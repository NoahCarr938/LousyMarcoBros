using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlock : MonoBehaviour
{
    public int value;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        PlayerScore.instance.CollectCoins(value);
    }
}
