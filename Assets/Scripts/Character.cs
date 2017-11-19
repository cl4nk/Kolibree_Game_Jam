using System.Collections.Generic;
using UnityEngine;

public enum CharacterEmotion
{
    Normal,
    Happy,
    Orgasm,
    Frustrated
}

[RequireComponent(typeof(FXManager))]
public class Character : MonoBehaviour
{
    public GameObject frontGameObject;
    public GameObject backGameObject;

    public Sprite MainHintSprite;

    private bool _back = false;
    public bool Back
    {
        get { return _back; }
        set
        {
            if (_back == value)
                return;
            _back = value;
            UpdateState();
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

    public void Awake()
    {
        Back = true;
    }

    private void Instance_OnBrushCompleted(BrushRythm rythm,  Accuracy accuracy)
    {
        if (Back && GameManager.Instance.OrgasmJauge > 0.5f)
            Back = false;
    }

    public void UpdateState ()
    {
        frontGameObject.gameObject.SetActive(!Back);
        backGameObject.gameObject.SetActive(Back);
    }
}
