using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupbuttonManager : MonoBehaviour {

    public GameObject Camera;
    AudioSource As;

    public GameObject PausePopup;
    bool OnOff = true;

    public GameObject SoundOnOff_gb;
    Image SoundOnoff_i;

    public Sprite SoundOn_i;
    public Sprite SoundOff_i;

    public GameObject Credit_gb;

	void Awake () {
        As = Camera.GetComponent<AudioSource>();
        SoundOnoff_i = SoundOnOff_gb.GetComponent<Image>();
    }

    public void PopupButtonON()
    {
        Singleton.getInstance.GameMode = false;
        Singleton.getInstance.PausePopup_open = true;
        PausePopup.SetActive(true);
    }
    public void PopupButtons(int i)
    {
        Debug.Log(Singleton.getInstance.Popup_open);

        switch (i)  
        {
            case 1:
                Singleton.getInstance.PausePopup_open = false;
                Singleton.getInstance.GameMode = true;
                PausePopup.SetActive(false);
                break;
            case 2:
                if(Singleton.getInstance.CreditPopup_open == false)
                {
                    PausePopup.SetActive(false);
                    Singleton.getInstance.PausePopup_open = true;
                    Singleton.getInstance.CreditPopup_open = true;
                    Credit_gb.SetActive(true);
                }
                else
                {
                    Singleton.getInstance.CreditPopup_open = false;
                    Credit_gb.SetActive(false);
                }
                break;
            case 3:
                if (OnOff == true)
                {
                    SoundOnOff(true);
                    SoundOnoff_i.sprite = SoundOff_i;
                }
                else if (OnOff == false)
                {
                    SoundOnOff(false);
                    SoundOnoff_i.sprite = SoundOn_i;
                }
                break;
            case 4:
                Application.Quit();
                break;
        }
    }
    public void SoundOnOff(bool on)
    {
        Debug.Log(on);

        if (on == true) {
            As.Pause();
            OnOff = false; }
        else if (on == false) {
            As.UnPause();
            OnOff = true; }
    }
}
