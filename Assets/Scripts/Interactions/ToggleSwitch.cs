using UnityEngine;

public class ToggleSwitch : MonoBehaviour
{
    public GameObject door;
    AudioManager audioManager;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            door.gameObject.SetActive(false);
            // audioManager.PlaySFX(audioManager.keyDoorOpen);
            animator.SetBool("Activate", true);
        }
    }
}
