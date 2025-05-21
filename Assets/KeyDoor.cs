using UnityEngine;

public class KeyDoor : MonoBehaviour
{

    [SerializeField] private Key.KeyColor keyColor;

    public  Key.KeyColor GetKeyId()
    {
        return keyColor;
    }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
