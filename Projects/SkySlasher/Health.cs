using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    [SerializeField] public float _health = 100f;
    public float MaxHealth = 100f; 

    // vfx  
    public GameObject deathVFX;


    private void Start()
    {
        _health = MaxHealth;
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void OnDestroy()
    {
        WaveManager waveManager = FindObjectOfType<WaveManager>(); 
        if (waveManager != null)
        {
            waveManager.EnemyDestroyed();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }
    private void Die()
    {
        if (deathVFX != null)
        {
            // Instantiate the vfx at the position of the object with a y offset of 0.5
            Instantiate(deathVFX, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);

        }
        if (transform.parent != null)
        {
            Destroy(GetHighestParent(gameObject));  
        }
        else
        {
            Destroy(gameObject); 
        }

        if (CompareTag("Player"))
        {
            ReturnToScene();
        }
    }

    void ReturnToScene()
    {
        SceneManager.LoadScene(0);
    }

    public GameObject GetHighestParent(GameObject childObject)
    {
        // Starting the check from the first parent of the gameobject
        Transform currentCheck = childObject.transform.parent;

        if (currentCheck == null)
        {
            Debug.LogWarning("The childObject does not contain a gameObject");
        }

        // If the parent is null it means we found the highest parent
        // If we have not returned yet we will try to check the next parent
        while (true)
        {
            if (currentCheck.parent == null)
            {
                return currentCheck.gameObject;
            }

            currentCheck = currentCheck.parent;
        }
    }
}
