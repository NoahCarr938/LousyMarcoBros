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
    private void Update()
    {
        // Move right animation
        if (Input.GetKeyDown(_keyRight))
        {
            if (TryGetComponent(out Animator anim))
                anim.SetTrigger("RunTrigger");
        }
        // Move left animation, currently the same animation as move right
        if (Input.GetKeyDown(_keyLeft))
        {
            if (TryGetComponent(out Animator anim))
                anim.SetTrigger("RunTrigger");
        }

        // Stop move right animation
        if (!Input.GetKeyDown(_keyRight))
        {
            if (TryGetComponent(out Animator anim))
                anim.SetTrigger("IdleTrigger");
        }

        // Stop move left animation
        if (!Input.GetKeyDown(_keyLeft))
        {
            if (TryGetComponent(out Animator anim))
                anim.SetTrigger("IdleTrigger");
        }
    }
}
