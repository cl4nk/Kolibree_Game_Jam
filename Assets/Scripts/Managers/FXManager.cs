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

    public float SoundChance = 0.4f;
    public AudioClip[] BadAudioClip;
    public AudioClip[] GoodAudioClip;
    public AudioClip[] PerfectAudioClip;
    public AudioClip[] CompletedAudioClip;

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

    private void Instance_OnBrushCompleted(AraToothbrushZone zone, Accuracy accuracy)
    {
        if (UnityEngine.Random.value < SoundChance)
            PlayAudio(accuracy);
        if (UnityEngine.Random.value < SpeakChance)
            Speak();
    }

    private void PlayAudio(Accuracy accuracy)
    {
        switch (accuracy)
        {
            case Accuracy.Bad:
                PlayRandomFromList(BadAudioClip);
                break;
            case Accuracy.Good:
                PlayRandomFromList(GoodAudioClip);
                break;
            case Accuracy.Perfect:
                PlayRandomFromList(PerfectAudioClip);
                break;
            case Accuracy.Completed:
                PlayRandomFromList(CompletedAudioClip);
                break;
        }
    }

    private void PlayRandomFromList(AudioClip[] list)
    {
        int index = UnityEngine.Random.Range(0, list.Length);
        Source.clip = list[index];
        Source.Play();
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
