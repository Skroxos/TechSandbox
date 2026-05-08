using System.Runtime.CompilerServices;
using UnityEngine;

namespace CustomMath
{
    public static class MathC
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPointInRadius(in Vector3 position,in Vector3 center, float radius)
        {
           float dx = position.x - center.x;
           float dy = position.y - center.y;
           float dz = position.z - center.z;
           
           float sqrDistance = dx * dx + dy * dy + dz * dz;
           
           return sqrDistance <= radius * radius;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPointInRadius(Vector2 position, Vector2 center, float radius)
        {
            float dx = position.x - center.x;
            float dy = position.y - center.y;

            float sqrDistance = dx * dx + dy * dy;
           
            return sqrDistance <= radius * radius;
        }
    }
}
