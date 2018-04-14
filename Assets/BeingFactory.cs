using UnityEngine;
using System.Collections;

public class BeingFactory {

	
    
    
    
    public GameObject GetHuman(string name)
    {
        GameObject gameObject = new GameObject(name);
        gameObject.AddComponent<Being>();
       

        gameObject.GetComponent<Being>().beingName = name;

        gameObject.GetComponent<Being>().race = "Human";

        gameObject.GetComponent<Being>().HP = 100;
        gameObject.GetComponent<Being>().RandomStats();

        gameObject.GetComponent<Being>().bodyLocations.Add(new BodyLocation(gameObject, "head"));
        gameObject.GetComponent<Being>().bodyLocations.Add(new BodyLocation(gameObject, "torso"));
        gameObject.GetComponent<Being>().bodyLocations.Add(new BodyLocation(gameObject, "left hand"));
        gameObject.GetComponent<Being>().bodyLocations.Add(new BodyLocation(gameObject, "right hand"));
        gameObject.GetComponent<Being>().bodyLocations.Add(new BodyLocation(gameObject, "legs"));
        gameObject.GetComponent<Being>().bodyLocations.Add(new BodyLocation(gameObject, "feet"));

        Resource focus = new Resource(gameObject, "Focus", 20);
        gameObject.GetComponent<Being>().resources.Add(focus);

        Ability punch = new Ability(gameObject, "Punch", CombatStates.CALCULATEDAMAGE, true);
        punch.Awake();
        punch.numberOfTargets = 1;
        Cost costsFocus = new Cost(gameObject, "costsFocus", focus, 3);
        Enemies enemies = new Enemies(gameObject, "Enemies");
        enemies.Awake();
        punch.Targets.Add(enemies);
        Self self2 = new Self(gameObject, "Self");
        self2.Awake();
        punch.Targets.Add(self2);

        

        Ability demonSlash = new Ability(gameObject, "Demon Slash", CombatStates.CALCULATEDAMAGE, true);
        demonSlash.Awake();
        demonSlash.numberOfTargets = 1;
        RequiresEquipped requiresSword = new RequiresEquipped(gameObject, "Requires Sword", 1);
        demonSlash.AbilityComponents.Add(requiresSword);
        requiresSword.Awake(); //This line is only here because of the null reference bug I'm getting, I think requires sword needs the Text object reference early.
        Enemies enemies2 = new Enemies(gameObject, "Enemies");
        enemies2.Awake();
        demonSlash.Targets.Add(enemies2);

        Ability kick = new Ability(gameObject, "Kick Barrage", CombatStates.CALCULATEDAMAGE, true);
        kick.Awake();
        kick.numberOfTargets = 4;
        Enemies enemies3 = new Enemies(gameObject, "Enemies");
        enemies3.Awake();
        kick.Targets.Add(enemies3);

        Ability heal= new Ability(gameObject, "Heal", CombatStates.CALCULATEDAMAGE, true);
        heal.Awake();
        heal.numberOfTargets = 1;
        Self self = new Self(gameObject, "Self");
        self.Awake();
        heal.Targets.Add(self);




        gameObject.GetComponent<Being>().abilities.Add(punch);
        gameObject.GetComponent<Being>().abilities.Add(demonSlash);
        gameObject.GetComponent<Being>().abilities.Add(kick);
        gameObject.GetComponent<Being>().abilities.Add(heal);

       // RequiresEquipped requiresStaff = new RequiresEquipped(gameObject, "Requires Staff", 100);
       //  heal.Flaws.Add(requiresStaff);
       // requiresStaff.Awake();

        Sword sword = new Sword(gameObject, "Bronze Sword", 1);
        gameObject.GetComponent<Being>().Equip(sword, "right hand");







        


        return gameObject;
        
    }
    
 
    
    
    
    
    
    
    
    
    
    
    
    // Use this for initialization
	void Start () {
     

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
