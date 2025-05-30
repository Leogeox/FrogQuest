using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("AUDIO MIXER")]
    [SerializeField] AudioMixer audioMixer;

    [Header("AUDIO SOURCE")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("SLIDERS")]
    [SerializeField] Slider audioSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    [Header("MIXERS")]
    const string MIXER_MUSIC = "Music";
    const string MIXER_SFX = "SFX";
    const string MIXER_MASTER = "Master";

    [Header("AUDIO CLIP")]
    public AudioClip background;
    public AudioClip walkOnGrass;
    public AudioClip walk;
    public AudioClip fallOnGrass;
    public AudioClip fall;
    public AudioClip jumpGrass;
    public AudioClip jump;
    public AudioClip wallJump;
    public AudioClip climbingLadder;
    public AudioClip useTongue;
    public AudioClip death;
    public AudioClip keyPickup;
    public AudioClip keyDoorOpen;
    public AudioClip keyDoorClose;
    public AudioClip NPCtalk;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        audioSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    
    void SetMusicVolume(float value)
    {
        audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }

    void SetSFXVolume(float value)
    {
        audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }

    void SetMasterVolume(float value)
    {
        audioMixer.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20);
    }

}
