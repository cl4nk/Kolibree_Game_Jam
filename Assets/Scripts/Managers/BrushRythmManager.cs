using System;
using System.Collections.Generic;
using UnityEngine;

public class BrushRythmManager : Singleton<BrushRythmManager>
{
    private Dictionary<AraToothbrushZone, BrushRythm> brushRythmDictionnary;

    public event Action<AraToothbrushZone, Accuracy> OnBrushCompleted;

    public float PercentRythmCompleted
    {
        get
        {
            float result = 0.0f;

            foreach (var pairs in brushRythmDictionnary)
            {
                result += pairs.Value.PercentCompleted;
            }
            return result;
        }
    }

    public void OnEnable()
    {
        AraDeviceHandler.OnAraDetectedZone += this.AraDeviceHandler_OnAraDetectedZone;
    }

    public void OnDisable()
    {
        AraDeviceHandler.OnAraDetectedZone -= this.AraDeviceHandler_OnAraDetectedZone;
    }

    public void InitRythms(List<AraToothbrushRythm> rythmList)
    {
        brushRythmDictionnary.Clear();

        foreach (AraToothbrushRythm rythm in rythmList)
        {
            if (brushRythmDictionnary.ContainsKey(rythm.Zone))
                Debug.LogWarning("Zone already have a rythm connected");
            else
                brushRythmDictionnary.Add(rythm.Zone, rythm.Rythm);
        }
    }

    private void AraDeviceHandler_OnAraDetectedZone(AraToothbrushZone zone)
    {
        if (brushRythmDictionnary.ContainsKey(zone))
        {
            OnBrushCompleted.Invoke(zone, brushRythmDictionnary[zone].OnBrushDetected());
        }
    }

    
}
