using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSetter : MonoBehaviour
{
    public event Action<Color> OnValidateColor;

    private Color currentColor = Color.white;
    public Color CurrentColor
    {
        get { return currentColor; }
        set
        {
            currentColor = value;
            image.color = value;
        }
    }

    [SerializeField]
    private Slider redSlider;

    [SerializeField]
    private Slider greenSlider;

    [SerializeField]
    private Slider blueSlider;

    [SerializeField]
    private Image image;

    public void Start()
    {
        redSlider.value = currentColor.r;
        greenSlider.value = currentColor.g;
        blueSlider.value = currentColor.b;

        redSlider.onValueChanged.AddListener(SetRedValue);
        greenSlider.onValueChanged.AddListener(SetGreenValue);
        blueSlider.onValueChanged.AddListener(SetBlueValue);
    }

    public void SetRedValue(float value)
    {
        Color color = CurrentColor;
        color.r = value;
        CurrentColor = color;
    }

    public void SetGreenValue(float value)
    {
        Color color = CurrentColor;
        color.g = value;
        CurrentColor = color;
    }

    public void SetBlueValue(float value)
    {
        Color color = CurrentColor;
        color.b = value;
        CurrentColor = color;
    }

    public void ValidateColor()
    {
        OnValidateColor.Invoke(currentColor);
    }
}
