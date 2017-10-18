using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBoxScript : MonoBehaviour {

    public GameObject Counter;
    public GameObject face;
    private SpawnCounterScript script;
    private SmileyFaceScript faceScript;
    
    private bool isForGoodFood;
    private string thisBox;

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
        if (this.tag == "For_Good_Food")
        {
            isForGoodFood = true;
            thisBox = "goodBox";
        }
        else if (this.tag == "For_Bad_Food")
        {
            isForGoodFood = false;
            thisBox = "badBox";
        }
        faceScript = face.GetComponent<SmileyFaceScript>();
    }

    private void OnTriggerStay2D(Collider2D food)
    {

        script.DecrementCounter(food,thisBox);

        if (isForGoodFood)
        {
            if (food.tag == "Good_Food")
            {
                // Do something that indicates the right action was taken.
                faceScript.SetFaceState(1);
            }
            else
            {
                // Do something that indicates the wrong action was taken.
                faceScript.SetFaceState(0);
            }
        }
        else
        {
            if (food.tag == "Good_Food")
            {
                // Do something that indicates the wrong action was taken.
                faceScript.SetFaceState(0);
            }
            else
            {
                // Do something that indicates the right action was taken.
                faceScript.SetFaceState(1);
            }
        }
        
        food.gameObject.SetActive(false);
    }
}
