using VContainer;
using VContainer.Unity;

public static class InventoryExtensions
{
    public static void RegisterInventorySystem(this IContainerBuilder builder)
    {
        builder.Register<InventoryModel>(Lifetime.Singleton).WithParameter(20);
        builder.RegisterEntryPoint<InventoryPresenter>(Lifetime.Singleton);
    }
}