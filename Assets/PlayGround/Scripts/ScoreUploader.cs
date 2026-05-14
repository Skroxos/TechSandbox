using UnityEngine;
using VContainer;

public class ScoreUploader : MonoBehaviour
{
    private FirstApiCall _firstApiCall;

    [Inject]
    public void Construct(FirstApiCall firstApiCall)
    {
        _firstApiCall = firstApiCall;
    }

    public async void OnUploadButtonClicked()
    {
        Debug.Log("Clicked on button");
        string testJson = "{\"score\": 999}";
        await _firstApiCall.SendPostRequestAsync("https://jsonplaceholder.typicode.com/posts", testJson);
    }
}
