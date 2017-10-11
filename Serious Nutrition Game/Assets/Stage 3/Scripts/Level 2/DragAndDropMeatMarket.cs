using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropMeatMarket : MonoBehaviour {

    void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = objPos;
    }

}
