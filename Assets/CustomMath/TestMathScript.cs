using CustomMath;
using UnityEngine;

public class TestMathScript : MonoBehaviour
{
   public Vector3 position;
   public Vector3 center;
   public float radius;
   private void Start()
   {
      Debug.Log(MathC.IsPointInRadius(position, center, radius));
      Debug.Log(MathC.IsPointInRadius(new Vector2(1,2), new Vector2(3,4), radius));
   }
}
