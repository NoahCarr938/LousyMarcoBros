using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int value;
    private void OnCollisionEnter(Collision collision)
    {
        PlayerLives.instance.LoseLife(value);
    }
}
