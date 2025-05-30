using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryHolder : MonoBehaviour
{
    public event EventHandler OnKeyChanged;
    private List<Key.KeyColor> keyList;

    AudioManager audioManager;

    private void Awake()
    {
        keyList = new List<Key.KeyColor>();
    }

    public List<Key.KeyColor> GetKeyList()
    {
        return keyList;
    }

    public void AddKey(Key.KeyColor keyColor)
    {
        Debug.Log("Key added");
        keyList.Add(keyColor);
        OnKeyChanged?.Invoke(this, EventArgs.Empty);
        audioManager.PlaySFX(audioManager.keyPickup);
    }

    public bool ContainsKey(Key.KeyColor keyColor)
    {
        return keyList.Contains(keyColor);
    }

    public void RemoveKey(Key.KeyColor keyColor)
    {
        keyList.Remove(keyColor);
        OnKeyChanged?.Invoke(this, EventArgs.Empty);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Key key = collision.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyColor());
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = collision.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyId()))
            {
                RemoveKey(keyDoor.GetKeyId());
                keyDoor.OpenDoor();
                Debug.Log("Open Door and Key erased");
            }
        }
    }
}
