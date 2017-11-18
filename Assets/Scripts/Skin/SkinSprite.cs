using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SkinSprite : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GetComponent<SpriteRenderer>().color = CharacterDataKeeper.Instance.skinColor;
    }
}
