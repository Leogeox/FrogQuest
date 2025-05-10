using UnityEngine;

public class ToggleSwitch : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            Debug.Log("Touched");
            door.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
