using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextObjectBehaviour : MonoBehaviour {


    public Vector2 Anchored;

    // Use this for initialization
    void Start () {
	Anchored = gameObject.GetComponent<Text>().rectTransform.anchoredPosition;

    }
	
	// Update is called once per frame
	void Update () {
	//if (gameObject)
	}
}
