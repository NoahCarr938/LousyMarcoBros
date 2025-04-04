using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    // Movement right
    [SerializeField]
    private KeyCode _keyRight = KeyCode.D;
    // Movement Left
    [SerializeField]
    private KeyCode _keyLeft = KeyCode.A;

    private void Update()
    {
        if (Input.GetKeyDown(_keyRight))
            _speed += 1;
        if (Input.GetKeyDown(_keyLeft))
            _speed -= 1;
        // If speed is greater than or equal to one move right
        if (_speed >= 1)
            _speed = Input.GetAxisRaw("PlayerHorizontal");

        // If speed is less than or equal to one move left
        if (_speed <= 1)
            _speed = Input.GetAxisRaw("Player1Horizontal");
    }
}
