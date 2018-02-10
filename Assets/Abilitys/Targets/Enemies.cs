using UnityEngine;
using System.Collections;

public class Enemies : ITarget, IBeingComponent
{
    TextController textController;

    public string targetName { get; set; }
    public GameObject parentObject { get; set; }





    public bool CanThisBeTargeted(Being combatant)
    {
        if (combatant != parentObject.GetComponent<Being>())
        {
            return true;
        }

        return false;
    }




    public Enemies(GameObject parentObject, string name)
    {
        this.parentObject = parentObject;
        this.targetName = name;
    }

    public void Awake()
    {

        textController = GameObject.Find("TextControllerObject").GetComponent<TextController>();

    }
}
