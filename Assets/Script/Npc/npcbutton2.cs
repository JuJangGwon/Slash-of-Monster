using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcbutton2 : MonoBehaviour
{
    public GameObject gb;
    public GameObject mul;

    public void sksks()
    {
        mul.SetActive(false);
        Singleton.getInstance.quest = Quest.fd;
        PlayerPrefs.SetInt("Quest",3);
        Singleton.getInstance.money += 2000;
        Rune.possess_Rune.Add(RuneType.fire);
        gb.SetActive(false);
    }
}
