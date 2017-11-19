using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class EmotionSwitcher : MonoBehaviour
{
    public enum Emotion
    {
        Normal, 
        Happy,
        Orgasm,
        Frustrated
    };

    public Sprite[] emotionSprites;
    public AudioClip[] emotionClips;

	public void SetCurrentEmotion (Emotion emotion)
    {
        int index = (int) emotion;
        GetComponent<SpriteRenderer>().sprite = emotionSprites[index];
        GetComponent<AudioSource>().clip = emotionClips[index];
    }
}
