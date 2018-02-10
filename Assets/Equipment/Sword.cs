using UnityEngine;
using System.Collections;
using System;

public class Sword : IEquipment, IBeingComponent
{
    public GameObject parentObject { get; set; }
    public string equipmentName { get; set; }
    public int equipmentValue { get; set; }


    public void equipEffect()
    {
        
    }

    public void unequipEffect()
    {
       
    }

    public Sword(GameObject parentObject, String name, int equipmentValue)
    {
        this.parentObject = parentObject;
        this.equipmentName = name;
        this.equipmentValue = equipmentValue;
    }
}
