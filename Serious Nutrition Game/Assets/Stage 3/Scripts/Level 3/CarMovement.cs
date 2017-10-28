using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    public float speed;
    public float targetCatch;
    public Rigidbody2D rb2d;
    public GameObject PauseButton;
    public Camera cam;

    private Vector2 target;
    private Vector2 offset;
    private float hypontenuse;
    private float epsilon;
    private float targetAngle;
    private RectTransform RT;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        target = new Vector2(transform.position.y, transform.position.x);
        RT = PauseButton.GetComponent<RectTransform>();
    }


    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(RT, Input.mousePosition, cam) && Camera.main.pixelRect.Contains(Input.mousePosition))
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                offset = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
                hypontenuse = Mathf.Sqrt((offset.x * offset.x) + (offset.y * offset.y));
                offset.x = (offset.x / hypontenuse) * speed;
                offset.y = (offset.y / hypontenuse) * speed;
                targetAngle = (Mathf.Atan2(offset.y, offset.x)/* - (Mathf.PI / 2)*/) * Mathf.Rad2Deg;
                rb2d.rotation = targetAngle;
                rb2d.velocity = new Vector2(offset.x, offset.y);
            }
        }
        offset = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
        epsilon = Mathf.Sqrt((offset.x * offset.x) + (offset.y * offset.y));
        if (epsilon < targetCatch)
        {
            rb2d.velocity = new Vector2(0f, 0f);
        }
        else
        {
            ;
        }
    }

    //void OnTriggerStay2D(Collider2D col)
    //{
    //    if (col.tag == "LowerWall" || col.tag == "UpperWall" || col.tag == "LeftWall" || col.tag == "RightWall")
    //    {
    //        target = new Vector2(this.transform.position.x, this.transform.position.y);
    //    }        
    //}
}
