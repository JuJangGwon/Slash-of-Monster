using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcbutton : MonoBehaviour {

    public GameObject dkdk;
    public GameObject nkim;
    public GameObject Quest_pop;
    public GameObject npc;

    NpcScript npcscript;

    public void Awake()
    {
        npcscript = npc.GetComponent<NpcScript>();
    }


    public void aaa()
    {
        if (Singleton.getInstance.quest == Quest.none)
        {
            npcscript.go = true;
        }
        if (Singleton.getInstance.quest == Quest.finish)
        {
            dkdk.SetActive(true);
        }
    }
    public void bbb()
    {
        Singleton.getInstance.quest = Quest.going;
        PlayerPrefs.SetInt("Quest", 1);
        PlayerPrefs.Save();
        Quest_pop.SetActive(false);
        nkim.SetActive(false);
    }
    public void ccc()
    {
        Quest_pop.SetActive(false);
    }
}
