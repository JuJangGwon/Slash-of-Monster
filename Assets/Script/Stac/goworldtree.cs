using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goworldtree : MonoBehaviour {

    public GameObject Canvas;
    public GameObject worldmap;
    public GameObject popup;
    public GameObject sk;

    Ingame ingame_cs;

    void Awake()
    {
        ingame_cs = Canvas.GetComponent<Ingame>();
    }
    public void akaka()
    {
        sk.SetActive(true);
        Singleton.getInstance.quest = Quest.finish;
        popup.SetActive(false);
        Singleton.getInstance.stage = 999;
        ingame_cs.ChangeMap(Singleton.getInstance.stage);
        worldmap.SetActive(true);
    }

}
