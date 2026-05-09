using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public void Move(Vector3 dir)
    {
        transform.position = transform.position + dir;
    }
}
