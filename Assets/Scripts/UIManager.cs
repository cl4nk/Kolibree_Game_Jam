using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Canvas titleCard;
    public Canvas startGame;
    public Canvas shopScreen;
    public Canvas optionScreen;
    public Canvas helpScreen;
    public Canvas creditScreen;

    public Button btnSoundOn;
    public Button btnSoundOff;
    public Button btnVibrationOn;
    public Button btnVibrationOff;

	// Use this for initialization
	void Start () {
        titleCard.enabled = true;
        startGame.enabled = false;
        shopScreen.enabled = false;
        optionScreen.enabled = false;
        helpScreen.enabled = false;
        creditScreen.enabled = false;

        if (PlayerPrefs.HasKey("volume"))
        {
            if (PlayerPrefs.GetFloat("volume") == 0)
            {
                activeButton(btnSoundOff);
                disableButton(btnSoundOn);
            }else if (PlayerPrefs.GetFloat("volume") == 1)
            {
                activeButton(btnSoundOn);
                disableButton(btnSoundOff);
            }
        }else
        {
            activeButton(btnSoundOn);
            disableButton(btnSoundOff);
        }

        if (PlayerPrefs.HasKey("vibration"))
        {
            if (PlayerPrefs.GetFloat("vibration") == 0)
            {
                activeButton(btnVibrationOff);
                disableButton(btnVibrationOn);
            }
            else if (PlayerPrefs.GetFloat("vibration") == 1)
            {
                activeButton(btnVibrationOn);
                disableButton(btnVibrationOff);
            }
        }
        else
        {
            activeButton(btnVibrationOn);
            disableButton(btnVibrationOff);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void openCanvas(Canvas pNewCanvas)
    {
        pNewCanvas.enabled = true;
    }

    public void closeCanvas(Canvas pActualCanvas)
    {
        pActualCanvas.enabled = false;
    }

    public void activeButton(Button pNewButton)
    {
        pNewButton.enabled = true;
        pNewButton.gameObject.SetActive(true);
    }

    public void disableButton(Button pActualButton)
    {
        pActualButton.enabled = false;
        pActualButton.gameObject.SetActive(false);
    }

    public void disableSound()
    {
        PlayerPrefs.SetFloat("volume", 0);
    }

    public void enableSound()
    {
        PlayerPrefs.SetFloat("volume", 1);
    }

    public void disableVibration()
    {
        PlayerPrefs.SetFloat("vibration", 0);
    }

    public void enableVibration()
    {
        PlayerPrefs.SetFloat("vibration", 1);
    }
}
