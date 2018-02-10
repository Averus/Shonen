using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Main : MonoBehaviour {


    //In the future the save/load and character select and creation things will go before this step

    //probably need to create a Being prefab and instantiate that instead

    //public Text outputText;

   public GameObject textControllerObj;

    void Start()
    {

        //First need to check if a Main already exists, also theres something you can do to make things persist through scene changes. 
        //In the future the save/load and character select and creation things will go before this step
        //Right now we're just setting up a fight

        // T

        //Get the static TextControllerObject to do our text displaying
        textControllerObj = GameObject.Find("TextControllerObject");

        textControllerObj.GetComponent<TextController>().Print("Main starting...");

        //create a gameobject to be the combat controller
        GameObject combatController = new GameObject("Combat Controller");
        combatController.AddComponent<CombatController>();

        BeingFactory beingFactory = new BeingFactory();

        GameObject playerAvatar = beingFactory.GetHuman("Turel");
        playerAvatar.GetComponent<Being>().playerControlled = true;

        GameObject goon1 = beingFactory.GetHuman("Quux");
        GameObject goon2 = beingFactory.GetHuman("Bazz");
        GameObject goon3 = beingFactory.GetHuman("Larry");
        GameObject goon4 = beingFactory.GetHuman("Carp");

        combatController.GetComponent<CombatController>().combatants.Add(playerAvatar.GetComponent<Being>());
        combatController.GetComponent<CombatController>().combatants.Add(goon1.GetComponent<Being>());
            combatController.GetComponent<CombatController>().combatants.Add(goon2.GetComponent<Being>());
                combatController.GetComponent<CombatController>().combatants.Add(goon3.GetComponent<Being>());
                    combatController.GetComponent<CombatController>().combatants.Add(goon4.GetComponent<Being>());


        /*

        GameObject playerAvatar = new GameObject("Turel");
        playerAvatar.AddComponent<Human>();
      

        //marks the playerAvatar as being player controlled
        playerAvatar.GetComponent<Being>().playerControlled = true;

        //name the players Avatar
        playerAvatar.GetComponent<Being>().beingName = "Turel"; //this would already be set by the name thing at the start of character generation
        

  

        //make dem goons
        GameObject goon1 = new GameObject("Goon1");
        GameObject goon2 = new GameObject("Goon2");
        GameObject goon3 = new GameObject("Goon3");
        GameObject goon4 = new GameObject("Goon3");
        //make dem goons Beings
        goon1.AddComponent<Being>();
        goon2.AddComponent<Being>();
        goon3.AddComponent<Being>();
        goon4.AddComponent<Being>();
        //Name dem goons
        goon1.GetComponent<Being>().beingName = "Bazz";
        goon2.GetComponent<Being>().beingName = "Carp";
        goon3.GetComponent<Being>().beingName = "Quux";
        goon4.GetComponent<Being>().beingName = "Larry";

        //Put the players avatar and the goons into the list of combatants
        combatController.GetComponent<CombatController>().combatants.Add(playerAvatar);
        combatController.GetComponent<CombatController>().combatants.Add(goon1);
        combatController.GetComponent<CombatController>().combatants.Add(goon2);
        combatController.GetComponent<CombatController>().combatants.Add(goon3);
        combatController.GetComponent<CombatController>().combatants.Add(goon4);

        Ability normalPunch = new Ability("Turel", "punch");
        //normalPunch.abilityName = "Just a normal punch";
        playerAvatar.GetComponent<Being>().abilities.Add(normalPunch);

        Ability RisingPheonixSuperBuster = new Ability();
        RisingPheonixSuperBuster.abilityName = "Fire";
        playerAvatar.GetComponent<Being>().abilities.Add(RisingPheonixSuperBuster);

        Ability BWWDKick = new Ability();
        BWWDKick.abilityName = "Kick";
        playerAvatar.GetComponent<Being>().abilities.Add(BWWDKick);

        //GameObject.FindObjectOfType

        RequiresEquipped requiresSword = new RequiresEquipped("Turel", "Requires Sword", 1);
        normalPunch.Flaws.Add(requiresSword);

        playerAvatar.AddComponent<RequiresEquipped>



        BodyLocation rightHand = new BodyLocation();
        rightHand.bodyLocationName = "right hand";
        playerAvatar.GetComponent<Being>().BodyLocations.Add(rightHand);

        Equipment sword = new Equipment(1);
        sword.equpimentName = "Sword";
        playerAvatar.GetComponent<Being>().Equip(sword, "right hand");

        */

        //combatController.GetComponent<CombatController>().StartCombat();

    }

    // Update is called once per frame
    void Update() {

    }
    
    

}
