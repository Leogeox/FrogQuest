using UnityEngine;

public class KeyDoor : MonoBehaviour
{

    [SerializeField] private Key.KeyColor keyColor;
    AudioManager audioManager;

    public Key.KeyColor GetKeyId()
    {
        return keyColor;
    }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
        // audioManager.PlaySFX(audioManager.keyDoorOpen);
    }
}
