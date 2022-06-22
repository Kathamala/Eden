using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePanelSwitch : MonoBehaviour
{
    [SerializeField] GameObject waterPanel;
    [SerializeField] GameObject sleepPanel;

    public void openWaterPanel() 
    {
        waterPanel.gameObject.SetActive(true);
        sleepPanel.gameObject.SetActive(false);
    }
    public void openSleepPanel()
    {
        waterPanel.gameObject.SetActive(false);
        sleepPanel.gameObject.SetActive(true);
    }
    public void openMainPanel()
    {
        waterPanel.gameObject.SetActive(false);
        sleepPanel.gameObject.SetActive(false);
    }
}
