using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManageStore : MonoBehaviour
{
    [SerializeField] int[] plantsPrices;
    [SerializeField] GameObject[] seedTypes;

    [SerializeField] TextMeshProUGUI dreamcoinText;

    [SerializeField] GameObject plantsOwnedHolder;

    [SerializeField] GameObject plant;

    // Start is called before the first frame update
    void Start()
    {
        SetPrices();
    }

    void SetPrices() 
    {
        for (int i = 0; i < seedTypes.Length; i++)
        {
            seedTypes[i].transform.Find("DreamcoinHolder").Find("DreamcoinsText").gameObject.GetComponent<TextMeshProUGUI>().text = plantsPrices[i].ToString();
        }
    }

    public void buyPlant(int plantIndex) 
    {
        if (!GameDataManager.removeCoins(plantsPrices[plantIndex]))
        {
            Debug.Log("Você não têm moedas suficientes.");
            return;
        }
        GameObject newPlant = Instantiate(plant);
        if (!GameDataManager.addPlantsOwned(newPlant))
        {
            Debug.Log("Não há mais espaço para plantas.");
            return;
        }
        else
        {
            updateCoinsText();
            addPlantToMainPanel(plantIndex, newPlant);
        };
    }

    void updateCoinsText()
    {
        int totalDreamcoins = GameDataManager.getCoins();

        dreamcoinText.text = totalDreamcoins.ToString();
    }

    void addPlantToMainPanel(int plantTypeIndex, GameObject newPlant) 
    {
        newPlant.transform.SetParent(plantsOwnedHolder.transform);
        newPlant.GetComponent<PlantBehavior>().setPlantType(plantTypeIndex);
        newPlant.GetComponent<RectTransform>().position = plantsOwnedHolder.transform.GetChild(GameDataManager.getPlantsOwned().Count-1).GetComponent<RectTransform>().position;
    }
}
