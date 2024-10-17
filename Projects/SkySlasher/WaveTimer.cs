using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveTimer : MonoBehaviour
{
    public float _waveTimer;
    public float _timeBetweenWaves;
    [Tooltip("put all the types of enemies in this slot")]
    public GameObject[] _enemies;
    [Tooltip("put the WaveText in this slot")]
    public Text _waveTimerText;
    public bool _waveTimerCount;
    
    
    void Update()
    {
        switch (_waveTimerCount)
        {
            case true:
                

                foreach (GameObject enemies in _enemies)
                {
                    //if there are no more enemies active in the hierarchy and the time between waves is 0 or less
                    if (!enemies.activeInHierarchy && _timeBetweenWaves <= 0)
                    {
                        //turn on the enemy spawner
                        //FindObjectOfType<EnemySpawner>().enabled = true;
                    }
                }
                //count down the wave timer
                _waveTimer -= Time.deltaTime;
                _waveTimerText.text = "Wave " + (int)_waveTimer;
                _timeBetweenWaves = 10;
                break;

            case false:
                _waveTimer = 60;
                //count down inbetween wave timer
                _timeBetweenWaves -= Time.deltaTime;
                _waveTimerText.text = "Next Wave In : " + (int)_timeBetweenWaves;
                //turn off the enemy spawner
                //FindObjectOfType<EnemySpawner>().enabled = false;
                break;

        }

        if (_waveTimer <= 0)
        {
            //wave timer shouldn't count down
            _waveTimerCount = false;
        }

        if(_timeBetweenWaves <= 0)
        {
            //wave timer should count down
            _waveTimerCount = true;
        }
    }

    

    
}
