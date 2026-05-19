using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<FirstApiCall>(Lifetime.Singleton).As<INetworkService>();
        builder.RegisterComponentInHierarchy<ScoreUploader>();
    }
}
