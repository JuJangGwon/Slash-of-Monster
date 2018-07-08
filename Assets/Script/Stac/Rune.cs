using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RuneType
{
   none = -1,
   blue,
   purple,
   red,
   yellow,
   wind,
   fire,
   ground,
   water,
   blue2,
   purple2,
   red2,
   yellow2
}


public class Rune : MonoBehaviour {

    public int page = 1;
    public GameObject runeborder;
    public GameObject Rune_text_parents;


    public GameObject Gameobejct_pf;
    public GameObject[] ShowUseRune = new GameObject[5];
    public GameObject[] RunePrefebs = new GameObject[8];
    public GameObject ShowUseBigRune;

    public GameObject[] RuneEquipText_pf = new GameObject[8];

    public static List<RuneType> possess_Rune = new List<RuneType>();
    public static List<GameObject> possess_Rune_gb = new List<GameObject>();
    public static RuneType[] UsesmallRune = new RuneType[5];
    public static RuneType UseBigRune = RuneType.none;
    public static GameObject Upper_Rune;

    private GameObject Selected_rune_gb;

    GameObject RuneParents;
    int Wheres = -1;
    int UpWheres = -1;
    Vector2 OriginPos;
    bool SelectedRune = false;

    void RuneEffect()
    {
        int money = 0;
        int Power = 0;
        int cooltime = 0;
        int critical = 0;
        for (int i = 0; i < 5; i++)
        {
            if(UsesmallRune[i] == RuneType.yellow)
            {
                money += 5;
            }
            else if (UsesmallRune[i] == RuneType.yellow2)
            {
                money += 10;
            }
            else if(UsesmallRune[i] == RuneType.red)
            {
                Power += 5;
            }
            else if (UsesmallRune[i] == RuneType.red2)
            {
                Power += 10;
            }
            if (UsesmallRune[i] == RuneType.blue)
            {
                cooltime += 5;
            }
            else if (UsesmallRune[i] == RuneType.blue2)
            {
                cooltime += 10;
            }
            else if (UsesmallRune[i] == RuneType.purple)
            {
                critical += 5;
            }
            else if (UsesmallRune[i] == RuneType.purple2)
            {
                critical += 10;
            }
            Singleton.getInstance.RuneEffect_attack_percent = Power;
            Singleton.getInstance.RuneEffect_cooltime_percent = cooltime;
            Singleton.getInstance.RuneEffect_money_percent = money;
            Singleton.getInstance.RuneEffect_criticial_percent = critical;
        }

    }
    void Awake()
    {
        Rune.possess_Rune.Add(RuneType.blue);
     
        for (int i = 0; i < 5; i++)
        {
            UsesmallRune[i] = RuneType.none;
        }
  
        ShowRunePage();
        RuneEffect();
    }
    public void ShowRunePage()
    {
        for(int i =0; i<5; i++)
        {
           if(ShowUseRune[i] != null)
            {
                Destroy(ShowUseRune[i]);
            }
        }
        if(RuneParents != null)
        {
           Destroy(RuneParents);
           possess_Rune_gb.Clear();
        }
           RuneParents = Instantiate(Gameobejct_pf);
           RuneParents.transform.SetParent(runeborder.transform);
           RuneParents.transform.localScale = new Vector3(1, 1, 1);
           RuneParents.transform.localPosition = new Vector3(0, 0, 0);
        
        Debug.Log(possess_Rune.Count);

        if (possess_Rune.Count > 0)
        {
            for (int i = (page-1)*9; i < (page * 9); i++)
            {
               if (i >= possess_Rune.Count) break;
               if (possess_Rune[i] != RuneType.none)
               {
                   GameObject gb = Instantiate(RunePrefebs[(int)possess_Rune[i]]);
                   gb.transform.SetParent(RuneParents.transform);
                   gb.transform.localPosition = new Vector3(-173 + (((i %9)% 3) * +178), 170 + ((i%9) / 3 * -170), 0);
                   if ((int)possess_Rune[i] < 4) gb.transform.localScale = new Vector3(1.2f, 1.2f, 1);
                   else if ((int)possess_Rune[i] < 8) gb.transform.localScale = new Vector3(0.9f, 0.9f, 1);
                   else gb.transform.localScale = new Vector3(1.2f, 1.2f, 1);

                   possess_Rune_gb.Add(gb);
               }
            }
        }
       for (int i = 0; i < 5; i++)
       {
           if (UsesmallRune[i] == RuneType.none)
           {
               ShowUseRune[i] = Instantiate(RunePrefebs[0]);
               ShowUseRune[i].SetActive(false);
           }
           else
           {
               ShowUseRune[i] = Instantiate(RunePrefebs[(int)UsesmallRune[i]]);
           }
           ShowUseRune[i].transform.SetParent(transform);
           ShowUseRune[i].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
           switch (i)
           {
               case 0:
                   ShowUseRune[i].transform.localPosition = new Vector3(0, 473, -1);
                   break;
               case 1:
                   ShowUseRune[i].transform.localPosition = new Vector3(168, 358, -1);
                   break;
               case 2:
                   ShowUseRune[i].transform.localPosition = new Vector3(105, 150, -1);
                   break;
               case 3:
                   ShowUseRune[i].transform.localPosition = new Vector3(-115, 150, -1);
                   break;
               case 4:
                   ShowUseRune[i].transform.localPosition = new Vector3(-168, 356, -1);
                   break;
           }
       }
    }
    void Update()
    {
        if (Singleton.getInstance.GameMode == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
                if (hit.collider != null)
                {
                    Debug.Log(hit.transform.localPosition);
                    if (hit.collider.tag == "Rune")
                    {
                        FirstTouch(hit.transform.localPosition);
                        SelectedRune = true;
                    }
                }
            }
            //if (SelectedRune == true)
            //{
            //    if (Input.GetMouseButton(0))
            //    {
            //        Selected_rune_gb.transform.localPosition = Input.mousePosition + new Vector3(360, 640, 0);
            //    }
            //    if (Input.GetMouseButtonUp(0))
            //    {
            //        SelectedRune = false;
            //      //  PutRuneAndPositionCheck(Input.mousePosition);
            //    }
            //}
        }
    }
    void FirstTouch(Vector2 StartMousePos)
    {
        int Ypos = 0;
        int Xpos = 0;
        // y 
        if (StartMousePos.y == 170) Ypos = 1;
        else if (StartMousePos.y == 0) Ypos = 2;
        else if (StartMousePos.y == -170) Ypos = 3;
        // x 
        if (StartMousePos.x == -173) Xpos = 1;
        else if (StartMousePos.x == 5) Xpos = 2;
        else if (StartMousePos.x == 183) Xpos = 3;

        if (Ypos != 0 && Xpos != 0)
        {
            Debug.Log(Xpos);
            int Ad = (Ypos - 1) * 3 + (Xpos - 1);
            Debug.Log(Wheres);
            Debug.Log(Ad);
            if (Wheres == Ad) Equip(Wheres);
            else
            {
                Wheres = (Ypos - 1) * 3 + (Xpos - 1);
            }
        }
        //720 - 485// 235
        if (StartMousePos.y > 149)
        {
            int b = 0;
            if (StartMousePos.x == 0 && StartMousePos.y ==473)
            {
                b = 1;
            }
            else if (StartMousePos.x == 168 && StartMousePos.y == 358)
            {
                b = 2;
            }
            else if (StartMousePos.x == 105 && StartMousePos.y == 150)
            {
                b = 3;
            }
            else if (StartMousePos.x == -115 && StartMousePos.y ==150)
            {
                b = 4;
            }
            else if (StartMousePos.x == -168 && StartMousePos.y == 356)
            {
                b = 5;
            }
            else if (StartMousePos.x == 0 && StartMousePos.y == 295)
            {
                b = 6;
            }
            if (UpWheres == b)
            {
                noneEquip(b);
            }
            else
            {
                UpWheres = b;
            }
        }
    }
    void noneEquip(int where)
    {
        if (where < 6)
        {
            UpWheres = -1;
            possess_Rune.Add(UsesmallRune[where - 1]);
            UsesmallRune[where - 1] = RuneType.none;
            ShowRunePage();
        }
        else if(where == 6)
        {
            UpWheres = -1;
            possess_Rune.Add(UseBigRune);
            UseBigRune = RuneType.none;
            Destroy(ShowUseBigRune);
            ShowRunePage();
        }
    }
    void Equip(int where)
    {
        Debug.Log(possess_Rune[where]);
        int size = 0;
        if((int)possess_Rune[where] <4 || (int)possess_Rune[where] >7)
        {
            size = 1;
            Debug.Log("들옴");
        }
        else
        {
            size = 2;
        }
        //
        if (size == 1)
        {
            bool enable = false;
            for (int i = 0; i < 5; i++)
            {
                if (UsesmallRune[i] == RuneType.none)
                {
                    UsesmallRune[i] = possess_Rune[where];
                    Equiptext_uppload((int)UsesmallRune[i]);
                     Destroy(possess_Rune_gb[where]);
                    possess_Rune.RemoveRange(where, 1);
                    possess_Rune_gb.RemoveRange(where, 1);
                    enable = true;
                    Wheres = -1;
                    break;
                }
                if(enable == true)
                {

                }
            }
        }
       if (size == 2)
       {
            if (ShowUseBigRune != null)
            {
                possess_Rune.Add(UseBigRune);
                Destroy(ShowUseBigRune);
            }
           UseBigRune = possess_Rune[Wheres];
           Destroy(possess_Rune_gb[Wheres]);
           possess_Rune.RemoveRange(Wheres, 1);
           possess_Rune_gb.RemoveRange(Wheres, 1);

           ShowUseBigRune = Instantiate(RunePrefebs[(int)UseBigRune]);
           ShowUseBigRune.transform.SetParent(transform);
           ShowUseBigRune.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
           ShowUseBigRune.transform.localPosition = new Vector3(0, 295, -1);
       }
       ShowRunePage();
       RuneEffect();
    }
    void Equiptext_uppload(int i)
    {
        switch(i)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }
        GameObject Equiptext_up = Instantiate(RuneEquipText_pf[i]);
        Equiptext_up.transform.SetParent(Rune_text_parents.transform);
        Equiptext_up.transform.localPosition = new Vector3(0, -80, 0);
        Equiptext_up.transform.localScale = new Vector3(1, 1, 1);
    }
}
