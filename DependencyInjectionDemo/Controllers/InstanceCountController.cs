

using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstanceCountController : ControllerBase
    {
        public InstanceCountController(ISingleton singleton, IScoped scoped, ITransient transient)
        {
            Console.WriteLine("Constructor start");
            Singleton = singleton;// 1st time
            Scoped = scoped;// 1st time
            Transient = transient; // 1st time
        }

        public ISingleton Singleton { get; }
        public IScoped Scoped { get; }
        public ITransient Transient { get; }

        [HttpGet("GetInstanceCount")]
        public IActionResult GetInstanceCount(IServiceProvider serviceProvider)
        {
            Console.WriteLine("Start calling");

            // get singleton 3 times
            var singleton1  = serviceProvider.GetRequiredService<ISingleton>();
            var singleton2  = serviceProvider.GetRequiredService<ISingleton>();
            var singleton3 = serviceProvider.GetRequiredService<ISingleton>();  
            Console.WriteLine($"singleton1 Guid: {singleton1.InstanceGuid}");
            Console.WriteLine($"singleton2 Guid: {singleton2.InstanceGuid}");
            Console.WriteLine($"singleton3 Guid: {singleton3.InstanceGuid}");
            Console.WriteLine("singleton call end");
            // get scoped 3 times
            var scoped1 = serviceProvider.GetRequiredService<IScoped>();
            var scoped2= serviceProvider.GetRequiredService<IScoped>(); 
            var scoped3 = serviceProvider.GetRequiredService<IScoped>();
            Console.WriteLine($"Scoped1 Guid: {scoped1.InstanceGuid}");
            Console.WriteLine($"scoped2 Guid: {scoped2.InstanceGuid}");
            Console.WriteLine($"scoped3 Guid: {scoped3.InstanceGuid}");
            Console.WriteLine("Scoped call end");

            //get transient 3 times
            var transient1 = serviceProvider.GetRequiredService<ITransient>();
            var transient2 = serviceProvider.GetRequiredService<ITransient>();
            var transient3 = serviceProvider.GetRequiredService<ITransient>();
            Console.WriteLine($"transient1 Guid: {transient1.InstanceGuid}");
            Console.WriteLine($"transient2 Guid: {transient2.InstanceGuid}");
            Console.WriteLine($"transient3 Guid: {transient3.InstanceGuid}");
            Console.WriteLine("Transient call end");

            // retrieve count from instance initialized in constructor
            int instanceCount = Singleton.GetInstanceCount();

            return Ok(new { instanceCount });
        }
    }
}
