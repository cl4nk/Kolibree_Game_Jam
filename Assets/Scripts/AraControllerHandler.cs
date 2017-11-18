using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AraControllerHandler : Singleton<AraControllerHandler>
{
    public int LobbyIndex = 0;
    public int MainMenuIndex = 1;

    private void OnEnable()
    {
        AraDeviceHandler.OnAraConnected += this.AraDeviceHandler_OnAraConnected;
        AraDeviceHandler.OnAraDisconnected += this.AraDeviceHandler_OnAraDisconnected;
    }

    private void OnDisable()
    {
        AraDeviceHandler.OnAraConnected -= this.AraDeviceHandler_OnAraConnected;
        AraDeviceHandler.OnAraDisconnected -= this.AraDeviceHandler_OnAraDisconnected;
    }

    private void AraDeviceHandler_OnAraConnected()
    {
        SceneManager.LoadScene(MainMenuIndex);
    }

    private void AraDeviceHandler_OnAraDisconnected()
    {
        SceneManager.LoadScene(LobbyIndex);
    }
}
