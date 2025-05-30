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
    private bool firstTime = true;
    private bool isFalling = false;
    private Vector3 previousPosition;
    private float highestPosition;

    private bool isGrounded;


    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        TryGetComponent(out _rgbd2d);
        previousPosition = transform.position;
    }
    private void Update()
    {
        life = Mathf.Max(life, 0);

        isGrounded = IsGrounded();


        if (!isGrounded)
        {
            if (transform.position.y < previousPosition.y && firstTime)
            {
                firstTime = false;
                isFalling = true;
                highestPosition = previousPosition.y;
            }
        }

        if (isGrounded && isFalling)
        {
            if (highestPosition - transform.position.y > 10)
            {
                TakeDamage(1);
                Debug.Log(life);
            }
            else if (highestPosition - transform.position.y > 20)
            {
                life = 0;
                Debug.Log(life);
            }

            isFalling = false;
            firstTime = true;
        }

        previousPosition = transform.position;
    }

    bool IsGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f + extraHeight, LayerMask.GetMask("Ground"));
        return hit.collider != null;
    }

    void TakeDamage(int damage)
    {
        life -= damage; 
    }

    


    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     relVelY = _rgbd2d.linearVelocity.y;

    //     if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //     {

    //         if (collision.gameObject.CompareTag("NonGrass"))
    //         {
    //             audioManager.PlaySFX(audioManager.fall);
    //         }
    //         else if (collision.gameObject.CompareTag("Grass"))
    //         {
    //             audioManager.PlaySFX(audioManager.fallOnGrass);
    //         } 


    //         if (relVelY < -20f)
    //         {
    //             life = 0;
    //             GameOver();

    //         }

    //         else if (relVelY <= -10f)
    //         {
    //             life--;
    //         }
    //     }
    // }

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
