using UnityEngine;
using System.Collections;


public interface IFlaw
{

    string flawName { get; set; }

    bool CanThisBeUsed();


}
