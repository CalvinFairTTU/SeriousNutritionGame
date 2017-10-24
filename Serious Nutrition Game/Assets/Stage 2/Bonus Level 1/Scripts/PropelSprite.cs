using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropelSprite : MonoBehaviour
{
	float speed = 5f;

	void Update() {
		if (gameObject != null) {
			if (gameObject.transform.position.y < 7f) {
				gameObject.transform.Translate (Vector2.up * Time.deltaTime * speed, Space.World);
			} else {
				Destroy (gameObject);
			}
		}
	}

}
