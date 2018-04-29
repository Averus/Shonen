using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Defence : Ability, IBeingComponent {
    public Defence(GameObject parentObject, string name, float reflex, CombatStates stateThisRunsIn, bool active) : base(parentObject, name, stateThisRunsIn, active)
    {
        this.parentObject = parentObject;
        this.abilityName = name;
        this.reflex = reflex;
        this.runsInState = stateThisRunsIn;
        this.activeAbility = active;

    }

    public float reflex;

}
