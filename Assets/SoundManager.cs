using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Audio players components.
    public AudioSource EffectsSource;
    public AudioSource MusicSource;
    [SerializeField] private Slider musicSlider = null;
    [SerializeField] private Slider effectSlider = null;
    [SerializeField] ThirdPersonController player;

    // Singleton instance.
    public static SoundManager Instance = null;

    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadEffectVolume();
        LoadMusicVolume();
    }

    // Play a single clip through the sound effects source.
    public void Play(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }

    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    public void SaveMusicVolume()
    {
        float musicVolume = musicSlider.value;
        PlayerPrefs.SetFloat("MusicValue", musicVolume);
        LoadMusicVolume();
    }

    public void SaveEffectVolume()
    {
        float effectVolume = effectSlider.value;
        float playerEffect = effectSlider.value;
        PlayerPrefs.SetFloat("EffectValue", effectVolume);
        PlayerPrefs.SetFloat("PlayerEffect", playerEffect);
        player.FootstepAudioVolume = effectVolume;
        LoadEffectVolume(); 
    }

    void LoadMusicVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat("MusicValue");
        musicSlider.value = musicVolume;
        MusicSource.volume = musicVolume;
    }
    void LoadEffectVolume()
    {
        float effectVolume = PlayerPrefs.GetFloat("EffectValue");
        effectSlider.value = effectVolume;
        EffectsSource.volume = effectVolume;
    }
}