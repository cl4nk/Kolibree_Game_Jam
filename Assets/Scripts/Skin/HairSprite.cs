using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HairSprite : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GetComponent<SpriteRenderer>().color = CharacterDataKeeper.Instance.hairColor;
    }

}
