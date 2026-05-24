using VContainer;
using VContainer.Unity;

public static class CraftingSystemExtensions
{
    public static void RegisterCraftingSystem(this IContainerBuilder builder)
    {
        builder.Register<CraftingModel>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<CraftingView>();
        builder.RegisterEntryPoint<CraftingPresenter>(Lifetime.Singleton);
    }
}
