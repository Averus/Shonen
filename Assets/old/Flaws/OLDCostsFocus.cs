using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OLDCostsFocus : IFlaw, IBeingComponent
{
    public GameObject parentObject { get; set; }

    public string flawName { get; set; }

    public int focusCost { get; set; }


    // Use this for initialization
    void Start () {
		
	}

public bool CanThisBeUsed()
{

        {
            return false;
        }

}


// Update is called once per frame
void Update () {
		
	}
}
