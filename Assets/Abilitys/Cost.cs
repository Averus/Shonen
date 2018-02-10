using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cost: IAbilityComponent, IBeingComponent
{
    public string abilityComponentName { get; set; }

    public GameObject parentObject { get; set; }

    Resource resource { get; set; } //What resource this cost is attached too

    int cost { get; set; } //how much the cost is

    public bool CanThisBeUsed()
    {
        return true;
    }

    public void Use()
    {
        resource.resourceValue -= cost;
    }

    public Cost (GameObject parentObject, string costName, Resource resource, int cost)
    {
        parentObject = this.parentObject;
        costName = this.abilityComponentName;
        resource = this.resource;
        cost = this.cost;

    }
}
