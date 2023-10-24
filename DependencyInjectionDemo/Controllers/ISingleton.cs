namespace DependencyInjectionDemo.Controllers
{
    public interface ISingleton
    {
        Guid InstanceGuid { get; }
        int GetInstanceCount();
    }
}