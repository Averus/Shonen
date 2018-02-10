using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resource : IBeingComponent {

    public GameObject parentObject { get; set; }

    public string resourceName = "BLANK ABILITY";

    public int resourceValue = 0;

    public Resource (GameObject parentObject, string resourceName, int resourceValue)
    {
        this.parentObject = parentObject;
        this.resourceName = resourceName;
        this.resourceValue = resourceValue;
    }


}
