using UnityEngine;

public class EventTesterParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleEffectPrefab;
    private void OnEnable()
    {
        EventBus.Subscribe<DamageTakenEvent>(OnDamageTaken);
    }
    private void OnDisable()
    {
        EventBus.Unsubscribe<DamageTakenEvent>(OnDamageTaken);
    }
    private void OnDamageTaken(DamageTakenEvent damageEvent)
    {
        particleEffectPrefab.Play();
    }
}