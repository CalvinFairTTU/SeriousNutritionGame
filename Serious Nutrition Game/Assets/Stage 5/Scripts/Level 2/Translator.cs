using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour {
    private int spawnIndex;
    private SpriteRenderer sprite;
    private bool spawn = true;

    void Start ()
    {
        sprite = this.GetComponent<SpriteRenderer>();
    }

	// Update is called once per frame
	void Update ()
    {
        if(spawn)
            MoveUp();
        StartCoroutine(Wait());
	}

    void MoveUp ()
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
                if (transform.position.y < -1.75)
                    transform.Translate(new Vector3(0, 5, 0) * Time.deltaTime);
                break;
            case 1:
                sprite.sortingLayerName = "Foreground 01";
                if (transform.position.y < -1.75)
                    transform.Translate(new Vector3(0, 5, 0) * Time.deltaTime);
                break;
            case 2:
                sprite.sortingLayerName = "Foreground 02";
                if (transform.position.y < 0.03)
                    transform.Translate(new Vector3(0, 5, 0) * Time.deltaTime);
                break;
            case 3:
                sprite.sortingLayerName = "Foreground 02";
                if (transform.position.y < 0.03)
                    transform.Translate(new Vector3(0, 5, 0) * Time.deltaTime);
                break;
        }
    }

    IEnumerator MoveDown ()
    {
        switch (spawnIndex)
        {
            case 0:
                sprite.sortingLayerName = "Foreground 01";
                if (transform.position.y > -2.9)
                {
                    transform.Translate(new Vector3(0, -5, 0) * Time.deltaTime);
                }
                break;
            case 1:
                sprite.sortingLayerName = "Foreground 01";
                if (transform.position.y > -2.9)
                {
                    transform.Translate(new Vector3(0, -5, 0) * Time.deltaTime);
                }
                break;
            case 2:
                sprite.sortingLayerName = "Foreground 02";
                if (transform.position.y > -1.2)
                {
                    transform.Translate(new Vector3(0, -5, 0) * Time.deltaTime);
                }
                break;
            case 3:
                sprite.sortingLayerName = "Foreground 02";
                if (transform.position.y > -1.2)
                {
                    transform.Translate(new Vector3(0, -5, 0) * Time.deltaTime);
                }
                break;
        }

        yield return null;
    }

    IEnumerator Wait ()
    {
        yield return new WaitForSeconds(5f);
        spawn = false;
        yield return StartCoroutine(MoveDown());
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
        spawn = true;
    }
}
