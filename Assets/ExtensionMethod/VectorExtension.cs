using UnityEngine;


public static class VectorExtension
{
    public static Vector3 WithX(this Vector3 v, float x) => new Vector3(x, v.y, v.z);

    public static Vector3 WithY(this Vector3 v, float y) => new Vector3(v.x, y, v.z);

    public static Vector3 WithZ(this Vector3 v, float z) => new Vector3(v.x, v.y, z);

    public static Vector3 WithXY(this Vector3 v, float x, float y) => new Vector3(x, y, v.z);

    public static Vector3 WithXZ(this Vector3 v, float x, float z) => new Vector3(x, v.y, z);

    public static Vector3 WithYZ(this Vector3 v, float y, float z) => new Vector3(v.x, y, z);
}

