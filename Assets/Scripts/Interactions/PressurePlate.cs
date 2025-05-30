using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject toUnlock;
    AudioManager audioManager;
    public Animator animator;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Objects"))
        {
            toUnlock.SetActive(false);
            // audioManager.PlaySFX(audioManager.keyDoorOpen);
            animator.SetBool("isPressure", true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Objects"))
        {
            toUnlock.SetActive(true);
            // audioManager.PlaySFX(audioManager.keyDoorClose);
            animator.SetBool("isPressure", false);
        }
    }
}
