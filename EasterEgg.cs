using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEgg : MonoBehaviour
{
    public GameObject GUIPanel;
    public GameObject muteButton;
    public Sprite[] buttonImage;

    private string cheatcode = "";
    private const int MUTE = 0;
    private const int UNMUTE = 1;

	void Update ()
    {
        cheatcodeCapturing();
    }

    private void cheatcodeCapturing()
    {
        if (Input.GetKeyDown(KeyCode.E))
            cheatcode = "E";
        else if (Input.GetKeyDown(KeyCode.T) && cheatcode == "E")
            cheatcode = "ET";
        else if (Input.GetKeyDown(KeyCode.U) && cheatcode == "ET")
            cheatcode = "ETU";
        else if (cheatcode == "ETU")
        {
            GUIPanel.GetComponent<AudioSource>().Play();
            cheatcode = "";
            muteButton.SetActive(true);
        }
        else if (cheatcode.Length >= 3)
            cheatcode = "";       
    }

    public void MuteButton()
    {
        if(!GUIPanel.GetComponent<AudioSource>().mute)
        {
            GUIPanel.GetComponent<AudioSource>().mute = true;
            muteButton.GetComponent<Image>().sprite = buttonImage[UNMUTE];
        }
        else
        {
            GUIPanel.GetComponent<AudioSource>().mute = false;
            muteButton.GetComponent<Image>().sprite = buttonImage[MUTE];
        }
    }
}
