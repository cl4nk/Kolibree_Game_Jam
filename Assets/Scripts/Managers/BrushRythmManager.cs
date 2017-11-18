using System;
using System.Collections.Generic;
using UnityEngine;

public class BrushRythmManager : Singleton<BrushRythmManager>
{
    private Dictionary<AraToothbrushZone, BrushRythm> brushRythmDictionnary = new Dictionary<AraToothbrushZone, BrushRythm>();

    public event Action<BrushRythm, AraToothbrushZone, Accuracy> OnBrushCompleted;

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
        AraDeviceHandlerSimulator.OnAraDetectedZone += this.AraDeviceHandler_OnAraDetectedZone;
    }

    public void OnDisable()
    {
        AraDeviceHandlerSimulator.OnAraDetectedZone -= this.AraDeviceHandler_OnAraDetectedZone;
    }

    public void Register (BrushRythm rythm)
    {
        brushRythmDictionnary.Add(rythm.Zone, rythm);
    }

    public void Unregister(BrushRythm rythm)
    {
        AraToothbrushZone zone = rythm.Zone;
        if (brushRythmDictionnary.ContainsKey(zone) && brushRythmDictionnary[zone] == rythm)
            brushRythmDictionnary.Remove(zone);
        else
            Debug.LogWarning("Rythm not found inside dictionnary");
    }

    private void AraDeviceHandler_OnAraDetectedZone(AraToothbrushZone zone)
    {
        if (brushRythmDictionnary.ContainsKey(zone))
        {
            OnBrushCompleted.Invoke(brushRythmDictionnary[zone], zone, brushRythmDictionnary[zone].OnBrushDetected());
        }
    }

    
}
