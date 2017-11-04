using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthShrinkScript : MonoBehaviour {

    public GameObject growthRay;
    public GameObject shrinkRay;

    private Collider2D foodObj = null;

    void Update () {
       
        if(Input.GetMouseButtonDown(0)) {
            Vector3 mouseCord = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D shrinkIt = shrinkRay.GetComponent<Collider2D>();
            Collider2D growIt = growthRay.GetComponent<Collider2D>();

            if (shrinkIt.OverlapPoint(mouseCord)) {
                shrink();
            }
            if (growIt.OverlapPoint(mouseCord)) {
                growth();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D food)
    {
        foodObj = food;
    }

    void OnTriggerExit2D(Collider2D food)
    {
        foodObj = null;
    }

    void growth() {
        Debug.Log("Growth ray clicked.");
        foodObj.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
    }
    void shrink() {
        Debug.Log("Shrink ray clicked.");
        foodObj.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
    }
}
