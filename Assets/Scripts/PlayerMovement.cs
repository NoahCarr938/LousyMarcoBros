using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private bool _player = true;

    [SerializeField]
    private float _acceleration = 5.0f;

    [SerializeField]
    private float _maxSpeed = 10.0f;

    [SerializeField]
    private float _jumpPower = 5.0f;

    private Rigidbody _rigidBody;
    private float _movementInput;
    public float GetMaxSpeed{ get { return _maxSpeed; } }

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_player)
        {
            // Storing input for the horizontal axis into a movement variable
            _movementInput = Input.GetAxisRaw("PlayerHorizontal");
            if (Input.GetKeyDown(KeyCode.W))
                Jump();

            if (Input.GetKeyDown(KeyCode.S))
                Fall();
        }
    }

    void FixedUpdate()
    {
        Vector3 deltaMovement = new Vector3();
        deltaMovement.x = _movementInput * _acceleration;

        // Getting the rigidbody component and adding force

        // Class Time is static and is used to access deltaTime or in this case fixedDeltaTime
        _rigidBody.AddForce(deltaMovement * Time.fixedDeltaTime, ForceMode.VelocityChange);

        // Clamp the velocity
        Vector3 newVelocity = _rigidBody.velocity;
        newVelocity.x = Mathf.Clamp(newVelocity.x, -_maxSpeed, _maxSpeed);
        _rigidBody.velocity = newVelocity;
    }

    void Jump()
    {
        // Impuluse only happens once so there is no need for deltaTime
        _rigidBody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
    }

    void Fall()
    {
        _rigidBody.AddForce(Vector3.down * _jumpPower, ForceMode.Impulse);
    }

}
