using UnityEngine;
using System.Collections;

[System.Serializable]
public class BodyLocation : IBeingComponent {

    public GameObject parentObject { get; set; }

    public string bodyLocationName;

    public IEquipment equipment;

    public int GetEquipmentValue()
    {
        if (equipment == null)
        {
            Debug.Log(parentObject.GetComponent<Being>().beingName + " " + bodyLocationName + " no equipment here");
            return 0;
        }
        else
        {
            Debug.Log(bodyLocationName + " equipment value " + equipment.equipmentValue);
            return equipment.equipmentValue;
        
        }
    }

    public BodyLocation(GameObject parentObject, string bodyPartName)
    {
        this.parentObject = parentObject;
        bodyLocationName = bodyPartName;
    }

    public BodyLocation()
    {

    }


}
