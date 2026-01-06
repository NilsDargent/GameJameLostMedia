using UnityEngine;
using UnityEngine.InputSystem;

public class Mouvement : MonoBehaviour
{
    [SerializeField] 
    private float MoveSpeed = 5f;
    [SerializeField]
    private float JumpForce = 10f;
    

    private SpriteRenderer _sprite;
    private Rigidbody2D _rb;
    private Animator _animator;

    private float _moveInput;
    private bool _wantsToJump;


    [Header("RaycastController")]
    [SerializeField]
    private float PlayerHeight = 0.7f;
    [SerializeField]
    private LayerMask GroundMask;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        bool onGround = Physics2D.Raycast(transform.position, Vector2.down, PlayerHeight, GroundMask);
        _moveInput = Input.GetAxis("Horizontal");
        
        if (onGround)
        {
            _animator.SetBool("isJumping", false);
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                _wantsToJump = true;
                _animator.SetBool("isJumping", true);
            }

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
}
