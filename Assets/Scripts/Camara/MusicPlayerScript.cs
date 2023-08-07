using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerScript : MonoBehaviour
{   private AudioSource AudioSource;
    public Slider volumeSlider;
    public GameObject ObjectMusic;
    public float MusicVolume ;
        
        
    // Start is called before the first frame update
    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();
            
            
        MusicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = MusicVolume;
        volumeSlider.value = MusicVolume;
    
    }
    
    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("volume", MusicVolume);
    }
    
        
        
    public void UpdateVolume(float volume)
    {
        MusicVolume = volume;
    }
    
    public void ResetMusic()
    {
        PlayerPrefs.DeleteKey("volume");
        AudioSource.volume = 1;
        volumeSlider.value = 1;
    }
}
