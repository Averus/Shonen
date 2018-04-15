using UnityEngine;
using System.Collections;

public class BeingFactory {

	
    
    
    
    public GameObject GetHuman(string name)
    {
        GameObject gameObject = new GameObject(name);
        gameObject.AddComponent<Being>();

        Being being = gameObject.GetComponent<Being>(); //Get a reference to the new Being to avoid multiple GetComponent calls

        being.beingName = name;

        being.race = "Human";

        being.HP = 100;
        being.RandomStats();
        being.powerLevel = 0;

        being.bodyLocations.Add(new BodyLocation(gameObject, "head"));
        being.bodyLocations.Add(new BodyLocation(gameObject, "torso"));
        being.bodyLocations.Add(new BodyLocation(gameObject, "left hand"));
        being.bodyLocations.Add(new BodyLocation(gameObject, "right hand"));
        being.bodyLocations.Add(new BodyLocation(gameObject, "legs"));
        being.bodyLocations.Add(new BodyLocation(gameObject, "feet"));

        Resource focus = new Resource(gameObject, "Focus", 20);
        being.resources.Add(focus);

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
        punch.ranks = 100;

        

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

        Ability magicShield = new Ability(gameObject, "Magic Shield", CombatStates.INITIATIVESORT, false);
        magicShield.Awake();
        magicShield.numberOfTargets = 1;
        Self bum = new Self(gameObject, "Self");// this should really be done through prefabs
        self.Awake();
        heal.Targets.Add(self);


        being.abilities.Add(punch);
        being.abilities.Add(demonSlash);
        being.abilities.Add(kick);
        being.abilities.Add(heal);
        being.abilities.Add(magicShield);

        // RequiresEquipped requiresStaff = new RequiresEquipped(gameObject, "Requires Staff", 100);
        //  heal.Flaws.Add(requiresStaff);
        // requiresStaff.Awake();

        Sword sword = new Sword(gameObject, "Bronze Sword", 1);
        being.Equip(sword, "right hand");







        


        return gameObject;
        
    }
    
 
    
    
    
    
    
    
    
    
    
    
    
    // Use this for initialization
	void Start () {
     

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
