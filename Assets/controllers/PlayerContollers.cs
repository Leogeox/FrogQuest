using UnityEngine;

public class PlayerContollers : MonoBehaviour
{
    private Collider2D _collider2D;
    private SpriteRenderer _spriteRend;
    private Transform _transform;

    [Header("Wall")]
    private Rigidbody2D _rgbd2d;
    public float _distanceDW;
    public LayerMask detectwall;

    [Header("Move")]
    public float speedMove = 4;

    [Header("Jump")]
    [SerializeField] private float _forcejump = 5;
    [SerializeField] private int _limitJump = 2;
    private int _currentJump;

    void Awake()
    {
        TryGetComponent(out _rgbd2d);
        TryGetComponent(out _collider2D);
        TryGetComponent(out _spriteRend);
        TryGetComponent(out _transform);
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
            Move();

        if (Input.GetKeyDown(KeyCode.Space) && _currentJump < _limitJump)
            Jump();
    }

    void Move()
    {
        Vector3 direction = Input.GetAxis("Horizontal") * Vector2.right;

        var hit = Physics2D.BoxCast(_transform.position, Vector2.one, 0, direction, _distanceDW, detectwall);
        if (hit.collider != null)
            return;

        if (!Input.GetKey(KeyCode.LeftControl))
            _spriteRend.flipX = Input.GetAxis("Horizontal") < 0;

        _transform.position += Vector3.right * Input.GetAxisRaw("Horizontal") * speedMove * Time.deltaTime;
    }

    void Jump()
    {
        _rgbd2d.velocity = Vector2.up * _forcejump;
        _currentJump++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            _currentJump = 0;
    }
}