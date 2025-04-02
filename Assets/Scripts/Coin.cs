using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        PlayerScore.instance.CollectCoins(value);
    }
}
