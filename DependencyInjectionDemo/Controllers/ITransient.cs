namespace DependencyInjectionDemo.Controllers
{
    public interface ITransient
    {
        Guid InstanceGuid { get; }
        int GetInstanceCount();
    }
}