using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TechSandBox.Addressables.Scripts
{
    public class AddressableSpawner : MonoBehaviour
    {
        [SerializeField] public AssetReferenceGameObject prefabReference;

        private GameObject _spawnedInstance;

        public void SpawnObject()
        {
            if (_spawnedInstance != null)
            {
                Debug.LogWarning("An instance is already spawned. Please destroy it before spawning a new one.");
                return;
            }

            prefabReference.InstantiateAsync().Completed += OnInstatiateCompelted;
        }

        private void OnInstatiateCompelted(AsyncOperationHandle<GameObject> obj)
        {
            if (obj.Status == AsyncOperationStatus.Succeeded)
            {
                _spawnedInstance = obj.Result;
                Debug.Log("Object spawned successfully.");
            }
            else
            {
                Debug.LogError("Failed to spawn object.");
            }
        }

        public void DespawnObject()
        {
            if (_spawnedInstance != null)
            {
                prefabReference.ReleaseInstance(_spawnedInstance);
                _spawnedInstance = null;
                Debug.Log("Object despawned successfully.");
            }
        }
    }
}
