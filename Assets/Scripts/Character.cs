using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject frontGameObject;
    public GameObject backGameObject;
    public FXManager fxGameObject;
    public List<AraToothbrushRythm> frontRythm;
    public List<AraToothbrushRythm> backRythm;

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

    private void Instance_OnBrushCompleted(AraToothbrushZone zone, Accuracy accuracy)
    {
        if (Back && GameManager.Instance.OrgasmJauge > 0.5f)
            Back = false;
    }

    public void UpdateState ()
    {
        BrushRythmManager.Instance.InitRythms(Back ? backRythm : frontRythm);
        frontGameObject.gameObject.SetActive(!Back);
        backGameObject.gameObject.SetActive(Back);
    }
}
