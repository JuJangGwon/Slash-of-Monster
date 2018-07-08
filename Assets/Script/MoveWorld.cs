using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWorld : MonoBehaviour {

    public GameObject pos;

    public GameObject goinanis_popup;
    public GameObject goworldtree_popup;
    public GameObject Canvas;

    public GameObject Inanis_worldmap;
    public GameObject Wolrd_map;

    Ingame ingame_cs;
    void Awake()
    {
        ingame_cs = Canvas.GetComponent<Ingame>();
    }

    public void PlusMins(int i)
    {
        if(i == 1)
        {
            Wolrd_map.SetActive(true);
            pos.transform.localPosition = new Vector3(-24.6f, 0.2f, 0);
        }
        else if(i== 2)
        {
            Wolrd_map.SetActive(false);
            pos.transform.localPosition = new Vector3(24, 0.2f, 0);
        }
    }
    public void MoveMap(int i)
    {
        switch(i)
        {
            case 1:     // 월드맵
                if (Singleton.getInstance.EnableWorld[0] == 1)
                {
                    goworldtree_popup.SetActive(true);
                }
                break;
            case 2:     // 이나니스
                if (Singleton.getInstance.EnableWorld[1] == 1)
                {
                    goinanis_popup.SetActive(true);
                }
                break;
            case 3:     // 프리미그
                if (Singleton.getInstance.EnableWorld[2] == 1)
                {

                }
                break;
            case 4:     // 헬라 
                if (Singleton.getInstance.EnableWorld[3] == 1)
                {

                }
                break;
            case 5:     // 가미르
                if (Singleton.getInstance.EnableWorld[4] == 1)
                {

                }
                break;
            case 6:     // 마누스
                if (Singleton.getInstance.EnableWorld[5] == 1)
                {

                }
                break;
        }
    }
    public void Yes(int i)
    {
        switch(i)
        {
            case 1:
                goworldtree_popup.SetActive(false);
                Singleton.getInstance.stage = 999;
                ingame_cs.ChangeMap(Singleton.getInstance.stage);
                break;
            case 2:
                Singleton.getInstance.myworld = World.Inanis;
                goinanis_popup.SetActive(false);
                Wolrd_map.SetActive(false);
                Inanis_worldmap.SetActive(true);
                pos.transform.localPosition = new Vector3(24, 0.2f, 0);
                break;
        }
    }
    public void No(int i)
    {
        switch (i)
        {
            case 1:
                goworldtree_popup.SetActive(false);
                break;
            case 2:
                goinanis_popup.SetActive(false);
                break;
        }
    }
}
