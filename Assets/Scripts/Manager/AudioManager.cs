using UnityEngine;

public class AudioManager : MonoBehaviour
{
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
    public AudioClip climbingLadder;
    public AudioClip useTongue;
    public AudioClip death;

    private void Start()
    {
        musicSource.clip= background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
