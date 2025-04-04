using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public static PlayerLives instance;

    [SerializeField]
    private GameObject _robotExplosionParticles;

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
        SpawnParticles();
    }

    private void SpawnParticles()
    {
        // Guard clause
        if (_robotExplosionParticles)
            return;
        Instantiate(_robotExplosionParticles, gameObject.transform.position, gameObject.transform.rotation);
    }
}
