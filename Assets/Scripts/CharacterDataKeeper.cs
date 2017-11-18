using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataKeeper : Singleton<CharacterDataKeeper>
{
    public Color skinColor = Color.green;
    public Color hairColor = Color.magenta;
    public Color eyeColor = Color.blue;

    public Character characterPrefab;
}
