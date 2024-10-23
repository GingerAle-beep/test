using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCount : MonoBehaviour
{
    [SerializeField] GameObject[] _keys;
    [SerializeField] GameObject _key;
    [SerializeField] PlayerInfo _playerInfo;
    // Start is called before the first frame update
    void Start()
    {
        _playerInfo._keys = -1;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < _keys.Length; i++)
        {
            
            if(i <= _playerInfo._keys == true)
            {
                _keys[i].SetActive(true);
            }
            else
            {
                _keys[i].SetActive(false);
            }

        }

        
    }
}
