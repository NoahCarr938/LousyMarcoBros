using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTrigger : MonoBehaviour
{
    // Movement right
    [SerializeField]
    private KeyCode _keyRight = KeyCode.D;
    // Movement Left
    [SerializeField]
    private KeyCode _keyLeft = KeyCode.A;

    //private SpriteRenderer _spriteRenderer;
    //private float _horizontalInput;
    //private bool _faceingRight;

    private void Update()
    {
        //_horizontalInput = Input.GetAxisRaw("PlayerHorizontal");
        //SetDirection();

        // Move right animation
        if (Input.GetKeyDown(_keyRight))
        {
            //_horizontalInput--;
            if (TryGetComponent(out Animator anim))
                anim.SetTrigger("RunTrigger");
        }
        // Move left animation, currently the same animation as move right
        if (Input.GetKeyDown(_keyLeft))
        {
            //_horizontalInput++;
            if (TryGetComponent(out Animator anim))
                anim.SetTrigger("RunTrigger");
        }
    }

    //private void SetDirection()
    //{
    //    if (_horizontalInput < 0)
    //        _spriteRenderer.flipX = true;
    //    else if (_horizontalInput > 0)
    //        _spriteRenderer.flipX = false;
    //}
}
