using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantBehavior : MonoBehaviour
{
    [SerializeField] private PlantScriptableObject[] plantScriptableObjects;
    int plantType = 0;
    int wateredAmount = 0;
    private void OnEnable()
    {
        EventManager.UserDrankWaterEvent += setWateredAmount;
    }
    private void OnDisable()
    {
        EventManager.UserDrankWaterEvent -= setWateredAmount;
    }
    public void setPlantType(int index)
    {
        if (index >= plantScriptableObjects.Length)
        {
            Debug.LogError("Index out of range");
            return;
        }
        plantType = index;
        GetComponent<Image>().sprite = plantScriptableObjects[index].Sprites[0];
    }
    public void setWateredAmount(int amount)
    {
        wateredAmount += amount;
        Debug.Log(wateredAmount);
        if (wateredAmount >= plantScriptableObjects[plantType].waterLevels[2])
        {
            GetComponent<Image>().sprite = plantScriptableObjects[plantType].Sprites[3];
        }
        else if (wateredAmount >= plantScriptableObjects[plantType].waterLevels[1])
        {
            GetComponent<Image>().sprite = plantScriptableObjects[plantType].Sprites[2];
        }
        else if (wateredAmount >= plantScriptableObjects[plantType].waterLevels[0])
        {
            GetComponent<Image>().sprite = plantScriptableObjects[plantType].Sprites[1];
        }
        else
        {
            GetComponent<Image>().sprite = plantScriptableObjects[plantType].Sprites[0];
        }
    }
}
