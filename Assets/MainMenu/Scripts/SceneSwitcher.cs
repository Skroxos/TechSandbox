using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public sealed class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private AssetReference _sceneReference;
   
   

    private async void OnTriggerEnter(Collider other)
    {
        if (!_sceneReference.RuntimeKeyIsValid())
        {
            Debug.LogError("Scene reference not assigned");
            return;
        }
        await LoadSceneAsync();
    }
    private async UniTask LoadSceneAsync()
    {
        var handle = Addressables.LoadSceneAsync(_sceneReference, LoadSceneMode.Single);
        await handle.ToUniTask();
    }
}

  

