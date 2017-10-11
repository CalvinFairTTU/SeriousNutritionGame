using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayerCamera : MonoBehaviour
{

    public GameObject player;
    public float BoxDimX;
    public float BoxDimY;


    private Vector3 offset;
    private Vector3 newOffset;
    private Vector3 adjustment;
    //private float zAxis;
    

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
        transform.position = player.transform.position + offset;
        //zAxis = offset.z;
        adjustment = new Vector3();
    }


    void LateUpdate()
    {
        newOffset = player.transform.position - transform.position;
        adjustment = new Vector3(0,0,0);
        if (newOffset.x > BoxDimX)
        {
            adjustment.x = newOffset.x - BoxDimX;
        }
        else if (newOffset.x < -BoxDimX)
        {
            adjustment.x = newOffset.x + BoxDimX;
        }
        if (newOffset.y > BoxDimY)
        {
            adjustment.y = newOffset.y - BoxDimY;
        }
        else if (newOffset.y < -BoxDimY)
        {
            adjustment.y = newOffset.y + BoxDimY;
        }
        transform.position = transform.position + adjustment;
        //transform.position = player.transform.position + offset;
    }
}
