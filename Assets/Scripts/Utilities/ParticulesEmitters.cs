using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulesEmitters : MonoBehaviour {

    public List<GameObject> frustrate;
    public List<GameObject> normal;
    public List<GameObject> good;
    public List<GameObject> veryGood;
    public List<GameObject> perfect;

    public string lType;
    public bool spawnParticule = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnParticule)
        {
            EmitParticule(Accuracy.Perfect);
            spawnParticule = false;
        }
	}

    public void EmitParticule(Accuracy pType)
    {
        GameObject lEmitSprite;
        GameObject lRandomSprite;
        Vector2 velocity = new Vector2(0, 0);
        List<GameObject> lList = null;

        switch (pType)
        {
            case Accuracy.Bad:
                lList = frustrate;
                break;
            case Accuracy.Completed:
                lList = normal;
                break;
            case Accuracy.Good:
                lList = good;
                break;
            case Accuracy.None:
                lList = veryGood;
                break;
            case Accuracy.Perfect:
                lList = perfect;
                break;
            default:
                break;
        }

        lRandomSprite = lList.GetRandomItem();

        for (int i = 0; i < 5; i++)
        {
            lEmitSprite = Instantiate(lRandomSprite, transform);
            velocity.Set(Random.Range(-10, 10), Random.Range(-10, 10));
            lEmitSprite.GetComponent<Rigidbody2D>().AddForce(velocity, ForceMode2D.Impulse);
        }
    }
}
