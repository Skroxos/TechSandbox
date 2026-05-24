using System.Collections.Generic;
using UnityEngine;

public class  CharacterStatsManager : MonoBehaviour
{
    public CharacterStats _stats;


    private List<BuffEffectSO> _activeBuffs = new List<BuffEffectSO>(16);
    private bool _stasAreDirty;


    public void AddBuff(BuffEffectSO buff)
    {
        _activeBuffs.Add(buff);
        _stasAreDirty = true;
    }

    private void Update()
    {
     ProccesBuffs(Time.deltaTime);

        if (_stasAreDirty)
        {
                RecalculateStats();
                _stasAreDirty = false;
        }
    }

    public void ProccesBuffs(float deltaTime)
    {
        for (int i = _activeBuffs.Count - 1; i >= 0; i--)
        {
            BuffEffectSO buff = _activeBuffs[i];
            buff.duration -= deltaTime;
            buff.OnTick(deltaTime, this);
            _activeBuffs[i] = buff;
            if (buff.duration <= 0)
            {
                _activeBuffs.RemoveAt(i);
                _stasAreDirty = true;
            }
        }
    }

    private void RecalculateStats()
    {
        _stats.currentAttackPower = _stats.baseAttackPower;
        _stats.currentHealth = _stats.baseHealth;
        _stats.currentDefense = _stats.baseDefense;
        _stats.currentSpeed = _stats.baseSpeed;
        foreach (var buff in _activeBuffs)
        {
            buff.ApplyEffect(this);
        }
    }
}
