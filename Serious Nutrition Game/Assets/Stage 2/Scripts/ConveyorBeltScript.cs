using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltScript : MonoBehaviour {

    public float speed = 0.3f;

    void OnTriggerStay2D(Collider2D col) {
        col.transform.Translate(-speed * Time.deltaTime, 0, 0);
        col.transform.Translate(0, .001f, 0);
    }
}
