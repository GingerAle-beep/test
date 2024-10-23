using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerDeathOnCollision : MonoBehaviour
{
    [SerializeField] GameObject _explosionEffect;   
    [SerializeField] private Transform _checkPoint;
    
    // Called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering GameObject has the "Checkpoint" tag
        if (other.gameObject.CompareTag("Checkpoint"))
        { 
            // Update the checkpoint reference to the entering GameObject's transform
            _checkPoint = other.transform;
        }
    }

// Called when this collider collides with another collider
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding GameObject has the "Environment" tag
        if (collision.gameObject.CompareTag("Wall"))
        {
            MoveBoat.moveBoat.boatLives--;
        }
        
        if (MoveBoat.moveBoat.boatLives == 0)
        {
            // Start the WaitExplode coroutine
            StartCoroutine(WaitExplode()); 
        }
    }

// Coroutine to wait for a short duration, activate and deactivate explosion effect, and reset position to checkpoint
    IEnumerator WaitExplode()
    {
        // Activate the explosion effect GameObject
        _explosionEffect.SetActive(true);

        // Wait for 0.4 seconds
        yield return new WaitForSeconds(0.4f);

        // Deactivate the explosion effect GameObject
        _explosionEffect.SetActive(false);

        // Reset the position of this GameObject to the checkpoint position
        transform.position = _checkPoint.position;

        MoveBoat.moveBoat.boatLives = 10;
    }

    
}
