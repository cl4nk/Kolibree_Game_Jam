using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SkinSprite : MonoBehaviour
{
    public Sprite defaultSprite;
    // Use this for initialization
    void Start()
    {
        if (CharacterDataKeeper.HasSkinColor())
            GetComponent<SpriteRenderer>().color = CharacterDataKeeper.Instance.skinColor;
        else
            GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }
}
