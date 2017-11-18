using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EmotionSwitcher : MonoBehaviour
{
    public enum Emotion
    {
        Norlam, 
        Happy,
        Orgasm,
        Frustrated
    };

    public Sprite[] emotionSprites;

	public void SetCurrentEmotion (Emotion emotion)
    {
        GetComponent<SpriteRenderer>().sprite = emotionSprites[(int) emotion];
    }
}
