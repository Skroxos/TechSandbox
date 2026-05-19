using UnityEngine;
using VContainer;

public class ScoreUploader : MonoBehaviour
{
    private INetworkService _networkService;

    [Inject]
    public void Construct(INetworkService networkService )
    {
        _networkService = networkService;
    }

    public async void OnUploadButtonClicked()
    {
        Debug.Log("Clicked on button");
        string testJson = "{\"score\": 999}";
        await _networkService.SendPostRequestAsync("https://jsonplaceholder.typicode.com/posts", testJson);
    }
}
