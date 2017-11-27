using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveFood : MonoBehaviour {
    public GameObject slap;
    public AudioClip goodSound;
    public AudioClip badSound;

    private GameObject tmp;
    private AudioSource gameAudio;
    private float progressPoints;
    private Slider progressBar;

	// Use this for initialization
	void Start ()
    {
        gameAudio = this.GetComponent<AudioSource>();
        progressBar = Slider.FindObjectOfType<Slider>();
        progressPoints = progressBar.value;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator Slap ()
    {
        yield return new WaitForSeconds(1f);
        Destroy(tmp);
        Destroy(this.gameObject);
    }

    void OnMouseDown ()
    {
        this.name = "slapped";
        gameAudio.volume = 0.8f;

        if (this.tag == "GoodFood")
        {
            gameAudio.clip = goodSound;

            if (progressPoints < 1f)
                progressPoints += 0.10f;
        }
        else if (this.tag == "BadFood")
        {
            gameAudio.clip = badSound;

            if (progressPoints > 0f)
                progressPoints -= 0.10f;
        }

        gameAudio.Play();
        progressBar.value = progressPoints;

        tmp = Instantiate(slap, this.transform.position, this.transform.rotation);
        StartCoroutine(Slap());

        if (progressBar.value >= 1f)
        {
            //this.GetComponent<WinLevel>().wi
        }
    }

    void OnDestroy ()
    {
        if (tmp != null)
            Destroy(tmp);
    }
}
