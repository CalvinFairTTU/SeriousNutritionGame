using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNote : MonoBehaviour 
{
	public GameObject[] keys;
	public GameObject[] foodSprites;
	public GameObject[] foodPrefabs;

	public AudioSource[] keyAudio;
	public SpriteRenderer[] keyRenderer;

	void Update () 
	{
		
		SpriteRenderer key1 = keyRenderer[0];
		SpriteRenderer key2 = keyRenderer[1];
		SpriteRenderer key3 = keyRenderer[2];
		SpriteRenderer key4 = keyRenderer[3];
		SpriteRenderer key5 = keyRenderer[4];
		SpriteRenderer key6 = keyRenderer[5];
		SpriteRenderer key7 = keyRenderer[6];
		SpriteRenderer key8 = keyRenderer[7];

		if(Input.GetMouseButtonDown(0)) {
			Vector3 mouseCord = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			Collider2D keyOne = keys[0].GetComponent<Collider2D>();
			Collider2D keyTwo = keys[1].GetComponent<Collider2D>();
			Collider2D keyThree = keys[2].GetComponent<Collider2D>();
			Collider2D keyFour = keys[3].GetComponent<Collider2D>();
			Collider2D keyFive = keys[4].GetComponent<Collider2D>();
			Collider2D keySix = keys[5].GetComponent<Collider2D>();
			Collider2D keySeven = keys[6].GetComponent<Collider2D>();
			Collider2D keyEight = keys[7].GetComponent<Collider2D>();

			if (Input.GetKeyDown (KeyCode.A) || keyOne.OverlapPoint(mouseCord)) {
				keyAudio [0].Play ();
				Instantiate (foodPrefabs [0], foodSprites [0].gameObject.transform.position, foodSprites [0].gameObject.transform.rotation);
			}
			if (Input.GetKeyDown(KeyCode.S) || keyTwo.OverlapPoint(mouseCord)) {
				keyAudio [1].Play ();
				Instantiate (foodPrefabs [1], foodSprites[1].gameObject.transform.position, foodSprites[1].gameObject.transform.rotation);
			}
			if (Input.GetKeyDown(KeyCode.D) || keyThree.OverlapPoint(mouseCord)) {
				keyAudio [2].Play ();
				Instantiate (foodPrefabs [2], foodSprites[2].gameObject.transform.position, foodSprites[2].gameObject.transform.rotation);
			}
			if (Input.GetKeyDown(KeyCode.F) || keyFour.OverlapPoint(mouseCord)) {
				keyAudio [3].Play ();
				Instantiate (foodPrefabs [3], foodSprites[3].gameObject.transform.position, foodSprites[3].gameObject.transform.rotation);
			}
			if (Input.GetKeyDown(KeyCode.J) || keyFive.OverlapPoint(mouseCord)) {
				keyAudio [4].Play ();
				Instantiate (foodPrefabs [4], foodSprites[4].gameObject.transform.position, foodSprites[4].gameObject.transform.rotation);
			}
			if (Input.GetKeyDown(KeyCode.K) || keySix.OverlapPoint(mouseCord)) {
				keyAudio [5].Play ();
				Instantiate (foodPrefabs [5], foodSprites[5].gameObject.transform.position, foodSprites[5].gameObject.transform.rotation);
			}
			if (Input.GetKeyDown(KeyCode.L) || keySeven.OverlapPoint(mouseCord)) {
				keyAudio [6].Play ();
				Instantiate (foodPrefabs [6], foodSprites[6].gameObject.transform.position, foodSprites[6].gameObject.transform.rotation);
			}
			if (Input.GetKeyDown(KeyCode.Semicolon) || keyEight.OverlapPoint(mouseCord)) {
				keyAudio [7].Play ();
				Instantiate (foodPrefabs [7], foodSprites[7].gameObject.transform.position, foodSprites[7].gameObject.transform.rotation);
			}


			/////////////////////////////////////////////////////////////////////////



			if (Input.GetKey (KeyCode.A) || keyOne.OverlapPoint(mouseCord)) {
				key1.color = new Color (key1.color.r, key1.color.g, key1.color.b, 0.7f);
			} else {
				key1.color = new Color (key1.color.r, key1.color.g, key1.color.b, 1f);
			}
			if (Input.GetKey (KeyCode.S) || keyTwo.OverlapPoint(mouseCord)) {
				key2.color = new Color (key2.color.r, key2.color.g, key2.color.b, 0.7f);
			} else {
				key2.color = new Color (key2.color.r, key2.color.g, key2.color.b, 1f);
			}
			if (Input.GetKey (KeyCode.D) || keyThree.OverlapPoint(mouseCord)) {
				key3.color = new Color (key3.color.r, key3.color.g, key3.color.b, 0.7f);
			} else {
				key3.color = new Color (key3.color.r, key3.color.g, key3.color.b, 1f);
			}
			if (Input.GetKey (KeyCode.F) || keyFour.OverlapPoint(mouseCord)) {
				key4.color = new Color (key4.color.r, key4.color.g, key4.color.b, 0.7f);
			} else {
				key4.color = new Color (key4.color.r, key4.color.g, key4.color.b, 1f);
			}
			if (Input.GetKey (KeyCode.J) || keyFive.OverlapPoint(mouseCord)) {
				key5.color = new Color (key5.color.r, key5.color.g, key5.color.b, 0.7f);
			} else {
				key5.color = new Color (key5.color.r, key5.color.g, key5.color.b, 1f);
			}
			if (Input.GetKey (KeyCode.K) || keySix.OverlapPoint(mouseCord)) {
				key6.color = new Color (key6.color.r, key6.color.g, key6.color.b, 0.7f);
			} else {
				key6.color = new Color (key6.color.r, key6.color.g, key6.color.b, 1f);
			}
			if (Input.GetKey (KeyCode.L) || keySeven.OverlapPoint(mouseCord)) {
				key7.color = new Color (key7.color.r, key7.color.g, key7.color.b, 0.7f);
			} else {
				key7.color = new Color (key7.color.r, key7.color.g, key7.color.b, 1f);
			}
			if (Input.GetKey (KeyCode.Semicolon) || keyEight.OverlapPoint(mouseCord)) {
				key8.color = new Color (key8.color.r, key8.color.g, key8.color.b, 0.7f);
			} else {
				key8.color = new Color (key8.color.r, key8.color.g, key8.color.b, 1f);
			}
		}
	}
}
