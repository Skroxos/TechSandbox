using Cysharp.Threading.Tasks;

public interface INetworkService
{
    UniTask SendPostRequestAsync(string url, string jsonPayload);
}