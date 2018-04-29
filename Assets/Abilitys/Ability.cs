using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Ability: IBeingComponent
{
    public TextController textController;

    public GameObject parentObject { get; set; }

    public string abilityName = "BLANK ABILITY";

    public CombatStates runsInState;

    public bool activeAbility; //Is this ability Active or Passive? Active abilities fire their effects when they're selected, passive abilities fire whenever their conditions are fulfilled regardless of being selected by the player

    public bool selected = false; //this is set to true if its being used. EDIT I dont know if this is used atm
    public bool available = false; //this is set to true if all the component checks return true. EDIT I dont know if this is used atm

    public int toHit = 0;
    public int range = 0;
    public int ranks = 0; //how practiced the character is with this skill

    public int numberOfTargets = 0; //number of targets
    //public enum RelatedMod { STR, DEX, CON, INT, WIS, CHA };

    public List<IAbilityComponent> AbilityComponents = new List<IAbilityComponent>(); //effects/flaws/costs (all called ability components now)
    public List<ITarget> Targets = new List<ITarget>(); //Lists all valid targets (self, just enemies, just dragons or water types etc)



    public bool CanThisBeUsed()                      //Checks to see if conditions are OK to use this ability
    {
        if (AbilityComponents.Count <= 0)
        {
          return true; 
        }

        for (int i = 0; i < AbilityComponents.Count; i++)
        {
            if (AbilityComponents[i].CanThisBeUsed() == false)   //Each flaw has a CanThisBeUsed method that tests the current gamestate against some condition and returns true or false.
            {
                return false;                        //If a single flaw in this abilitys list of flaws fails a check this method will return false, else true.
            }
                                                     //Each flaw has a CanThisBeUsed method that tests the current gamestate against some condition and returns true or false.

        }                                            //If a single flaw in this abilitys list of flaws fails a check this method will return false, else true.
  
        return true;
    }

    public List<Being> GetPossibleTargets(List<Being> combatants)
    {
        List<Being> validTargets = new List<Being>();


        if (Targets.Count == 0)
        {
            textController.Print("" + abilityName + " has no Target list! (This shouldn't be the case!)");
            return validTargets;
        }

        for(int i = 0; i < combatants.Count; i++)                     //For each combatant in the fight...
        {
            for(int ii = 0; ii < Targets.Count; ii++)                 //check them against each Target rule this ability has (The target rules are stored in the 'Targets' list)
            {
                if (Targets[ii].CanThisBeTargeted(combatants[i]))     // Each Target rule can evaluate whether a given Being can be targeted...
                {
                    validTargets.Add(combatants[i]);                  //If even one of the Target rules returns 'true' then that combatant is added to the temporary list of validTargets, to be returned.

                }
            }
        }

        return validTargets;
    }





    public void Use()
    {
        //Runs through effects, calcs tohit
        textController.Print("Used " + abilityName);
        for(int i = 0; i < numberOfTargets; i++)
        {
           // Effects
        }
    }
   

    public Ability(GameObject parentObject, string name, CombatStates stateThisRunsIn, bool active) //Constructor
    {
        this.parentObject = parentObject;
        abilityName = name;
        activeAbility = active;

    }


    // Use this for initialization

    public void Awake() {

        textController = GameObject.Find("TextControllerObject").GetComponent<TextController>();

      

    }
	

}
