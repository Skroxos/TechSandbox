using UnityEngine;

public class TestEntity : ISpatialEntity
{
    public Vector3 Position { get; private set; }

    public int Id { get; private set; }

    public TestEntity(Vector3 position)
    {
        Position = position;
    }
}
