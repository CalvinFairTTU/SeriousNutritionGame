using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBoxScript : MonoBehaviour {

    public GameObject Counter;
    public GameObject face;
    private SpawnCounterScript script;
    private SmileyFaceScript faceScript;
    
    private string thisBox;
    private int isEqual;

    enum faceStates
    {
        HAPPY,
        CONFUSED,
        CHEER
    };



    // Use this for initialization
    void Start ()
    {
        script = Counter.GetComponent<SpawnCounterScript>();
        if (this.tag == "Bad_Food")
        {
            thisBox = "badBox";
        }
        else 
        {
            thisBox = "goodBox";
        }
        faceScript = face.GetComponent<SmileyFaceScript>();
        Debug.Log("thisBox = " + thisBox + " on " + this);
    }

    private void OnTriggerStay2D(Collider2D food)
    {

        script.DecrementCounter(food,thisBox,this.tag);        

        isEqual = string.Compare(this.tag, food.tag, false);

        if(isEqual == 0)
        {
            //Do something that indicates the right action was taken.
            faceScript.SetFaceState(1);
        }
        else
        {
            //Do something that indicates the wrong action was taken.
            faceScript.SetFaceState(0);
        }

        food.gameObject.SetActive(false);
    }
}
