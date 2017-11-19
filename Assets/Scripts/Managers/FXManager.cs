using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FXManager : Singleton<FXManager>
{
    public float SpeakChance = 0.1f;
    public string[] ExcitedStringList;
    public string[] NormalStringList;
    public string[] FrustratedStringList;

    public GameObject systemeParticles;

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

    public void Start()
    {
        systemeParticles = GameObject.Find("EmitterParticule");
    }

    public void OnEnable()
    {
        BrushRythmManager.Instance.OnBrushCompleted += this.Instance_OnBrushCompleted;
    }

    public void OnDisable()
    {
        BrushRythmManager.Instance.OnBrushCompleted -= this.Instance_OnBrushCompleted;
    }

    private void Instance_OnBrushCompleted(BrushRythm rythm, Accuracy accuracy)
    {

        if (UnityEngine.Random.value < SpeakChance)
            Speak(rythm, accuracy);
    }

    private void Speak(BrushRythm rythm, Accuracy accuracy)
    {
        GameObject lParticle = Instantiate(systemeParticles, rythm.transform);
        lParticle.GetComponent<ParticulesEmitters>().EmitParticule(accuracy);
    }

    private void SpeakRandomFromList(string[] list)
    {
        int index = UnityEngine.Random.Range(0, list.Length);
        OnCharacterSpeak.Invoke(list[index]);
    }
}
