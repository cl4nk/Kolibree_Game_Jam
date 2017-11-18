using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulesEmitters : MonoBehaviour {

    public enum ParticuleType
    {
        FRUSTRATE,
        NORMAL,
        GOOD,
        VERYGOOD,
        PERFECT
    }

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
            spawnParticule = false;
            EmitParticule(ParticuleType.PERFECT);
        }
	}

    void EmitParticule(ParticuleType pType)
    {
        GameObject lEmitSprite;
        GameObject lRandomSprite;
        Vector2 velocity = new Vector2(0, 0);
        float scale;
        List<GameObject> lList = null;

        switch (pType)
        {
            case ParticuleType.FRUSTRATE:
                lList = frustrate;
                break;
            case ParticuleType.NORMAL:
                lList = normal;
                break;
            case ParticuleType.GOOD:
                lList = good;
                break;
            case ParticuleType.VERYGOOD:
                lList = veryGood;
                break;
            case ParticuleType.PERFECT:
                lList = perfect;
                break;
            default:
                break;
        }

        lRandomSprite = lList.GetRandomItem();

        for (int i = 0; i < 5; i++)
        {
            lEmitSprite = Instantiate(lRandomSprite);
            scale = Random.Range(0.4f, 1);
            lEmitSprite.transform.localScale = new Vector2(scale, scale);
            velocity.Set(Random.Range(-50, 50), Random.Range(-50, 50));
            lEmitSprite.GetComponent<Rigidbody2D>().AddForce(velocity, ForceMode2D.Impulse);
        }
    }
}
