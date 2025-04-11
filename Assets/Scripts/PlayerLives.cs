using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    //[SerializeField]
    //private GameObject _explosionParticlesPrefab;

    public static PlayerLives instance;

    // The number of lives the player has
    public int currentPlayerLives;

    private void Awake()
    {
        instance = this;
    }

    public void LoseLife(int v)
    {
        currentPlayerLives -= v;
        // When a life is lost display robot explosion particles
        //SpawnExploison();
    }

    //private void SpawnExploison()
    //{
    //    if (!_explosionParticlesPrefab)
    //        return;
    //    Instantiate(_explosionParticlesPrefab, gameObject.transform.position, gameObject.transform.rotation);
    //}
}
