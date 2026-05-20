using UnityEngine;
using UnityEngine.UI;

public class EventTesterUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject deathText;


    private void Start()
    {
            healthSlider.maxValue = 100;
            healthSlider.value = 100;
            deathText.SetActive(false);
    }

    private void OnEnable()
    {
        EventBus.Subscribe<DamageTakenEvent>(OnDamageTaken);
        EventBus.Subscribe<PlayerDieEvent>(OnPlayerDie);
    }
    private void OnDisable()
    {
        EventBus.Unsubscribe<DamageTakenEvent>(OnDamageTaken);
        EventBus.Unsubscribe<PlayerDieEvent>(OnPlayerDie);
    }

    private void OnPlayerDie(PlayerDieEvent @event)
    {
        deathText.SetActive(true);
    }

    public void OnDamageTaken(DamageTakenEvent damageEvent)
    {
        healthSlider.value = damageEvent.RemainingHealth;
    }

}
