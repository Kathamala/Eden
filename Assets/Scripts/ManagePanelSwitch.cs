using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePanelSwitch : MonoBehaviour
{
    [SerializeField] GameObject waterPanel;
    [SerializeField] GameObject sleepPanel;
    [SerializeField] GameObject storePanel;
    [SerializeField] GameObject pausePanel;

    [SerializeField] AudioManager audioManager;

    public void openWaterPanel() 
    {
        waterPanel.SetActive(true);
        audioManager.playOpenMenu();

    }
    public void openSleepPanel()
    {
        sleepPanel.SetActive(true);
        audioManager.playOpenMenu();
    }
    public void openStorePanel()
    {
        storePanel.SetActive(true);
        audioManager.playOpenMenu();
    }public void openPausePanel()
    {
        pausePanel.SetActive(true);
        audioManager.playOpenMenu();
    }
    public void openMainPanel()
    {
        waterPanel.SetActive(false);
        sleepPanel.SetActive(false);
        storePanel.SetActive(false);
        pausePanel.SetActive(false);
        audioManager.playCloseMenu();
    }
}
