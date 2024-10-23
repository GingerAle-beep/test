using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatter : MonoBehaviour
{
    [SerializeField] GameObject _blood;
    [SerializeField] Transform _bloodSpawn;
    public Rigidbody _rb;
    [SerializeField] float _timer = 3f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        _timer -= 1 * Time.deltaTime;
        if(_timer <= 0)
        {
            Instantiate(_blood, _bloodSpawn.position, _bloodSpawn.rotation);
            _timer = 3f;
        }
    }
}
