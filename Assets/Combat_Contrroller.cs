﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;


public enum CombatStates
{
    INITIATIVESORT, MAINLOOP, PLAYERTURN, LISTABILITIES, SELECTABILITIES, LISTTARGETS, SELECTTARGETS, NPCTURN, WIN, LOSE,
    CALCULATETOHIT,
    CALCULATETOHITDEFENCE,
    CALCULATEDAMAGE,
    CALCULATEDAMAGEDEFENCE
}


[System.Serializable]
public class CombatController : MonoBehaviour
{

    // Use this for initialization

    InputField userInput;

    public GameObject textControllerObj;

    static System.Random rng = new System.Random();

    public int turn = 0;

    public List<Being> combatants = new List<Being>(); //All the Beings in combat

    public List<Being> validTargets = new List<Being>(); //A temporary holder for beings targeted by an ability

    public List<Being> selectedTargets = new List<Being>(); //

    public List<Ability> availableAbilities = new List<Ability>(); //A holder for a list of abilities avaliable at a given time

 

    public int playerSelectedAbility; //the number of the element in the avaliable abilities list that player has selected

    public bool playerHasSelectedAbility = false; //has the player selected an ability to use?

    public bool playerHasSelectedTargets = false; //has the player selected all the targets for the selected ability?

    public int currentElement = 0;

    public int playerControlledCombatantElement;

    public CombatStates currentState;

    public string userInputString;




    public void NextTurn()
    {
       if (currentElement < combatants.Count)
         {
            if (combatants[currentElement].GetComponent<Being>().condition == Being.Condition.normal) //check if the next Being in the initiative order is not unconcious, asleep etc
            {
                if (combatants[currentElement].GetComponent<Being>().playerControlled == true)
                {

                    currentState = CombatStates.PLAYERTURN;

                }
                else
                {
                    currentState = CombatStates.NPCTURN;
                }
            }

         }
        else
        {
            Print("Everyone has gone");
        }   

    }

    public void PlayerTurn() //If You ever have the option to do anything but use abilities, this is where they'll be listed
    {
        Print(combatants[currentElement].GetComponent<Being>().beingName + "'s [PLAYER] turn " + combatants[currentElement].GetComponent<Being>().initiative);

        currentState = CombatStates.LISTABILITIES;
  
    }


    public void GetAbilities(bool active){
        Print ("Getting abilities");
        availableAbilities = combatants[currentElement].GetComponent<Being>().GetAvaliableAbilities(true);
    }


    public void ListAbilities()
    {
        Print("Please select ability");

        if (availableAbilities.Count != 0)
        {
            for (int i = 0; i < availableAbilities.Count; i++) // list the playable characters abilities that are avaliable to use
            {
                Print("" + (i + 1) + ". " + availableAbilities[i].abilityName);
            }
        }
    }

    public void ListTargets()
    {

        Ability ability = availableAbilities[playerSelectedAbility];

        Print("Please select targets for " + availableAbilities[playerSelectedAbility].abilityName);
        
        validTargets = ability.GetPossibleTargets(combatants);

        if(validTargets.Count == 0)
        {
            Print(ability.abilityName + " has no valid targets at this time!");
            currentState = CombatStates.LISTABILITIES;
        }
        else for (int i = 0; i < validTargets.Count; i++)
            {
                Print("" + (i + 1) + ". " + validTargets[i].beingName);
                currentState = CombatStates.SELECTTARGETS;
            }
          
    }

    public void NPCTurn()
    {
        Print(combatants[currentElement].GetComponent<Being>().beingName + " just stands around like a dopey shit. " + combatants[currentElement].GetComponent<Being>().initiative);
        turn++; //Increment the turn counter
        currentElement++;
        currentState = CombatStates.MAINLOOP;
    }

    public void SortByInitiative()
    {

        List<Being> temp = new List<Being>();
        int highestinit = combatants[0].GetComponent<Being>().initiative;
        int highestintindex = 0;

        while (combatants.Count > 0)
        {
            
            for (int i = 0; i < combatants.Count; i++)
            {

                if (combatants[i].GetComponent<Being>().initiative >= highestinit)
                {
                    highestinit = combatants[i].GetComponent<Being>().initiative;
                    highestintindex = i;
                }

            }

            temp.Add(combatants[highestintindex]);
            combatants.Remove(combatants[highestintindex]);
            highestinit = 0;

        }
        for (int i = 0; i < temp.Count; i++)
        {
            combatants.Add(temp[i]);
        }
        temp.Clear();
    }

    public string GetUserString()
    {
        string s;

        if (userInputString != null)
        {
            s = userInputString;
            userInputString = null;
            return s;
        }
        else
        {
            return userInputString;
        }

    }

    public void checkForRelevantpassiveAbilities() //I think this checks within the current combatstate
    {
        for (int i = 0; i < combatants.Count; i++)
        {
            availableAbilities = combatants[i].GetComponent<Being>().GetAvaliableAbilities(false); //false because it's looking for passive abilities not active ones

            if (availableAbilities.Count == 0)
            {
                Print(combatants[i].beingName + "has no relevant passive abilities");
                break;
            }
            for (int ii = 0; ii < availableAbilities.Count; ii++)
            {
                Print("Using " + availableAbilities[ii].abilityName); //availableAbilities[ii].Use(); //Here it's using a passive ability so it needs a gambit style setup from which it gets its behaviour (behaviour of abilities that arent player controlled)
                //this Use needs to be a separate method, sroting relevant abilities in an array and then using them in order like, buffs-->damage-->healing etc
            }
        
        }

    }

    public void PlayerSelectsAbility()
    {
        //clear playerSelectedAbility first?

        if (userInputString != null)
        {
            string userStr = GetUserString();
            int number;

            if (int.TryParse(userStr, out number))
            {
                if (number <= availableAbilities.Count && number > 0)
                {
                    playerSelectedAbility = (number - 1);
                    currentState = CombatStates.LISTTARGETS;
                }
                else
                {
                    Print("Out of range!");
                    currentState = CombatStates.LISTABILITIES;
                }
            }
            else
            {
                Print("Please enter the number corrisponding to the desired ability.");
                currentState = CombatStates.LISTABILITIES;   
            }
            
        }
        
    }

    public void PlayerSelectsTargets() //needs to include range and area effects etc. targets need to be single, multiple, area etc
    {
        
        //wipe the list of selected targets first?
        if (selectedTargets.Count == availableAbilities[playerSelectedAbility].numberOfTargets)
        {
            //UseAbility(avaliableAbilities[playerSelectedAbility]);
            Print("Using " + availableAbilities[playerSelectedAbility].abilityName);
            CalculateToHit(combatants[currentElement], availableAbilities[playerSelectedAbility], selectedTargets);

        }

        if (userInputString != null)
        {
            string userStr = GetUserString();
            int number;

            if (int.TryParse(userStr, out number))
            {
                if (number <= validTargets.Count && number > 0)
                {
                    selectedTargets.Add(validTargets[(number - 1)]);
                    Print("" + validTargets[(number - 1)].beingName + " selected as a target for " + availableAbilities[playerSelectedAbility].abilityName + ". " + (availableAbilities[playerSelectedAbility].numberOfTargets - selectedTargets.Count) + " left to select.");
                    
                }
                else
                {
                    Print("Out of range!");
                    
                }

            }
            else
            {
                Print("Please enter the number corrisponding to the desired target.");
                currentState = CombatStates.LISTTARGETS;
            }

        }

    }

    private void CalculateToHit(Being attacker, Ability ability, List<Being> targets)
    {
        currentState = CombatStates.CALCULATETOHIT; //set the right state

        //Get the toHit value...

        float dex = (float)combatants[currentElement].GetComponent<Being>().DEX;
        int random = rng.Next(1, 101);
        float toHit = combatants[currentElement].GetComponent<Being>().powerLevel + ((dex / 100) * ability.ranks) + random;

        Print(attacker.powerLevel + " + (" + (dex / 100) + " * " + ability.ranks + ") + " + random + " = " + toHit);

        Print("Calculating to hit...");
        Print("To Hit value is " + toHit);

        //does anyone have any passive abilities that work now? This that modulate the tohit value for these guys
        checkForRelevantpassiveAbilities();

        CalculateToHitDefence(attacker, ability, targets, toHit);

    }

    private void CalculateToHitDefence(Being attacker, Ability ability, List<Being> targets, float toHit)
    {
        currentState = CombatStates.CALCULATETOHITDEFENCE;

        for (int i = 0; i < targets.Count; i++)
        {
            if(targets[i].mentalReflex < toHit)
            {
                checkForRelevantpassiveAbilities();
                Print("Sorting defences...");
                targets[i].sortDefences();

                if (targets[i].defences[0].reflex >= toHit)
                {
                    targets[i].defences[0].Use();
                }
                else
                {
                    Print(targets[i].beingName + ": Shit, I can't move fast enough!");
                }

               
            }
            else
            {
                //you get a choice of action including attacks, defences, everything.
                currentState = CombatStates.PLAYERTURN;
            }

        }
        /*
calc tohitdefence(float tohit)

is tohit above your concious notice (mental reflex?)
if yes
	do you have any passive defences that can take something of that speed?
	if yes
	The first one fires
	if no
	"shit I can't move fast enough!"

if no
	you get a choice of action including attacks, defences, everything.

*/





    }

    private void Print(string str)
    {
        textControllerObj.GetComponent<TextController>().Print(str);
    }

    void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Return) && userInput.text != string.Empty) //The player must press enter to enter the string
        {
            userInputString = userInput.text;
            userInput.text = null;
        }
    }

    void Awake () {

        userInput = GameObject.Find("Canvas").GetComponentInChildren<InputField>();

        textControllerObj = GameObject.Find("TextControllerObject");

        currentState = CombatStates.INITIATIVESORT;

    }
	
	// Update is called once per frame
	void Update () {

        switch (currentState)
        {
            case (CombatStates.INITIATIVESORT):
                SortByInitiative();
                checkForRelevantpassiveAbilities();
                currentState = CombatStates.MAINLOOP;
                break;


            case (CombatStates.MAINLOOP):
                NextTurn();
                break;


            case (CombatStates.PLAYERTURN):
                PlayerTurn();
                break;

            case (CombatStates.LISTABILITIES):
                GetAbilities(true);
                ListAbilities();
                currentState = CombatStates.SELECTABILITIES;
                break;

            case (CombatStates.SELECTABILITIES):
                PlayerSelectsAbility();
                break;

            case (CombatStates.LISTTARGETS):
                ListTargets();
                currentState = CombatStates.SELECTTARGETS;
                break;

            case (CombatStates.SELECTTARGETS):
                PlayerSelectsTargets();
                break;

            case (CombatStates.CALCULATETOHIT):
                
                break;


            case (CombatStates.CALCULATETOHITDEFENCE):
                
                break;


            case (CombatStates.CALCULATEDAMAGE):
                
                break;


            case (CombatStates.CALCULATEDAMAGEDEFENCE):
               
                break;

            case (CombatStates.NPCTURN):
                NPCTurn();
                break;


            case (CombatStates.WIN):
                break;


            case (CombatStates.LOSE):
                break;


        }


	}


}


