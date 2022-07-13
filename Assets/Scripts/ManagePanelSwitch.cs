using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePanelSwitch : MonoBehaviour
{
    [SerializeField] GameObject waterPanel;
    [SerializeField] GameObject sleepPanel;
    [SerializeField] GameObject storePanel;

    [SerializeField] AudioManager audioManager;

    public void openWaterPanel() 
    {
        waterPanel.gameObject.SetActive(true);
        audioManager.playOpenMenu();

    }
    public void openSleepPanel()
    {
        sleepPanel.gameObject.SetActive(true);
        audioManager.playOpenMenu();
    }
    public void openStorePanel()
    {
        storePanel.gameObject.SetActive(true);
        audioManager.playOpenMenu();
    }
    public void openMainPanel()
    {
        waterPanel.gameObject.SetActive(false);
        sleepPanel.gameObject.SetActive(false);
        storePanel.gameObject.SetActive(false);
        audioManager.playCloseMenu();
    }
}
