using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FXManager : Singleton<FXManager>
{
    public float SpeakChance = 0.1f;
    public string[] ExcitedStringList;
    public string[] NormalStringList;
    public string[] FrustratedStringList;

    public event Action<string> OnCharacterSpeak;

    private AudioSource audioSource;
    public AudioSource Source
    {
        get
        {
            if (audioSource == null)
                audioSource = GetComponent<AudioSource>();
            return audioSource;
        }
    }

    public void OnEnable()
    {
        BrushRythmManager.Instance.OnBrushCompleted += this.Instance_OnBrushCompleted;
    }

    public void OnDisable()
    {
        BrushRythmManager.Instance.OnBrushCompleted -= this.Instance_OnBrushCompleted;
    }

    private void Instance_OnBrushCompleted(BrushRythm rythm, AraToothbrushZone zone, Accuracy accuracy)
    {

        if (UnityEngine.Random.value < SpeakChance)
            Speak();
    }

    private void Speak()
    {
    }

    private void SpeakRandomFromList(string[] list)
    {
        int index = UnityEngine.Random.Range(0, list.Length);
        OnCharacterSpeak.Invoke(list[index]);
    }
}
