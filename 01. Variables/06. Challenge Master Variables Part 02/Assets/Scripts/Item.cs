using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    /// <summary>
    /// Every item has:
    ///     a name
    ///     a description
    ///     an image icon
    ///     an attack strength
    /// </summary>

    public string itemName = "";
    public string itemDescription = "";
    public Sprite itemImageIcon;
    public float itemAttackStrength = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Item name: " + itemName);
        Debug.Log("Item description: " + itemDescription);
        Debug.Log("Item image icon: " + itemImageIcon);
        Debug.Log("Item attack strength: " + itemAttackStrength);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
