using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMap : MonoBehaviour {

    public GameObject Button;
    PopupButton popupbutton_cs;
    public GameObject Canvas;
    Ingame Ingame_sc;

    public GameObject Text1;
    public GameObject Text2;
    Text text1;
    Text text2;

    void Awake()
    {
        popupbutton_cs = Button.GetComponent<PopupButton>();
        text1 = Text1.GetComponent<Text>();
        text2 = Text2.GetComponent<Text>();
        Ingame_sc = Canvas.GetComponent<Ingame>();
    }
    public void MoveMaps(int i)
    {
    //  if (i <= Singleton.getInstance.EnableStage+1)
        {
            // 불타는 산 //
            Debug.Log("f");
            Ingame_sc.ChangeMap(i);
            Debug.Log("fd");
            switch(i)
            {
                case 1:
                    Singleton.getInstance.MyPosition = Inanis_map.BarrenOasisEntrance;
                    Singleton.getInstance.myworld = World.Inanis;
                    break;
                case 2:
                    Singleton.getInstance.MyPosition = Inanis_map.DepletedField2;
                    Singleton.getInstance.myworld = World.Inanis;
                    break;
                case 3:
                    Singleton.getInstance.MyPosition = Inanis_map.DepletedField1;
                    Singleton.getInstance.myworld = World.Inanis;
                    break;
                case 4:
                    Singleton.getInstance.MyPosition = Inanis_map.RedDesertRoad3;
                    Singleton.getInstance.myworld = World.Inanis;
                    break;
                case 5:
                    Singleton.getInstance.MyPosition = Inanis_map.RedDesertRoad2;
                    Singleton.getInstance.myworld = World.Inanis;
                    break;
                case 6:
                    Singleton.getInstance.MyPosition = Inanis_map.RedDesertRoad1;
                    Singleton.getInstance.myworld = World.Inanis;
                    break;
                case 7:
                    Singleton.getInstance.MyPosition = Inanis_map.OasisEntrance;
                    Singleton.getInstance.myworld = World.Inanis;
                    break;
            }
            popupbutton_cs.a();
        }
    }
}