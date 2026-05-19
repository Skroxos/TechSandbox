using UnityEngine;

public class Controller : MonoBehaviour
{
    private DamageSystem _damageSystem;
    private EntityData[] _entityDatas;

    private void Start()
    {
        _damageSystem = new DamageSystem();
        _entityDatas = new EntityData[10];

        for (int i = 0; i < _entityDatas.Length; i++)
        {
            _entityDatas[i] = new EntityData(100);
        }
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _damageSystem.CalculateDamage(ref _entityDatas[0], 20);
            Debug.Log($"Enemy 0 HP: {_entityDatas[0].Health}");
        }
    }

}
