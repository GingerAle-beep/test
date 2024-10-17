using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Show Upgrade 

    public GameObject upgradePopUP;

    public void ShowUpgradePopup()
    { 
        Debug.Log("Show Upgrade Popup"); 

        upgradePopUP.SetActive(true);
    }


}
