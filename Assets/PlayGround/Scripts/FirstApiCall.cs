using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;

public class FirstApiCall
{
    private readonly string url = "https://jsonplaceholder.typicode.com/posts/1";

    
    public async void FetchData()
    {
        Debug.Log("Sending request");
        await SendGetRequestAsync(url);
    }

    private async UniTask SendGetRequestAsync(string url)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            try
            {
                await request.SendWebRequest().ToUniTask();

                if (request.responseCode == 200)
                {
                    string jsonResponse = request.downloadHandler.text;
                    PostData postData = JsonUtility.FromJson<PostData>(jsonResponse);
                    Debug.Log($"<color=cyan>Downloaded</color>");
                    Debug.Log($"ID User: {postData.UserId}");
                    Debug.Log($"(Title): {postData.title}");
                }
                else
                {
                    Debug.LogError("Server denied request Code: {request.responseCode}");
                }
            }
            catch (UnityWebRequestException ex)
            {
                Debug.LogError(ex.Message);
            }
        }
    }

    
    public async void SendData()
    {
        PostData newPost = new PostData
        {
            UserId = 123,
            id = 0,
            title = "Test send",
            body = "Trying to send data from Unity server",
        };

        string jsonPayload = JsonUtility.ToJson(newPost);
        Debug.Log($"Post data: {jsonPayload}");

        await SendPostRequestAsync("https://jsonplaceholder.typicode.com/posts", jsonPayload);
    }    

    public async UniTask SendPostRequestAsync(string url, string jsonPayload)
    {
        using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

        using (UnityWebRequest postRequest = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonPayload);
            postRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            postRequest.downloadHandler = new DownloadHandlerBuffer();

            postRequest.SetRequestHeader("Content-Type", "application/json");

            try
            {
                Debug.Log("Sending data to server");
                await postRequest.SendWebRequest().ToUniTask(cancellationToken: cts.Token);

                if (postRequest.responseCode == 200 || postRequest.responseCode == 201)
                {
                    Debug.Log($"<color=green>Data Send (Status {postRequest.responseCode})</color>");
                    Debug.Log($"Response:\n{postRequest.downloadHandler.text}");
                }
                else
                {
                    Debug.LogError($"failed. status code: {postRequest.responseCode}\n{postRequest.downloadHandler.text}");
                }
            }
            catch (OperationCanceledException)
            {
                Debug.LogError("Time limit");
            }

            catch (UnityWebRequestException ex)
            {
                Debug.LogError($"Error: {ex.Message}");
            }
        }
    }
}

[System.Serializable]
public class PostData
{
    public int UserId;
    public int id;
    public string title;
    public string body;
}
