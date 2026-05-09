using System;
using UnityEngine;
using UnityEngine.UI;

public class UIStuff : MonoBehaviour
{
    [SerializeField] private Button[] spellButtons;
    public static event Action<int> OnButtonPressed;



    private void Awake()
    {
        for (int i = 0; i < spellButtons.Length; i++)
        {
            int index = i;
            spellButtons[i].onClick.AddListener(() => HandleButtonPressed(index));
        }
    }

    void HandleButtonPressed(int index)
    {
        OnButtonPressed?.Invoke(index);
    }

}