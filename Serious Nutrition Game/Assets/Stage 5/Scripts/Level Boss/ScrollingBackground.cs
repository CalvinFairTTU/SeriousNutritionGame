﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

	public float Speed;

	private MeshRenderer backgroundRenderer;


	// Update is called once per frame
	void Update()
	{
		Vector2 offeset = new Vector2(-Time.time * Speed, 0);
		GetComponent<Renderer>().material.mainTextureOffset = offeset;
	}

	void Start()
	{
		backgroundRenderer = this.GetComponent<MeshRenderer>();

		backgroundRenderer.sortingLayerName = "Background";

	}

}