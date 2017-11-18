using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputAra : MonoBehaviour {

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
        MobileDebugView.LogInfo("Zone Detected !!! " + arg0.ToString());
    }
}
