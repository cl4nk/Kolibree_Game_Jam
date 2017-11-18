using UnityEngine;
using UnityEngine.Events;

public class AraDeviceHandlerSimulator : Singleton<AraDeviceHandlerSimulator> {

    public static event UnityAction<AraToothbrushZone> OnAraDetectedZone;

    private void OnEnable()
    {
        AraDeviceHandlerSimulator.OnAraDetectedZone += this.AraDeviceHandler_OnAraDetectedZone;
        BindFakeInput();
    }

    private void OnDisable()
    {
        AraDeviceHandlerSimulator.OnAraDetectedZone -= this.AraDeviceHandler_OnAraDetectedZone;

    }

    private void AraDeviceHandler_OnAraDetectedZone(AraToothbrushZone arg0)
    {
        OnAraDetectedZone.Invoke(arg0);
    }

    private void BindFakeInput()
    {

    }

}
