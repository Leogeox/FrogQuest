using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject Panel;
    public static bool Opened;

    void Start()
    {
        Panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
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
