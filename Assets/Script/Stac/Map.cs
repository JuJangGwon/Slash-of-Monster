using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour {

    public GameObject WorldMap_MyPos;

    public GameObject Volcano_Map;
    public GameObject ice_cavage;
    public GameObject inanis;

    public GameObject MyPosition_greenIcon;
    enum map
    {
        volcano,
        balhala,
        inanis
    }
    public Sprite black_icon;
    public Sprite green_icon;
    public Sprite yellow_icon;
    public GameObject boss_icon;

    public GameObject button;
    public GameObject[] Volcano_Use_icon_inField = new GameObject[8];
    Image[] Volcano_Use_icon_inFeild_image = new Image[8];

    List<Vector3> marble_pos = new List<Vector3>();
    List<Vector3> WorldMarble_pos = new List<Vector3>();
    bool[] marble = new bool[8];
    map maps;

    void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            marble[i] = false;
            Volcano_Use_icon_inFeild_image[i] = Volcano_Use_icon_inField[i].GetComponent<Image>();
        }
        marble[0] = true;
        marble_pos.Add(new Vector3(-177,-37,-2));
        marble_pos.Add(new Vector3(-64, 72, -2));
        marble_pos.Add(new Vector3(119, 90, -2));
        marble_pos.Add(new Vector3(257, -18, -2));
        marble_pos.Add(new Vector3(167, -186, -2));
        marble_pos.Add(new Vector3(-74, -170, -2));
        marble_pos.Add(new Vector3(22, -27, -2));


        marble_pos.Add(new Vector3(-233, 1.5f, 0));
        marble_pos.Add(new Vector3(-144, -18, 0));
        marble_pos.Add(new Vector3(-50, 49, 0));
        marble_pos.Add(new Vector3(36, 12, 0));
        marble_pos.Add(new Vector3(-82, -138, 0));
        marble_pos.Add(new Vector3(106, -52, 0));

        WorldMarble_pos.Add(new Vector3(6,-36,0));
        WorldMarble_pos.Add(new Vector3(168, -39.5f, 0));
        WorldMarble_pos.Add(new Vector3(35.7f, 63.7f, 0));
        WorldMarble_pos.Add(new Vector3(-66.8f, 29.8f, 0));
        WorldMarble_pos.Add(new Vector3(-68, -52, 0));
        WorldMarble_pos.Add(new Vector3(27.4f, -135.2f, 0));

    }
    public void Start()
    {
        Check_MyPosition();
    }
    void Check_MyPosition()
    {
        Debug.Log("입장");
        // 월드맵 //
        WorldMap_MyPos.transform.localPosition = WorldMarble_pos[(int)Singleton.getInstance.myworld];

        //
        //MyPosition_greenIcon.transform.localPosition = new Vector3(marble_pos[Singleton.getInstance.stage-1].x,marble_pos[Singleton.getInstance.stage-1].y+301,0);
    }
    void Volcano_initialization()
    {
        if (Singleton.getInstance.stage == Singleton.getInstance.EnableStage)
        {
            Singleton.getInstance.EnableStage++;
            marble[Singleton.getInstance.EnableStage - 1] = true;
        }
        if (marble[Singleton.getInstance.EnableStage-1] == false) marble[Singleton.getInstance.EnableStage-1] = true;
        for (int i = 0; i<5; i++)
        {
            if (marble[i] == false) Volcano_Use_icon_inFeild_image[i].sprite = black_icon;
            else if (marble[i] == true) Volcano_Use_icon_inFeild_image[i].sprite = yellow_icon;
        }
    }
}
