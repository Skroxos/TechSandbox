using Unity.Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject firstPersonCamera;
    [SerializeField] private GameObject thirdPersonCamera;
    private bool isInThirdPerson = true;

    private void Start()
    {
        ApplyCameraState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            isInThirdPerson = !isInThirdPerson;
            ApplyCameraState();
        }
    }

    private void ApplyCameraState()
    {
        firstPersonCamera.SetActive(!isInThirdPerson);
        thirdPersonCamera.SetActive(isInThirdPerson);
    }
}
