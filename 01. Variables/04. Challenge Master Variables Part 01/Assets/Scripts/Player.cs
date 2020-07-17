using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // create a variable to store your name
    public string myName = "";

    // create a variable to store your age
    public int myAge = 0;

    // create a variable to store your speed
    public float mySpeed = 0.0f;

    // create a health variable
    public float health = 0.0f;

    // create a score variable
    public int score = 0;

    // create a speed variable
    public float speed = 0.0f;

    // create a variable to check if all keys were collected
    public bool hasAllKeys = false;

    // create a variable for ammo count
    public int ammoCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        // print out variables with appropriate descriptive text
        Debug.Log("My name is: " + myName);
        Debug.Log("My age is: " + myAge);
        Debug.Log("My speed is: " + mySpeed);
        Debug.Log("Health: " + health);
        Debug.Log("Score: " + score);
        Debug.Log("Has all keys: " + hasAllKeys);
        Debug.Log("Ammo count: " + ammoCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
