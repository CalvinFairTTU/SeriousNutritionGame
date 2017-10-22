using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCanScript : MonoBehaviour {

    public ProgressBar pB;

    void OnTriggerStay2D(Collider2D food) {
        if (food.tag == "Bad_Food") {
            pB.progressUp();
        }
        else {
            pB.progressDown();
        }
        Destroy(food.gameObject);
    }
}
