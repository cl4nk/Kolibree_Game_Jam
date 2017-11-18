using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataKeeper : Singleton<CharacterDataKeeper>
{
    public Color skinColor = Color.green;
    public Color hairColor = Color.magenta;
    public Color eyeColor = Color.blue;

    public Character characterPrefab;

    public void Start()
    {
        skinColor = ColorOptionMenu.GetColor(ColorOptionMenu.ColorPart.Skin);
        skinColor.a = 1.0f;
        hairColor = ColorOptionMenu.GetColor(ColorOptionMenu.ColorPart.Hair);
        hairColor.a = 1.0f;
        eyeColor = ColorOptionMenu.GetColor(ColorOptionMenu.ColorPart.Eye);
        eyeColor.a = 1.0f;
    }
}
