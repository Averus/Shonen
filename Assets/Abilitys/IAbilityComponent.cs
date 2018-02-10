using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbilityComponent {

    string abilityComponentName { get; set; } //what is the components name?

    bool CanThisBeUsed(); //Conditions for activation of ability component

    void Use(); //What happens upon activation?
}
