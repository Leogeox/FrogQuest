using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Steles : MonoBehaviour
{
    public GameObject Panel;
    public static bool Opened;
    private bool playerInRange = false;

    void Start()
    {
        Panel.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Collision");
            if (Opened)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    
    public void PauseGame()
    {
        Panel.SetActive(true);
        Time.timeScale = 0f;
        Opened = true;
    }

    public void ResumeGame()
    {
        Panel.SetActive(false);
        Time.timeScale = 1f;
        Opened = false;
    }
}
