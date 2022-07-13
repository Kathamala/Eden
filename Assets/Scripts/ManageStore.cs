using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManageStore : MonoBehaviour
{
    [SerializeField] int[] plantsPrices;
    [SerializeField] GameObject[] plants;

    [SerializeField] TextMeshProUGUI dreamcoinText;

    [SerializeField] GameObject plantsOwnedHolder;

    // Start is called before the first frame update
    void Start()
    {
        SetPrices();
    }

    void SetPrices() 
    {
        for (int i = 0; i < plants.Length; i++)
        {
            plants[i].transform.Find("DreamcoinHolder").Find("DreamcoinsText").gameObject.GetComponent<TextMeshProUGUI>().text = plantsPrices[i].ToString();
        }
    }

    public void buyPlant(int plantIndex) 
    {
        if (!GameDataManager.removeCoins(plantsPrices[plantIndex - 1]))
        {
            Debug.Log("Você não têm moedas suficientes.");
            return;
        }
        if (!GameDataManager.addPlantsOwned(plants[plantIndex - 1]))
        {
            Debug.Log("Não há mais espaço para plantas.");
            return;
        };

        updateCoinsText();
        addPlantToMainPanel(plantIndex);
    }

    void updateCoinsText()
    {
        int totalDreamcoins = GameDataManager.getCoins();

        dreamcoinText.text = totalDreamcoins.ToString();
    }

    void addPlantToMainPanel(int plantIndex) 
    {
        GameObject plant = Instantiate(plants[plantIndex - 1]);
        Destroy(plant.GetComponent<Button>());
        plant.transform.DetachChildren();
        plant.transform.SetParent(plantsOwnedHolder.transform);

        plant.GetComponent<RectTransform>().position = plantsOwnedHolder.transform.GetChild(GameDataManager.getPlantsOwned().Count-1).GetComponent<RectTransform>().position;
    }
}
