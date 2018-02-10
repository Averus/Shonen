using UnityEngine;
using System.Collections;

public interface ITarget {

    string targetName { get; set; }

    bool CanThisBeTargeted(Being combatant);



}
