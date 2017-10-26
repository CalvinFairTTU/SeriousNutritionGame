using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropMeatMarket : MonoBehaviour {

    PolygonCollider2D thisCollider;

    private void Start()
    {
        thisCollider = this.gameObject.GetComponent<PolygonCollider2D>();
    }


    void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = objPos;
        thisCollider.enabled = false;
    }

    void OnMouseUp()
    {
        thisCollider.enabled = true;
    }
}
