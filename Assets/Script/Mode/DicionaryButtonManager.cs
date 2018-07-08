using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicionaryButtonManager : MonoBehaviour
{
    public GameObject Dictionary;

    public GameObject Point;
    public GameObject Inanis;
    public GameObject leftRightButton;
    public GameObject Runes;
    public GameObject Maps;

    public void InanisButton()
    {
        Inanis.SetActive(true);
        leftRightButton.SetActive(false);
    }

    public void DriectionButton(int i)
    {
        switch(i)
        {
            case 1: // 왼쪽
                Point.transform.localPosition = new Vector3(-20, -2, 0);
                Runes.SetActive(false);
                Maps.SetActive(true);
                break;
            case 2: // 오른쪽
                Point.transform.localPosition = new Vector3(20, -2, 0);
                Runes.SetActive(true);
                Maps.SetActive(false);
                break;
                
        }
    }
    public void On()
    {
        if (Singleton.getInstance.Popup_open == false || Singleton.getInstance.PausePopup_open == false)
        {
            Singleton.getInstance.GameMode = false;
            Dictionary.SetActive(true);
        }
    }
}
