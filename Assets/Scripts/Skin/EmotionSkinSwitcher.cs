using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EmotionSkinSwitcher : MonoBehaviour {

    public Sprite[] emotionSprites;
    public Sprite[] grayEmotionSprites;

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
        Sprite result = CharacterDataKeeper.HasSkinColor() ? grayEmotionSprites[index] : emotionSprites[index];
        GetComponent<SpriteRenderer>().sprite = result;
    }
}
