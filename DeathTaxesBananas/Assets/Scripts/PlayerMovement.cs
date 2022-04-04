using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Controls the players walking, jumping, and crouching
 */
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;

    [Header("Movement")]
    public float _gravity = 10f;
    public float _moveForce = 10;
    public float _sprintForce = 15;
    public float _crouchForce = 5;
    private Vector3 _moveDirection = Vector3.zero;

    [Header("Jumping")]
    public float _jumpForce = 5f;
    public float _moveForceAirScale = 0.2f; // Percentage of your move speed while in the air

    [Header("Drag")]
    public float _groundDrag = 6f;
    public float _airDrag = 2f;

    public Transform _foot; // Used to calculate if we're touching the ground
    [HideInInspector] public bool _isSprinting = false;

    [Header("Ground Detection")]
    public LayerMask _groundLayers; // Layers that you can jump off of
    private bool _isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        // Grounded logic
        _isGrounded = Physics.CheckSphere(_foot.position, 0.3f, _groundLayers);

        // Movement logic
        Vector2 inputs = Vector2.ClampMagnitude(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")), 1);
        _moveDirection = transform.forward * inputs.y + transform.right * inputs.x;

        // Jumping logic
        if (Input.GetButtonDown("Jump") && _isGrounded) {
            _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        }

        // Drag logic
        _rb.drag = (_isGrounded) ? _groundDrag : _airDrag;
    }

    // Use fixed update for rigidbody physics
    void FixedUpdate()
    {

        if (_isGrounded) // Ground movement
            _rb.AddForce(_moveDirection * _moveForce, ForceMode.Acceleration);
        else
        {
            // Player gravity
            _rb.AddForce(transform.up * -1 * _gravity, ForceMode.Acceleration);

            _rb.AddForce(_moveDirection * _moveForce * _moveForceAirScale * 1f, ForceMode.Acceleration);
        }
    }
}
