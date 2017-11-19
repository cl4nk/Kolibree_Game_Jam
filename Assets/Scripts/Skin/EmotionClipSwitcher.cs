using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EmotionClipSwitcher : MonoBehaviour
{

    public AudioClip[] emotionClips;

    private void OnEnable()
    {
        GameManager.Instance.OnEmotionChanged += SetCurrentEmotion;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnEmotionChanged -= SetCurrentEmotion;
    }

    public void SetCurrentEmotion(CharacterEmotion emotion)
    {
        int index = (int) emotion;
        GetComponent<AudioSource>().clip = emotionClips[index];
    }
}
