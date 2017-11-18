using System;
using UnityEngine;
using UnityEngine.Events;

public class AraDeviceHandlerSimulator : Singleton<AraDeviceHandlerSimulator> {

    public static event UnityAction<AraToothbrushZone> OnAraDetectedZone;

    private void OnEnable()
    {
        AraDeviceHandler.OnAraDetectedZone += this.AraDeviceHandler_OnAraDetectedZone;
    }

    private void OnDisable()
    {
        AraDeviceHandler.OnAraDetectedZone -= this.AraDeviceHandler_OnAraDetectedZone;
    }

    private void AraDeviceHandler_OnAraDetectedZone(AraToothbrushZone arg0)
    {
        OnAraDetectedZone.Invoke(arg0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            OnAraDetectedZone.Invoke((AraToothbrushZone) 1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            OnAraDetectedZone.Invoke((AraToothbrushZone) 2);
        }
        else if(Input.GetKeyDown(KeyCode.Keypad3))
        {
            OnAraDetectedZone.Invoke((AraToothbrushZone) 3);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            OnAraDetectedZone.Invoke((AraToothbrushZone) 4);
        }
        else if(Input.GetKeyDown(KeyCode.Keypad5))
        {
            OnAraDetectedZone.Invoke((AraToothbrushZone) 5);
        } else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            OnAraDetectedZone.Invoke((AraToothbrushZone) 6);
        }

    }

}
