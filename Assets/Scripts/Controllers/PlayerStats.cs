using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    public int life = 3;
    private Rigidbody2D _rgbd2d;
    private bool isFalling;
    private float relVelY;

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
            }
            else if (relVelY > -30)
            {
                life--;
                Debug.Log(life);
            }
        }

        if (life <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
