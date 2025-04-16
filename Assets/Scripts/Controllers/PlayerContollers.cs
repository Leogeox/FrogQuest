using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerContollers : MonoBehaviour
{
    private Collider2D _collider2D;
    private SpriteRenderer _spriteRend;
    private Transform _transform;

    [Header("Wall")]
    private Rigidbody2D _rgbd2d;
    public float _distanceDW;
    public LayerMask detectground;

    [Header("Jump")]
    [SerializeField] public int limitJump = 2;
    private int _currentJump;
    public int speedMove = 5;
    [SerializeField] public float forcejump = 15 ;

    [Header("WallSliding")]
    [SerializeField] public float wallSlidespeed = 0;
    [SerializeField] public Transform wallCheckPoint;
    [SerializeField] Vector2 wallCheckSize;
    private bool isSliding;
    private bool isOnWall;

    [Header("WallJump")]
    [SerializeField] public float wallJumpForce = 18;
    [SerializeField] public float wallJumpDirection = -1f;
    [SerializeField] Vector2 wallJumpAngle;
    private int _currentWallJump;

    [Header("Ladder")]
    private float _vertical;
    private bool _isLadder;
    private bool _isClimbing;

    [Header("Crouch/Ramp")]
    public Transform playerTransform;
    public float normalHeight, crouchHeight, rampHeight;
    public int speedCrouch = 4;
    public int speedRamp = 3;

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

        if (Input.GetKeyDown(KeyCode.Space) && _currentJump < limitJump)
            Jump();

        Slide();
        WallJumping();

        _vertical = Input.GetAxisRaw("Vertical");
        if (_isLadder && Mathf.Abs(_vertical) > 0f)
        {
            _isClimbing = true;
        }

        Crouch();
        Ramp();
    }


    private void FixedUpdate()
    {
        if (_isClimbing)
        {
            _rgbd2d.gravityScale = 0f;
            _rgbd2d.linearVelocity = new Vector2(_rgbd2d.linearVelocity.x, _vertical * speedMove);
        }
        else
        {
            _rgbd2d.gravityScale = 3f;
        }

    }

    void Move()
    {
        Vector3 direction = Input.GetAxis("Horizontal") * Vector2.right;

        var ground = Physics2D.BoxCast(_transform.position, Vector2.one, 0, direction, _distanceDW, detectground);
        if (ground.collider != null)
            return;

        if (!Input.GetKey(KeyCode.LeftControl))
        {
            if(Input.GetAxis("Horizontal") < 0)
               _transform.rotation = Quaternion.Euler(0, 180, 0);
            else
                _transform.rotation = Quaternion.Euler(0, 0, 0);

        }

        _transform.position += Vector3.right * Input.GetAxisRaw("Horizontal") * speedMove * Time.deltaTime;
    }

    void Jump()
    {
        _rgbd2d.linearVelocity = Vector2.up * forcejump;
        _currentJump++;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") || collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
            _currentJump = 0;
    }

    void Slide()
    {
        Vector3 direction = Input.GetAxis("Horizontal") * Vector2.right;

        var ground = Physics2D.BoxCast(_transform.position, Vector2.one, 0, direction, _distanceDW, detectground);
        isOnWall = Physics2D.OverlapBox(wallCheckPoint.position, wallCheckSize, 0, detectground);

        if (isOnWall && _rgbd2d.linearVelocity.y < 0)
        {
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }

        if (isSliding)
        {
            _rgbd2d.linearVelocity = new Vector2(_rgbd2d.linearVelocity.x, wallSlidespeed);
        }
    }

    void WallJumping()
    {
        wallJumpDirection *= -1;

        if (isSliding || isOnWall)
        {
            _rgbd2d.AddForce(new Vector2(wallJumpForce * wallJumpDirection * wallJumpAngle.x, wallJumpForce * wallJumpAngle.y), ForceMode2D.Impulse);
            _currentWallJump++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            _isLadder = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            _isLadder = false;
            _isClimbing = false;
        }
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerTransform.localScale = new Vector3(playerTransform.localScale.x, crouchHeight, playerTransform.localScale.z);
            speedMove = speedCrouch;
            _rgbd2d.gravityScale = 0f;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            playerTransform.localScale = new Vector3(playerTransform.localScale.x, normalHeight, playerTransform.localScale.z);
            speedMove = 4;
            _rgbd2d.gravityScale = 3f;
        }
    }

    void Ramp()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            playerTransform.localScale = new Vector3(playerTransform.localScale.x, rampHeight, playerTransform.localScale.z);
            speedMove = speedRamp;
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            playerTransform.localScale = new Vector3(playerTransform.localScale.x, normalHeight, playerTransform.localScale.z);
            speedMove = 4;
        }
    }
}
