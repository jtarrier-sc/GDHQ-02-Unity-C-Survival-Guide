﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	/// <summary>
	/// To create variables there are 3 required components with an optional 4th:
	/// 1. public or private reference ("Who can access this information?")
	/// 	public = everyone can access the variable, can be seen and manipulated in the Unity editor
	/// 	private = only this script has control of the variable.
	/// 2. data type ("What kind of variable is this?")
	/// 	3 common types:
	///			string (characters of text e.g. a name, a sentence)
	///			bool (logical true or false)
	///			float (decimal number)
	///			int (whole number)
	///	3. name
	/// 4. value (optional)
	/// </summary>
	
	
	// variable for my name
	public string myName = "Jeremy";
	
	// variable for my age
	public int myAge = 57;
	
	// variable for my location
	public string myLocation = "Singapore";
	
	// variable for whether or not player has obtained a key
	public bool hasKey = false;
	
	
    // Start is called before the first frame update
    void Start()
    {
        // Print out variables to the Unity Console
		Debug.Log("My name is: " + myName);
		Debug.Log("My age is: " + myAge);
		Debug.Log("My location is: " + myLocation);
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
