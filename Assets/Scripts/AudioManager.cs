using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioClip closeMenu;
    public AudioClip openMenu;
    public AudioClip dailyObjective;
    public AudioClip waterSleepAdded;

    [SerializeField] Sprite volumeOn;
    [SerializeField] Sprite volumeOff;
    [SerializeField] Image silenceButton;

    private AudioSource source;

    private int soundEnabled = -1;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        soundEnabled = PlayerPrefs.GetInt("soundEnabled");
        if (soundEnabled == 0) 
        {
            Camera.main.GetComponent<AudioSource>().volume = 0;
            source.Stop();
            silenceButton.sprite = volumeOff;
        }
    }

    public void playOpenMenu() 
    {
        if (soundEnabled == 0) return;
        source.clip = openMenu;
        source.Play();
    }

    public void playCloseMenu()
    {
        if (soundEnabled == 0) return;
        source.clip = closeMenu;
        source.Play();
    }

    public void playWaterSleepAdded()
    {
        if (soundEnabled == 0) return;
        source.clip = waterSleepAdded;
        source.Play();
    }

    public void playDailyObjective()
    {
        if (soundEnabled == 0) return;
        source.clip = dailyObjective;
        source.Play();
    }

    public void switchSound() 
    {
        if (soundEnabled == 0)
        {
            soundEnabled = 1;
            silenceButton.sprite = volumeOn;
            Camera.main.GetComponent<AudioSource>().volume = 0.5f;
        }
        else 
        {
            soundEnabled = 0;
            silenceButton.sprite = volumeOff;
            source.Stop();
            Camera.main.GetComponent<AudioSource>().volume = 0;
        }

        PlayerPrefs.SetInt("soundEnabled", soundEnabled);
    }
}
