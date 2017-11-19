using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EyeSprite : MonoBehaviour
{
    public Sprite defaultSprite;
    // Use this for initialization
    void Start()
    {
        if (CharacterDataKeeper.HasEyeColor())
            GetComponent<SpriteRenderer>().color = CharacterDataKeeper.Instance.eyeColor;
        else
            GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }
}
