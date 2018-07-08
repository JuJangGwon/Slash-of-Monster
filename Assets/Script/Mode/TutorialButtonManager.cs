using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonManager : MonoBehaviour {

    public GameObject ssk;

    public void PopupOpen()
    {
        ssk.SetActive(true);
        Singleton.getInstance.GameMode = false;
        Singleton.getInstance.untouched = true;
    }
}
