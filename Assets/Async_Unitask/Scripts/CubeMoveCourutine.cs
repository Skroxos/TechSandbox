using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CubeMoveCourutine : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(MoveCubesCoroutine());
    }

    public IEnumerator MoveCubesCoroutine()
    {

        while (true)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + Mathf.Sin(Time.time), gameObject.transform.position.z);
            yield return null;
        }
    }
}
