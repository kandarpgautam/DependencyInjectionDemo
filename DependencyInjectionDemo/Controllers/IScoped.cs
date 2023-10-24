namespace DependencyInjectionDemo.Controllers
{
    public interface IScoped
    {
        Guid InstanceGuid { get; }
        int GetInstanceCount();
    }
}