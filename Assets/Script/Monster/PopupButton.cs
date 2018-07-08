using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupButton : MonoBehaviour
{
    public GameObject Rune_Gb;
    Rune rune_cs;
    public GameObject Boss_t;

    public GameObject Popup;
    public GameObject border;
    public GameObject Upper_Map;
    public GameObject Upper_Rune;

    public Sprite[] lower_explain_map = new Sprite[7];

    public GameObject[] borders = new GameObject[5];

    public GameObject[] Popup_button = new GameObject[5];
    Image[] Popup_button_sp = new Image[5];

    public GameObject lowermap;
    Image lowerImage;
    public Sprite[] Popup_b_noneselected = new Sprite[5];
    public Sprite[] job_noneselected = new Sprite[3];
    public Sprite[] Popup_b_selected = new Sprite[5];
    public Sprite[] job_selected = new Sprite[3];
    

    Image border_I;
    void Awake()
    {
        rune_cs = Rune_Gb.GetComponent<Rune>();
        lowerImage = lowermap.GetComponent<Image>();
        Singleton.getInstance.i = 0;
        for (int i = 0; i < 5; i++)
            Popup_button_sp[i] = Popup_button[i].GetComponent<Image>();
    }

    public void CharacterSelect(int num)
    {
        switch(num)
        {
            case 1:
                Singleton.getInstance.Job = Job.Beserek;
                break;
            case 2:
                Singleton.getInstance.Job = Job.magician;
                break;
            case 3:
                Singleton.getInstance.Job = Job.shamen;
                break;
        }
    }
    public void a()
    {
        switch (Singleton.getInstance.MyPosition)
        {
            case Inanis_map.RedDesertRoad1:
                lowerImage.sprite = lower_explain_map[0];
                break;
            case Inanis_map.RedDesertRoad2:
                lowerImage.sprite = lower_explain_map[1];
                break;
            case Inanis_map.RedDesertRoad3:
                lowerImage.sprite = lower_explain_map[2];
                break;
            case Inanis_map.DepletedField1:
                lowerImage.sprite = lower_explain_map[3];
                break;
            case Inanis_map.DepletedField2:
                lowerImage.sprite = lower_explain_map[4];
                break;
            case Inanis_map.BarrenOasisEntrance:
                lowerImage.sprite = lower_explain_map[5];
                break;
            case Inanis_map.OasisEntrance:
                lowerImage.sprite = lower_explain_map[6];
                break;
        }

    }
    public void PopupButtons(int types)
    {
        Debug.Log(Singleton.getInstance.Popup_open);

        if(Singleton.getInstance.bossAlive == false)
        {
            if (Singleton.getInstance.untouched == true)
            {
                if (Singleton.getInstance.useCorutine == false)
                {
                    if (Singleton.getInstance.Popup_open == false)
                    {
                        Singleton.getInstance.GameState = GameState.showmenu;
                        Singleton.getInstance.Popup_open = true;
                        StartCoroutine(MoveCoroutine(new Vector2(0, 2), 0.8f));
                        Singleton.getInstance.GameMode = false;
                    }
                    if (Singleton.getInstance.i == types) SKs();
                    else
                    {
                        Singleton.getInstance.i = types;
                        Clear(types - 1);
                        Popup_button_sp[types - 1].sprite = Popup_b_selected[types - 1];
                        borders[types - 1].SetActive(true);
                        if (types == 3)
                        {
                            a();
                            Upper_Map.SetActive(true);
                            if (Singleton.getInstance.useCorutine == false) Upper_Map.transform.localPosition = new Vector3(0, 450, 0);
                            else StopCoroutine(MoveCoroutine2(new Vector2(0, 0), 0.8f, false));
                            StartCoroutine(MoveCoroutine2(new Vector2(0, 0), 0.8f, false));
                        }
                        if (types == 4)
                        {
                            Upper_Rune.SetActive(true);
                            rune_cs.ShowRunePage();
                        }
                    }
                }
            }
        }
        else
        {
            Boss_t.SetActive(true);
        }
    }
    IEnumerator MoveCoroutine(Vector2 endPos, float duration)
    {
        Singleton.getInstance.useCorutine = true;
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        Vector2 startPos = Popup.transform.localPosition;
        while (duration > 0.0f)
        {
    
            duration -= Time.deltaTime;
            Popup.transform.localPosition = Vector2.Lerp(Popup.transform.localPosition, endPos, Time.smoothDeltaTime * 7.5f);
            yield return waitForEndOfFrame;
        }
        Popup.transform.localPosition = endPos;
        Singleton.getInstance.useCorutine = false;
        yield return null;
    }
    IEnumerator MoveCoroutine2(Vector2 endPos, float duration,bool live)
    {
        Singleton.getInstance.Uppermap_useCorutine = true;
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        Vector2 startPos = Popup.transform.localPosition;
        while (duration > 0.0f)
        {
            duration -= Time.deltaTime;
            Upper_Map.transform.localPosition = Vector2.Lerp(Upper_Map.transform.localPosition, endPos, Time.smoothDeltaTime * 8.5f);
            yield return waitForEndOfFrame;
        }
        Upper_Map.transform.localPosition = endPos;
        Singleton.getInstance.Uppermap_useCorutine = false;
        if (live == true) Upper_Map.SetActive(false);
   
    }
    public void Clear(int num)
    {
        if (num != 6)
        {
            for (int i = 0; i < 5; i++) if (i != num) { Popup_button_sp[i].sprite = Popup_b_noneselected[i]; borders[i].SetActive(false); }
        }
        else
        {
            for (int i = 0; i < 5; i++) { Popup_button_sp[i].sprite = Popup_b_selected[i]; borders[i].SetActive(false); }
        }
        Upper_Rune.SetActive(false);
        if(Upper_Map.active == true)
        {
            if (Singleton.getInstance.Uppermap_useCorutine == true) StopCoroutine(MoveCoroutine2(new Vector2(0, 600),0.8f,true));
                StartCoroutine(MoveCoroutine2(new Vector2(0,600),0.8f,true));
        }
    }
    void SKs()
    {
        Singleton.getInstance.i = 0;
        StartCoroutine(MoveCoroutine(new Vector2(0, -500), 0.5f));
        Singleton.getInstance.Popup_open = false;
        Singleton.getInstance.GameMode = true;
        Singleton.getInstance.GameState = GameState.PlayNormal;
        Clear(6);
    }
}
