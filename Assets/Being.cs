using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class Being : MonoBehaviour
{
    GameObject textControllerObj;//The text controller object, might be changed later if I write a better one.

    //is this Being player controlled? ------ later need to add a different AI's to equip
    public bool playerControlled = false;

    //beings name
    public string beingName = "Unknown";

    //beings race
    public string race = "Unknown";

    //power level ---will probably have equpable extras later like ki, riatsu etc
    public int powerLevel;


    public int HP;
    public int reflex;
    public int initiative;
    public int Maxfocus = 20; //Attention used up when using an ability, can be spent to increase ability chance of hitting

    //core stats
    public int STR;
    public int DEX;
    public int CON;
    public int INT;
    public int WIS;
    public int CHA;

    //core stat mods
    public int STRmod;
    public int DEXmod;
    public int CONmod;
    public int INTmod;
    public int WISmod;
    public int CHAmod;

    //fighting style bonus ----------this should be currently equipped fighing style bonus
    public int FightingStyleBonus;

    //normal, dazed, staggared, unconcious, dead etc
    public enum Condition{ normal, dazed, staggered, unconcious };
    public Condition condition = Condition.normal;

    

    //abilities lists all abilities of this Being
    public List<Ability> abilities = new List<Ability>();

    //resources lists all resources this Being has
    public List<Resource> resources = new List<Resource>();

    //defences lists all defences of this Being
    public List<IDefence> defences = new List<IDefence>();

    //Equipped lists BodyLocations (head, right hand, legs etc) which can have IEquippable objects put in them
    public List<BodyLocation> bodyLocations = new List<BodyLocation>();


    public Being()
    {

    }

    private int getMod(int stat)
    {
        stat -= 10;
        stat /= 2;
        return stat;
    }

    private void CalculateMods()
    {
        STRmod = getMod(STR);
        DEXmod = getMod(DEX);
        CONmod = getMod(CON);
        INTmod = getMod(INT);
        WISmod = getMod(WIS);
        CHAmod = getMod(CHA);
    }

    public void RandomStats()
    {
        STR = Dice.RollStat();
        DEX = Dice.RollStat();
        CON = Dice.RollStat();
        INT = Dice.RollStat();
        WIS = Dice.RollStat();
        CHA = Dice.RollStat();

        CalculateMods();
    }

    public List<Ability> GetAvaliableAbilities(bool active)
    {

        int abilityCounter = 0;
        List<Ability> abList = new List<Ability>();

        if (abilities.Count == 0)
        {
            Print("No Abilities! (this must be wrong, the Being should at least have a basic attack)");
        }

        for (int i = 0; i < abilities.Count; i++)
        {
            if ((abilities[i].activeAbility == active) && (abilities[i].CanThisBeUsed()))
            {
                abilityCounter++;
                abList.Add(abilities[i]);
               // Print(abilityCounter + ". " + abilities[i].abilityName);
            }
           
        }
        return abList;
    } //Returns a list of the beings abilities that can be used

    public void GetBodyLocations()
    {
        for (int i = 0; i < bodyLocations.Count; i++)
        {
            if (bodyLocations[i].equipment == null)
            {
                Print(bodyLocations[i].bodyLocationName + " which is empty");
            }
            else
            {
                Print(bodyLocations[i].bodyLocationName + " contains " + bodyLocations[i].equipment.equipmentName);
            }
            
        }
    } //this ones kind of testcrappy but might be useful enough to keep

    public void UseAbility()
    {
	    for (int i = 0;  i< abilities.Count; i++)
	    {
		    if (abilities[i].selected)
		{
			//abilities[i].Use();
			abilities[i].selected = false;
		}
	}
	
}

    public void Equip(IEquipment equipment, string bodyLocationName)
    {
        for (int i = 0; i < bodyLocations.Count; i++)
        {
            if (bodyLocations[i].bodyLocationName == bodyLocationName)
            {
                if (bodyLocations[i].equipment != null)
                {
                    Print(beingName + " removes the " + bodyLocations[i].equipment.equipmentName + " from their " + bodyLocationName);
                    UnEquip(bodyLocationName);
                }

                Print(beingName + " puts the " + equipment.equipmentName + " on their " + bodyLocationName);
                bodyLocations[i].equipment = equipment; //In the future this will have to be a string equipmentName looked up from an equipment database
               // Print(beingName + " Equipped " + BodyLocations[i].equipment.equipmentName + " which has a value of " + BodyLocations[i].GetEquipmentValue()); //testcrap line
              //  ListBodyLocations(); //testcrap
                equipment.equipEffect(); //This does whatever the equipment 'does' when equipped, like buff stats or give the character a new ability. This is defined in each equipment.
                break;
            }

            if (i == bodyLocations.Count - 1)
            {
                Print(beingName + " does not have a " + bodyLocationName + "!");
            }
       
        }
        
    }

    public void UnEquip(string bodyLocationName) //Will need a version of this for just an item of equipment too
    {
        for (int i = 0; i < bodyLocations.Count; i++)
        {
            if (bodyLocations[i].bodyLocationName == bodyLocationName)
            {
                if (bodyLocations[i].equipment == null)
                {
                    Print(beingName + " does not have anything to remove from their " + bodyLocationName);
                }
                else
                {
                    bodyLocations[i].equipment.unequipEffect(); //'undo' whatever effect was being done by the equipment
                    bodyLocations[i].equipment = null;
                }
            }
            else
            {
                Print(beingName + " does not have a " + bodyLocationName + "!");
            }
        }
    } 

    private void Print(string str)
    {
        //   textControllerObj = GameObject.Find("TextControllerObject");
        textControllerObj.GetComponent<TextController>().Print(str);
    }

    // Use this for initialization
    void Awake ()
    {
        textControllerObj = GameObject.Find("TextControllerObject");
        RandomStats();
        initiative = Dice.RollStat();
    }
	
	// Update is called once per frame
	void Update () {

      

    }
}
