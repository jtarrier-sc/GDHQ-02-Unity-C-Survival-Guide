using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // C# basic data types (examples)
    public int score;
    public float speed = 5.5f; // the 'f' suffix is required

    // Unity data types (examples)
    public GameObject player;
    public Animator anim;
    public Transform myTransform; // value assigned by dragging & dropping 'Main Camera' Transform in Unity editor

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Main camera 'Transform' settings:");
        Debug.Log("x = " + myTransform.position.x);
        Debug.Log("y = " + myTransform.position.y);
        Debug.Log("z = " + myTransform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
