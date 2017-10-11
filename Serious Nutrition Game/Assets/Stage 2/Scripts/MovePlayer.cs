using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour 
{
	public float speed;
	public AudioClip goodSound;
	public AudioClip badSound;
	public Slider progressBar;
	public Image star;
    public GameObject player;

	float progressPoints;
	Rigidbody2D rb2d;
	AudioSource gameAudio;

	void Start () 
	{
		progressPoints = 0;
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.transform.position = new Vector2 (0f, -62f); 
		gameAudio = GetComponent<AudioSource> ();
	}

	void FixedUpdate () 
	{
		float moveHoriz = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (moveHoriz, 0f);
		rb2d.AddForce(movement * speed);

		float horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height; //horizontal distance from center to edge of screen
		float rb2dMidToEdge = 30f; //value to stop player sprite moving halfway off the screen within clamp

		//limit player horizontal movement to within screen boundaries
		rb2d.transform.position = new Vector2 (Mathf.Clamp (rb2d.transform.position.x, (-horzExtent + (2.5f * rb2dMidToEdge)), (horzExtent - rb2dMidToEdge)), rb2d.transform.position.y);

		//rotate player orientation based on direction they are facing
		if (moveHoriz > 0) {
			rb2d.transform.rotation = new Quaternion (0, 0, 0, 0); 
		} else if (moveHoriz < 0) {
			rb2d.transform.rotation = new Quaternion (0, 180, 0, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D foodItem) //collision with food
	{
		if (foodItem.tag == "Good_Food") {
            growth();
			gameAudio.volume = 0.8f;
			gameAudio.clip = goodSound;
			if (progressPoints < 1f) {
				progressPoints += 0.05f;
			}
		} else if (foodItem.tag == "Bad_Food") {
            shrink();
			gameAudio.volume = 1f;
			gameAudio.clip = badSound;
			if (progressPoints > 0f) {
				progressPoints -= 0.05f;
			}		
		}
		gameAudio.Play ();
		Destroy (foodItem.gameObject);
		progressBar.value = progressPoints;

		if (progressBar.value >= 1f) {
			gameObject.GetComponent<WinGame> ().Win ();
			gameObject.GetComponent<EdgeCollider2D> ().enabled = false;
		}
	}

    void growth()
    {
        player.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
    }

    void shrink()
    {
        player.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
    }
}
