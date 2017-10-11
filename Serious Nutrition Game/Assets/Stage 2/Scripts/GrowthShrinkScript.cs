using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthShrinkScript : MonoBehaviour {

	public GameObject item;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            growth();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            shrink();
        }
    }

	void growth() {
        item.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
    }

	void shrink() {
        item.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
    }
}
