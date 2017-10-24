using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMovement : MonoBehaviour {

    public float Speed;

    // Update is called once per frame
    void Update()
    {
        Vector2 offeset = new Vector2(0, Time.time * Speed);
        GetComponent<Renderer>().material.mainTextureOffset = offeset;
    }
}
