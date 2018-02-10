using UnityEngine;
using System.Collections;

public interface IBeingComponent {

    //honestly, calling it parent object was a silly name because its actually the parent 'being' the Being class that is the root of the 
    //ability chain or whatever. Not the actual parent object that you could reference through the transform/ with functionality in Unity already

    //The point of this interface is that anything that sits inside a Being should be able to reference its parent being.

    GameObject parentObject { get; set; }
}
