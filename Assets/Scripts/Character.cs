using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FXManager))]
public class Character : MonoBehaviour
{
    public GameObject frontGameObject;
    public GameObject backGameObject;

    public Sprite MainHintSprite;

    private bool _back = true;
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

    public void Awake()
    {
        Back = false;
        BrushRythmManager.Instance.OnBrushCompleted += this.Instance_OnBrushCompleted;
    }

    public void OnDestroy()
    {
        BrushRythmManager.Instance.OnBrushCompleted -= this.Instance_OnBrushCompleted;
    }

    private void Instance_OnBrushCompleted(BrushRythm rythm, AraToothbrushZone zone, Accuracy accuracy)
    {
        if (Back && GameManager.Instance.OrgasmJauge > 0.5f)
            Back = false;
    }

    public void UpdateState ()
    {
        if (frontGameObject)
            frontGameObject.gameObject.SetActive(!Back);
        if (backGameObject)
            backGameObject.gameObject.SetActive(Back);
    }
}
