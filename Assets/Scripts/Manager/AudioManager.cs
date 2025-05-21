using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("AUDIO MIXER")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("AUDIO SOURCE")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

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

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
        Debug.Log("master");
    }

    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        Debug.Log("music");
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
        Debug.Log("SFX");
    }

}
