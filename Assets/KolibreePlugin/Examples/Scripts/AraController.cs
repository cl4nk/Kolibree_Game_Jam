using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace KolibreeExamples
{
    using ToothbrushResult = PluginEventListener.ToothbrushResult;

    public class AraController : MonoBehaviour
    {
        public VerticalLayoutGroup UIAraScanResultLayout;
        public Text UIAraConnectionStateText;
        public GameObject UIAraResultTemplate;

        public UnityEvent UIEventOnTBConnection;
        public UnityEvent UIEventOnTBDisconnection;

        private Dictionary<string, GameObject> ButtonsByMacAdress = new Dictionary<string, GameObject>();

        #region UnityCallbacks
        void Awake()
        {
            if (UIAraConnectionStateText != null)
            {
                UIAraConnectionStateText.text = "AraConnectionState - Disconnected";
            }
        }

        void OnEnable()
        {
            // Subscribe to this event to receive scan results
            AraDeviceHandler.OnAraScanUpdate += OnAraScanUpdateHandler;
            // Subscribe to this event to be notify when the toothbrush is connected
            AraDeviceHandler.OnAraConnected += OnAraConnectedHandler;
            // Subscribe to this event to be notify when the toothbrush is disconnected
            AraDeviceHandler.OnAraDisconnected += OnAraDisconnectedHandler;
        }

        void OnDisable()
        {
            AraDeviceHandler.OnAraScanUpdate -= OnAraScanUpdateHandler;
            AraDeviceHandler.OnAraConnected -= OnAraConnectedHandler;
            AraDeviceHandler.OnAraDisconnected -= OnAraDisconnectedHandler;
        }
        #endregion

        #region Handlers
        void OnAraScanUpdateHandler(List<ToothbrushResult> Devices)
        {
            foreach (ToothbrushResult Result in Devices)
            {
                if (!ButtonsByMacAdress.ContainsKey(Result.MacAdress))
                {
                    GameObject instance = CreateAraDeviceButton(Result);

                    if (instance != null)
                        ButtonsByMacAdress.Add(Result.MacAdress, instance);
                }
            }
        }

        void OnAraConnectedHandler()
        {
            if (UIAraConnectionStateText != null)
            {
                UIAraConnectionStateText.text = "AraConnectionState - Connected"; 
            }

            UIEventOnTBConnection.Invoke();

            AraDeviceHandler.OnAraScanUpdate -= OnAraScanUpdateHandler;
        }

        void OnAraDisconnectedHandler()
        {
            if (UIAraConnectionStateText != null)
            {
                UIAraConnectionStateText.text = "AraConnectionState - Disconnected";
            }

            UIEventOnTBDisconnection.Invoke();

            AraDeviceHandler.OnAraScanUpdate += OnAraScanUpdateHandler;

            // Just to be sure we don't miss some devices
            OnAraScanUpdateHandler(AraDeviceHandler.Instance.AllScannedDevices);
            AraDeviceHandler.Instance.StartScan();
        }
        #endregion

        #region PublicCallbacks
        public void DisconnectToothbrush()
        {
            AraDeviceHandler.Instance.DisconnectFromToothbrush();
        }

        public void StopToothbrushVibrator()
        {
            AraDeviceHandler.Instance.StopToothbrush();
        }
        #endregion

        #region PrivateMethods
        private GameObject CreateAraDeviceButton(ToothbrushResult Device)
        {
            if (UIAraScanResultLayout == null)
            {
                Debug.LogError("Can't display Ara's results without a valid VerticalLayoutGroup");
                return null;
            }

            GameObject buttonObject = Instantiate(UIAraResultTemplate, UIAraScanResultLayout.transform);

            buttonObject.DoWithComponentInChildren((Text Content) =>
            {
                Content.text = Device.Name + " (" + Device.MacAdress + ")";
            });

            buttonObject.DoWithComponent((Button ButtonComponent) =>
            {
                ButtonComponent.onClick.AddListener(() =>
                {
                    AraDeviceHandler.Instance.LaunchConnection(Device);
                });
            });

            return buttonObject;
        }
        #endregion
    }
}