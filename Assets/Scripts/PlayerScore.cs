using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore instance;

    // Displays the text for the current amount of coins
    [SerializeField]
    private TextMeshProUGUI _coinText;

    public int currentCoins = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        _coinText.text = currentCoins.ToString();
    }

    public void CollectCoins(int v)
    {
        currentCoins += v;
    }
   
}
