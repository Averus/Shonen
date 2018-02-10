using UnityEngine;
using System.Collections;

public class OLDCombatController : MonoBehaviour {

    // Use this for initialization
    
    public GameObject PlayerAvatar;
    public GameObject Combatant;

    GameObject playerAvatarClone;
    GameObject enemyCombatantClone;

    Vector3 playerAvatarArea = new Vector3( 4.0f , 0.0f , 0.0f );
    Vector3 enemyCombatantArea = new Vector3( -4.0f , 0.0f , 0.0f );


 void OnGUI()
    {

        DisplayStats(playerAvatarClone);
        DisplayStats(enemyCombatantClone);


    }

	void Start () {

        playerAvatarClone = Instantiate(PlayerAvatar, playerAvatarArea, Quaternion.identity) as GameObject;
        enemyCombatantClone = Instantiate(Combatant, enemyCombatantArea, Quaternion.identity) as GameObject;

    }
	
	// Update is called once per frame
	void Update () {


          

    }

    void DisplayStats(GameObject target)
    {
        //In a perfect world, stats would be stored in a hashtable and this function woudl cycle through and display the ones that are there. But I cba to write that.

        //Get a reference to the main camera from who's perspective the 'world' becomes the 'screen'.
        Camera cam = Camera.main.GetComponent<Camera>();

        //Convert the 'world' position vec3 from the target gameobject(argument) into a vec3 adjusted to 'screen' perspective.
        Vector3 vec = cam.WorldToScreenPoint(target.transform.position);

        float screen = Screen.height;

        //These are the amount by which the text is offset from the targets center
        int hOffset = 80;
        int vOffset = 90;

        //Create a label using the x and y from that vector and display the stats
        GUI.Label(new Rect(vec.x + hOffset, (screen - vec.y) - vOffset, 100, 20), "HP: " + target.GetComponent<Being>().HP);
    }


}