using UnityEngine;
using UnityEngine.UI;

namespace KolibreeExamples
{
    [RequireComponent(typeof(Text))]
    public class UIAraVibratorState : MonoBehaviour
    {
        #region UnityEvents
        void Awake()
        {
            this.DoWithComponent((Text TextComponent) =>
            {
                TextComponent.text = "Vibrator - Off";
            });
        }

        void OnEnable()
        {
            AraDeviceHandler.OnAraStartRunning += OnAraStartRunningHandler;
            AraDeviceHandler.OnAraStopRunning += OnAraStopRunningHandler;
        }

        void OnDisable()
        {
            AraDeviceHandler.OnAraStartRunning -= OnAraStartRunningHandler;
            AraDeviceHandler.OnAraStopRunning -= OnAraStopRunningHandler;
        }
        #endregion

        #region Handlers
        void OnAraStartRunningHandler()
        {
            this.DoWithComponent((Text TextComponent) =>
            {
                TextComponent.text = "Vibrator - On";
            });
        }

        void OnAraStopRunningHandler()
        {
            this.DoWithComponent((Text TextComponent) =>
            {
                TextComponent.text = "Vibrator - Off";
            });
        }
        #endregion
    }
}