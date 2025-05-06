using UnityEngine;

public class PlayerStats : MonoBehaviour
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
                Debug.Log("0 hearts");

                if (gameObject.CompareTag("NonGrass"))
                {
                    audioManager.PlaySFX(audioManager.death);
                }
            }
            else if (relVelY > -30)
            {
                life--;
                Debug.Log(life);

                if (gameObject.CompareTag("NonGrass"))
                {
                    audioManager.PlaySFX(audioManager.fall);
                    Debug.Log("player fall");
                }
                else if (gameObject.CompareTag("Grass"))
                {
                    audioManager.PlaySFX(audioManager.fallOnGrass);
                    Debug.Log("player fall grass");
                }
            }
        }

        if (life <= 0)
        {
            Debug.Log("Game Over");

            if (gameObject.layer == LayerMask.NameToLayer("Ground") || gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                audioManager.PlaySFX(audioManager.death);
                Debug.Log("player dead");
            }
        }
    }
}
