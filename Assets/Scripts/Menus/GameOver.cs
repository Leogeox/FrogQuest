using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameOver : MonoBehaviour
{
    public GameObject gameover;
    [SerializeField] private PlayerLife player;
    [SerializeField] private GrabbingTongue tongue;

    void Start()
    {
        gameover.SetActive(false);
    }

    // void Update()
    // {
    //     if (player.life <= 0)
    //     {
    //         gameover.SetActive(true);
    //         tongue.enabled = false;
    //         tongue.enabled = false;
    //     }
    //     else
    //     {
    //         gameover.SetActive(false);
    //     }
    // }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("FrogQuest");
    }

}

