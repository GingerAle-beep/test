using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Finishgame : MonoBehaviour
{
    [SerializeField] PlayerInfo _playerInfo;
    [SerializeField] public string _endScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Gate" && _playerInfo._keys >= 2)
        {
            SceneManager.LoadScene(_endScene);
        }
    }

}
