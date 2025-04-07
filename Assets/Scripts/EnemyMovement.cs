using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private bool _enemy = true;

    [SerializeField]
    private float _jumpPower = 5.0f;

    [SerializeField]
    private float _acceleration = 5.0f;

    [SerializeField]
    private float _maxSpeed = 10.0f;

    private Rigidbody _rigidBody;

    private float _movementInput;
    public float GetMaxSpeed { get { return _maxSpeed; } }

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
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

        if (_enemy)
        {
            // If the w key is down and the groundcheck is true, jump
            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
            //if (Input.GetKeyDown(KeyCode.S))
            //    Fall();
            if (_rigidBody.position.y >= 16)
                Fall();
            if (_rigidBody.position.y <= 10)
                Jump();
        }
    }

    void Jump()
    {
        // Impuluse only happens once so there is no need for deltaTime
        _rigidBody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
    }

    void Fall()
    {
        // Impulse only happens once so there is no need for deltaTime
        _rigidBody.AddForce(Vector3.down * _jumpPower, ForceMode.Impulse);
    }
}
