using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNoiseTimer : MonoBehaviour
{
    [SerializeField] AudioSource _BullSound;
    public float _timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= 1 * Time.deltaTime;

        if(_timer <= 0)
        {
            _BullSound.enabled = true;
            _timer = 4.5f;

        }
        if(_BullSound.time >= 2f)
        {
            _BullSound.enabled = false;
        }
    }
}
