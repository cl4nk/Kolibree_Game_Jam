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
        if (ColorOptionMenu.HasColor(ColorOptionMenu.ColorPart.Skin))
        {
            skinColor = ColorOptionMenu.GetColor(ColorOptionMenu.ColorPart.Skin);
            skinColor.a = 1.0f;
        }
        if (ColorOptionMenu.HasColor(ColorOptionMenu.ColorPart.Hair))
        {
            hairColor = ColorOptionMenu.GetColor(ColorOptionMenu.ColorPart.Hair);
            hairColor.a = 1.0f;
        }
        if (ColorOptionMenu.HasColor(ColorOptionMenu.ColorPart.Eye))
        {
            eyeColor = ColorOptionMenu.GetColor(ColorOptionMenu.ColorPart.Eye);
            eyeColor.a = 1.0f;
        }
    }
}
