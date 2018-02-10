using UnityEngine;
using System.Collections;
using System;

public class Damage : IEffect, IBeingComponent
{
    GameObject textControllerObj; //so we can send messages to the text field

    public GameObject parentObject { get; set; }
    public string effectName { get; set; }

    int damage;

    public void Use()
    {

    }
    

    public Damage(GameObject parentObject, string name)
    {
        this.parentObject = parentObject;
        this.effectName = name;
    }

    
}

