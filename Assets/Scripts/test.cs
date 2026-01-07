using UnityEngine;
using UnityEngine.InputSystem;

public class test : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 1f;
    [SerializeField]
    private float JumpForce = 1f;


    private Rigidbody2D _rb;
    private Animator _animator;

    [Header("RaycastController")]
    [SerializeField]
    private float PlayerHeight = 0.7f;
    [SerializeField]
    private LayerMask GroundMask;


    private bool _wantsToJump;

    private Vector2 _position;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            _wantsToJump = true;
        }

              

        if (Physics2D.Raycast(transform.position, Vector2.down, PlayerHeight, GroundMask))
        {
            _animator.SetBool("isGrounded", true); 
        } else
        {
            _animator.SetBool("isGrounded", false);
        }
        
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            transform.position = _position;
        }
    }

    private void FixedUpdate()
    {
        if (_wantsToJump)
        {
            _rb.linearVelocity = new Vector2(MoveSpeed, _rb.linearVelocityY);
            _rb.AddForceY(JumpForce, ForceMode2D.Impulse);
            _wantsToJump = false;
        }
    }
}
