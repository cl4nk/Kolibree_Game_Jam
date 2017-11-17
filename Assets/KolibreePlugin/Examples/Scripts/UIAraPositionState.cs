using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KolibreeExamples
{
    [RequireComponent(typeof(Text))]
    public class UIAraPositionState : MonoBehaviour
    {
        #region UnityEvents
        void Awake()
        {
            this.DoWithComponent((Text TextComponent) =>
            {
                TextComponent.text = "Position - None";
            });
        }

        void OnEnable()
        {
            AraDeviceHandler.OnAraRawDetectedZone += OnAraRawDetectedZoneHandler;
        }

        void OnDisable()
        {
            AraDeviceHandler.OnAraRawDetectedZone -= OnAraRawDetectedZoneHandler;
        }
        #endregion

        #region Handlers
        void OnAraRawDetectedZoneHandler(List<AraToothbrushZone> Zones)
        {
            this.DoWithComponent((Text TextComponent) =>
            {
                // Zones is sort by probabilties ( descending order ) Zones[0] > Zones[X]
                TextComponent.text = "Position - " + Zones[0];
            });
        }
        #endregion
    }
}