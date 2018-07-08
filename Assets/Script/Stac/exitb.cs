using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitb : MonoBehaviour {

    public GameObject mid;
    public GameObject tutorial;

    public GameObject dictionary_popup;
    public GameObject Map;
    public GameObject monster;
    public GameObject Rune;
    public GameObject berserker_ex_popup;
    public GameObject Popup;
    public GameObject till;

    public void adad()
    {
        Popup.SetActive(false);
        Singleton.getInstance.GameMode = true;
        Singleton.getInstance.CreditPopup_open = false;
    }
    public void explainPopupExit(int i)
    {
        switch(i)
        {
            case 1:
                Singleton.getInstance.GameMode = false;
                berserker_ex_popup.SetActive(true);
                break;
            case 2:
                Singleton.getInstance.GameMode = true;
                berserker_ex_popup.SetActive(false);
                break;
        }
    }
    public void Dictionary_popup()
    {
        till.SetActive(true);
        mid.transform.localPosition = new Vector3(-20, 2.2f, 0);
        dictionary_popup.SetActive(false);
        Rune.SetActive(false);
        Map.SetActive(true);
        monster.SetActive(false);
        Singleton.getInstance.GameMode = true;
    }
    public void back_b()
    {
        monster.SetActive(false);
    }
    public void exitbds()
    {
        Singleton.getInstance.untouched = false;
        tutorial.SetActive(false);
        Singleton.getInstance.GameMode = true;
    }
}
