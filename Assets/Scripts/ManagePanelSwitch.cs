using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePanelSwitch : MonoBehaviour
{
    [SerializeField] GameObject waterPanel;
    [SerializeField] GameObject sleepPanel;

    [SerializeField] AudioManager audioManager;

    public void openWaterPanel() 
    {
        waterPanel.gameObject.SetActive(true);
        sleepPanel.gameObject.SetActive(false);
        audioManager.playOpenMenu();

    }
    public void openSleepPanel()
    {
        waterPanel.gameObject.SetActive(false);
        sleepPanel.gameObject.SetActive(true);
        audioManager.playOpenMenu();
    }
    public void openMainPanel()
    {
        waterPanel.gameObject.SetActive(false);
        sleepPanel.gameObject.SetActive(false);
        audioManager.playCloseMenu();
    }
}
