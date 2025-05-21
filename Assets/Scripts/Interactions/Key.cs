using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField] private KeyColor keyColor;

    public enum KeyColor
    {
        Red,
        Green,
        Blue
    }

    public KeyColor GetKeyColor()
    {
        return keyColor;
    }

}
