using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float MoveSpeed = 5f;
    [SerializeField]
    private float JumpForce = 10f;
    

    public Vector2 test; 


    private SpriteRenderer _sprite;
    private Rigidbody2D _rb;
    private Animator _animator;

    private float _moveInput;
    private bool _wantsToJump;
    private bool _isDead = false;

    private static Vector2 respawnPoint;


    [Header("RaycastController")]
    [SerializeField]
    private float PlayerHeight = 0.7f;
    [SerializeField]
    private LayerMask GroundMask;

    public Vector2 respawn
    {
        get { return respawnPoint; }
        set { respawnPoint = value; }
    }

    void Start()
    {
        transform.position = respawnPoint;
        test = respawnPoint;
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        bool onGround = Physics2D.Raycast(transform.position, Vector2.down, PlayerHeight, GroundMask);
        _moveInput = Input.GetAxis("Horizontal");
        _animator.SetFloat("velocityY", _rb.linearVelocityY);

        if (_moveInput != 0)
        {
            _animator.SetBool("isRunning", true);
            if (_moveInput < 0)
            {
                _sprite.flipX = true;
            }
            else if (_moveInput > 0)
            {
                _sprite.flipX = false;
            }
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }

        if (onGround)
        {
            _animator.SetBool("isGrounded", true);
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                _wantsToJump = true;
            }
        }
        else
        {
            _animator.SetBool("isGrounded", false);
        }
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_moveInput * MoveSpeed, _rb.linearVelocityY);
        if (_wantsToJump)
        {
            _wantsToJump = false;

            _rb.AddForceY(JumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.otherCollider.GetType() == typeof(CapsuleCollider2D) && !_isDead)
            {
                _isDead = true;
                _animator.SetBool("isDead", true);
                StartCoroutine(DeathCoroutine());
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            if (!collision.gameObject.GetComponent<RespawnPoint>().isActif)
            {
                print("Respawn touché");
                respawnPoint = transform.position;
                test = respawnPoint;
            }
        }
        if (collision.gameObject.CompareTag("DeathZone")&& !_isDead)
        {
            _isDead = true;
            print("DeathZone touché");
            StartCoroutine(DeathCoroutine());
        }
    }

    IEnumerator DeathCoroutine()
    {
        
            yield return new WaitForSeconds(1);
            GameManager.Instance?.Death();
    }
}
