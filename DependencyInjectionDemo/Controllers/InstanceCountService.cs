namespace DependencyInjectionDemo.Controllers
{
    public class InstanceCountService : ISingleton, IScoped, ITransient
    {
        private static int InstanceCount { get; set; }

        public Guid InstanceGuid { get; set; } = Guid.NewGuid();
        public InstanceCountService()
        {
            InstanceCount++;
            Console.WriteLine($"Instance Created: {InstanceCount} Guid: --> {InstanceGuid}");
        }

        public int GetInstanceCount()
        {
            return InstanceCount;
        }
    }
}
