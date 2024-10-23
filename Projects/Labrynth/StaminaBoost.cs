using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBoost : MonoBehaviour, ICollectible
{
    private PlayerController playercon;
    private float staminaBoost = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {//checks for tag and calls the playerscript and than checks if its not null and calls the collect function
        
            playercon = other.gameObject.GetComponent<PlayerController>();

            if (playercon != null)
            {
                Collect();
            }
            Debug.Log("Collected");
        }
    }
    public void Collect()
    {//checks playerscript is null than returns if it is else it calls the currentstaminavarable and adds the boost & destroys object
        if (playercon == null)
        {
            Debug.Log("can't collect");
            return;
        }
        playercon.currentStamina += staminaBoost;

        Destroy(gameObject);
    }
}
