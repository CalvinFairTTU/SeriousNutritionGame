using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour {
    private int spawnIndex;
    private SpriteRenderer sprite;

    void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x == -2.0)
            spawnIndex = 0;
        if (transform.position.x == 2.05)
            spawnIndex = 1;
        if (transform.position.x == -1.5)
            spawnIndex = 2;
        if (transform.position.x > 1.5 && transform.position.x < 2.0)
            spawnIndex = 3;
        
        switch (spawnIndex)
        {
            case 0:
                sprite.sortingLayerName = "Foreground 01";
                if (transform.position.y < -1.5)
                    transform.Translate(new Vector3(0, 5, 0) * Time.deltaTime);
                Invoke("DespawnFood", 5f);
                break;
            case 1:
                sprite.sortingLayerName = "Foreground 01";
                if (transform.position.y < -1.5)
                    transform.Translate(new Vector3(0, 5, 0) * Time.deltaTime);
                Invoke("DespawnFood", 5f);
                break;
            case 2:
                sprite.sortingLayerName = "Foreground 02";
                if (transform.position.y < 0.03)
                    transform.Translate(new Vector3(0, 5, 0) * Time.deltaTime);
                Invoke("DespawnFood", 5f);
                break;
            case 3:
                sprite.sortingLayerName = "Foreground 02";
                if (transform.position.y < 0.03)
                    transform.Translate(new Vector3(0, 5, 0) * Time.deltaTime);
                Invoke("DespawnFood", 5f);
                break;
        }
	}

    void DespawnFood ()
    {
        if (transform.position.x == -2.0)
            spawnIndex = 0;
        if (transform.position.x == 2.05)
            spawnIndex = 1;
        if (transform.position.x == -1.5)
            spawnIndex = 2;
        if (transform.position.x > 1.5 && transform.position.x < 2.0)
            spawnIndex = 3;

        switch (spawnIndex)
        {
            case 0:
                if (transform.position.y > -2.908023)
                    transform.Translate(new Vector3(0, -5, 0) * Time.deltaTime);
                break;
            case 1:
                if (transform.position.y > -2.908023)
                    transform.Translate(new Vector3(0, -5, 0) * Time.deltaTime);
                break;
            case 2:
                if (transform.position.y > -1.068023)
                    transform.Translate(new Vector3(0, -5, 0) * Time.deltaTime);
                break;
            case 3:
                if (transform.position.y > -1.068023)
                    transform.Translate(new Vector3(0, -5, 0) * Time.deltaTime);
                Invoke("DespawnFood", 5f);
                break;
        }

        Destroy(this.gameObject);
    }
}
