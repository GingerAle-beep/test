using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stamina : MonoBehaviour
{
    [SerializeField] private Slider staminaBarFill;//sliderbar for stamina in ui
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {//variables from the other scripts function to update it in the updatestaminabar function
        float currentStamina = playerController.GetCurrentStamina();
        float maxStamina = playerController.GetMaxStamina();

        UpdateStaminaBar(currentStamina, maxStamina);
    }
    private void UpdateStaminaBar(float currentStamina, float maxStamina)
    {
        staminaBarFill.value = currentStamina / maxStamina;
        //calculates the value of how full it is by doing currentstamina / maxstamina to find the value
    }
}
