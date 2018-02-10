using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TextController : MonoBehaviour{


    public float inputBoxHeight = 25;
    public float textFrameLeft = 25;
    public float textFrameBottom;
    public float textLineSpacing = 20;
    public GameObject[] textObjects;

    void Start()
    {
        textFrameBottom = (Screen.height - inputBoxHeight);
        
    }


    public void Print(string str)
    {

        textObjects = GameObject.FindGameObjectsWithTag("TextObject");

        //Move all existing lines of text up
        if (textObjects.Length > 0)
        {
            foreach (GameObject go in textObjects)
            {

                Vector2 temp = go.GetComponentInChildren<Text>().rectTransform.anchoredPosition;
                temp.y += textLineSpacing;
                go.GetComponentInChildren<Text>().rectTransform.anchoredPosition = temp;

                if (go.GetComponentInChildren<Text>().rectTransform.anchoredPosition.y > Screen.height)
                {
                    Destroy(go);
                }

            }

        }

        //Create a new line of text at the bottom of the stack
        GameObject newText = Instantiate(Resources.Load("TextObject")) as GameObject;
        newText.GetComponentInChildren<Text>().text = str;

    }


    private void SubmitInput(string arg0)
    {

    }

    // Update is called once per frame
    static void Update () {

	}
}
