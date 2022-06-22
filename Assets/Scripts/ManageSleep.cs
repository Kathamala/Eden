using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageSleep : MonoBehaviour
{

    [SerializeField] Text hoursInput;
    [SerializeField] Text minutesInput;
    [SerializeField] Text totalHoursSleptText;
    [SerializeField] Text totalMinutesSleptText;

    public void saveTimeSlept() 
    {
        if (!validateInputs()) { return; }

        int hours = int.Parse(hoursInput.text);
        int minutes = int.Parse(minutesInput.text);

        GameDataManager.addMinutesSleepSaved((hours*60) + minutes);

        updateSleepTexts();
        //Debug.Log("OK");
    }

    bool validateInputs() 
    {
        if (hoursInput.text == "" && minutesInput.text == "")
        {
            //Debug.Log("Hours and minutes can't be empty!");
            return false;
        }
        /*
        if (minutesInput.text == "")
        {
            //Debug.Log("Minutes can't be empty!");
            return false;
        }*/
        if (int.Parse(hoursInput.text) < 0)
        {
            //Debug.Log("Hours can't be negative!");
            return false;
        }
        if (int.Parse(minutesInput.text) < 0)
        {
            //Debug.Log("Minutes can't be negative!");
            return false;
        }
        if (int.Parse(minutesInput.text) >= 60)
        {
            //Debug.Log("Minutes can't be greater than 59!");
            return false;
        }

        return true;
    }

    void updateSleepTexts() 
    {
        int totalHours = GameDataManager.getOnlyHoursSleepSaved();
        int totalMinutes = GameDataManager.getOnlyMinutesSleepSaved();

        totalHoursSleptText.text = totalHours.ToString();
        totalMinutesSleptText.text = totalMinutes.ToString();
    }
}
