using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOptionMenu : MonoBehaviour
{

    public enum ColorPart
    {
        Skin, Hair, Eye, None = -1,
    };

    private ColorPart colorPart = ColorPart.None;
    public ColorPart CurrentColorPart
    {
        get { return colorPart; }
        set
        {
            if (colorPart == value)
                return;

            SaveColor(colorPart, colorSetter.CurrentColor);

            colorPart = value;
            colorSetter.CurrentColor = GetColor(value);
        }
    }

    [SerializeField]
    private ColorSetter colorSetter;

	// Use this for initialization
	void Start ()
    {
        CurrentColorPart = ColorPart.Skin;
        colorSetter.OnValidateColor += this.ColorSetter_OnValidateColor;
    }


    public void SwitchToHair()
    {
        CurrentColorPart = ColorPart.Hair;
    }

    public void SwitchToSkin()
    {
        CurrentColorPart = ColorPart.Skin;
    }

    public void SwitchToEye()
    {
        CurrentColorPart = ColorPart.Eye;
    }

    public static Color GetColor(ColorPart colorPart)
    {
        Color color = new Color();
        color.r = PlayerPrefs.GetFloat(colorPart.ToString() + 'r', 1.0f);
        color.g = PlayerPrefs.GetFloat(colorPart.ToString() + 'g', 1.0f);
        color.b = PlayerPrefs.GetFloat(colorPart.ToString() + 'b', 1.0f);
        return color;
    }
	
	private void SaveColor (ColorPart colorPart, Color value)
    {
        if (colorPart == ColorPart.None)
            return;
        PlayerPrefs.SetFloat(colorPart.ToString() + 'r', value.r);
        PlayerPrefs.SetFloat(colorPart.ToString() + 'g', value.g);
        PlayerPrefs.SetFloat(colorPart.ToString() + 'b', value.b);
        PlayerPrefs.Save();

        value.a = 1.0f;
        switch (colorPart)
        {
            case ColorPart.Skin:
                CharacterDataKeeper.Instance.skinColor = value;
                break;
            case ColorPart.Hair:
                CharacterDataKeeper.Instance.hairColor = value;
                break;
            case ColorPart.Eye:
                CharacterDataKeeper.Instance.eyeColor = value;
                break;
        }
    }

    private void ColorSetter_OnValidateColor(Color value)
    {
        SaveColor(CurrentColorPart, value);
    }
}
