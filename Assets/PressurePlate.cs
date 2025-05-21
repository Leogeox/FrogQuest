using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject toUnlock;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Objects"))
        {
            toUnlock.SetActive(false);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Objects"))
        {
            toUnlock.SetActive(true);
        }
    }
}
