using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    // Making an array to hold all of the game objects
    public GameObject[] objects;

    private void Start()
    {
        // Getting a random object between 0 and the number of objects we have in the array
        int rand = Random.Range(0, objects.Length);
        // Instantiate a random object at a spawn point.
        // Quaternion.identity means that you would like the object to have no rotation
        Instantiate(objects[rand], transform.position, Quaternion.identity);
    }
}
