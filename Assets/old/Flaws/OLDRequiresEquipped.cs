using UnityEngine;
using System.Collections;

[System.Serializable]
public class OLDRequiresEquipped : IFlaw, IBeingComponent {

    //This flaw is for abilities that require a given piece of equipment to be equipped on the character. The equipment is designted by the equipment value set in the constructor. 
    //Each piece of equipment will have its own value. The method CanThisBeUsed, will check the body locations of the parent character for the item in question and return true or false.


    GameObject textControllerObj;

    public GameObject parentObject { get; set; }
    public string flawName { get; set; }

    public int equipmentVal { get; set; }


    public bool CanThisBeUsed()
    {       
         
        for (int i = 0; i < parentObject.GetComponent<Being>().bodyLocations.Count; i++)                          //Vegin cycling through the parent Beings body locations    
        {
           
            if (parentObject.GetComponent<Being>().bodyLocations[i].equipment != null)                            //If the body location has some equipment in it
            {
                if (parentObject.GetComponent<Being>().bodyLocations[i].equipment.equipmentValue == equipmentVal) //If the equipment in the body location is the same as the requires equipment
                {
                //    textControllerObj.GetComponent<TextController>().Print("ability can be used");                //return true
                    return true;
                }

                
            }

         //   textControllerObj.GetComponent<TextController>().Print(parentObject.GetComponent<Being>().beingName + " has no equipment on their " + parentObject.GetComponent<Being>().BodyLocations[i].bodyLocationName);

        }
        textControllerObj.GetComponent<TextController>().Print("ability cannot be used. " + flawName);
        return false; 
    }

    public OLDRequiresEquipped(GameObject parentObject, string name, int equipmentValue)
    {
        this.parentObject = parentObject;
        this.flawName = name;
        this.equipmentVal = equipmentValue;
       
    }

    public void Awake()
    {

        textControllerObj = GameObject.Find("TextControllerObject");

    }
}
