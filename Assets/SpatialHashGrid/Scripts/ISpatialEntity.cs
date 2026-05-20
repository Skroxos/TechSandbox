using UnityEngine;

public interface ISpatialEntity
{
    int Id { get; }
    Vector3 Position { get; }
}