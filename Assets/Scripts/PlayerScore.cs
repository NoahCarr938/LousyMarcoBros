using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private GameObject _coin;

    [SerializeField]
    private int _coinsToWin;

    private int _currentcoins = 0;
    private Rigidbody _rigidBody;
    private CapsuleCollider _capsuleCollider;
    private void Start()
    {
        // If the amount of coins to win the game is 0 then the game is won
        if (_coinsToWin == 0)
            return;
    }

    private void Update()
    {
       
    }
}
