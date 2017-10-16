using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogMovement : MonoBehaviour {

    public float speed;
    public float targetCatch;
    public Rigidbody2D rb2d;
    public Animator anim;

    private Vector2 target;
    private Vector2 offset;
    private float hypontenuse;
    private float epsilon;
    private float targetAngle;


    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        target = new Vector2(transform.position.y, transform.position.x);
        anim.SetInteger("State", 0);
    }

    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
            hypontenuse = Mathf.Sqrt((offset.x * offset.x) + (offset.y * offset.y));
            offset.x = (offset.x / hypontenuse) * speed;
            offset.y = (offset.y / hypontenuse) * speed;
            targetAngle = (Mathf.Atan2(offset.y, offset.x) - (Mathf.PI / 2)) * Mathf.Rad2Deg;
            rb2d.rotation = targetAngle;
            rb2d.velocity = new Vector2(offset.x, offset.y);
            anim.SetInteger("State", 1);
        }
        offset = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
        epsilon = Mathf.Sqrt((offset.x * offset.x) + (offset.y * offset.y));
        if (epsilon < targetCatch)
        {
            rb2d.velocity = new Vector2(0f, 0f);
            anim.SetInteger("State", 0);
        }
        else
        {
            anim.SetInteger("State", 1);
        }
    }
}




   

