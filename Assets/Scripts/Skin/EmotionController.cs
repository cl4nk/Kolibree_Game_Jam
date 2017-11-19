using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EmotionController : MonoBehaviour
{

    private void OnEnable()
    {
        GameManager.Instance.OnEmotionChanged += this.Instance_OnEmotionChanged;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnEmotionChanged -= Instance_OnEmotionChanged;
    }

    private void Instance_OnEmotionChanged(CharacterEmotion emo)
    {
        GetComponent<Animator>().SetTrigger((int) emo);
    }
}
