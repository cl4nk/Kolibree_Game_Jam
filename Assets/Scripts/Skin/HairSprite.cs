using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HairSprite : MonoBehaviour {

    public Sprite defaultSprite;
    // Use this for initialization
    void Start()
    {
        if (CharacterDataKeeper.HasHairColor())
            GetComponent<SpriteRenderer>().color = CharacterDataKeeper.Instance.hairColor;
        else
            GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }

}
