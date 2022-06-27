using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip closeMenu;
    public AudioClip openMenu;
    public AudioClip dailyObjective;
    public AudioClip waterSleepAdded;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void playOpenMenu() 
    {
        source.clip = openMenu;
        source.Play();
    }

    public void playCloseMenu()
    {
        source.clip = closeMenu;
        source.Play();
    }

    public void playWaterSleepAdded()
    {
        source.clip = waterSleepAdded;
        source.Play();
    }

    public void playDailyObjective()
    {
        source.clip = dailyObjective;
        source.Play();
    }
}
