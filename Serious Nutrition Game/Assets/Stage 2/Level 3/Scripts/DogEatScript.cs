using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DogEatScript : MonoBehaviour {

    public ProgressBar pB;
   
    void OnTriggerStay2D(Collider2D food) {
        if (food.tag == "Good_Food") {
            pB.progressUp();
        }
        else {
            pB.progressDown();
        }
        Destroy(food.gameObject);
    }
}