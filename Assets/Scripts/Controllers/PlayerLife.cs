using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerLife : MonoBehaviour
{
    [Header("Stats")]
    public int life = 3;
    private Rigidbody2D _rgbd2d;
    private bool isFalling;
    private float relVelY;


    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        TryGetComponent(out _rgbd2d);
    }

    private void Update()
    {
        relVelY = _rgbd2d.linearVelocity.y;

        life = Mathf.Max(life, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (relVelY < -60)
            {
                life = 0;
                GameOver();
                
            }
            else if (relVelY > -30)
            {
                life--;
                Debug.Log(life);

                if (collision.gameObject.CompareTag("NonGrass"))
                {
                    audioManager.PlaySFX(audioManager.fall);
                    Debug.Log("player fall");
                }
                else if (collision.gameObject.CompareTag("Grass"))
                {
                    audioManager.PlaySFX(audioManager.fallOnGrass);
                    Debug.Log("player fall grass");
                }
            }
        }
    }

    public void GameOver()
    {
        if (life == 0)
        {
            Debug.Log("Game Over");
            audioManager.PlaySFX(audioManager.death);
            Time.timeScale = 0f;
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("FrogQuest");
    }
}
