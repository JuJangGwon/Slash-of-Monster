using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 헬라 갈래길, 불타는 개척로1 , 불타는 개척로2, 위험한 비탈길1
public class Ingame : MonoBehaviour {
    // 0.84375
    static List<string> mapname = new List<string>();

    public GameObject Grandfa;
    public GameObject npc;

    public GameObject worldmap;

    public GameObject MapnameSeal;
    public GameObject StageChangeEffect;
    public GameObject Donttouchmovemap;
    public GameObject Map_gb;
    public GameObject Mapname_gb;
    public GameObject Money_tex;

    public GameObject SKill1;
    public GameObject SKill2;

    Text mapname_text;
    Text money_text;
    Image mapname_img;

    public int stage = 1;
    public int Spec;

    NpcScript npcsc_sc;
    MonsterMananger monstermananger_sc;
    CreatePattern createpattern_sc;
    MapSelector mapselector_sc;
    BossManager bossmanager_sc;
    Map map_sc;

    void Awake()
    {
        worldmap.SetActive(true);

        npcsc_sc = npc.GetComponent<NpcScript>();
        money_text = Money_tex.GetComponent<Text>();
        Singleton.getInstance.stage = 999;
        Singleton.getInstance.MyPosition = Inanis_map.WorldTree;
        mapname_img = MapnameSeal.GetComponent<Image>();
        Screen.SetResolution(540, 960, false);

        if (PlayerPrefs.GetInt("Money") == 0) 
        if(PlayerPrefs.GetInt("First")==0)
        {
                Debug.Log("f");
            PlayerPrefs.SetInt("First",1);
            PlayerPrefs.SetInt("Money", 100);
            PlayerPrefs.Save();
        }
        int i = PlayerPrefs.GetInt("Quest");
        if (i == 0) Singleton.getInstance.quest = Quest.none;
        else if (i == 1) Singleton.getInstance.quest = Quest.going;
        else if (i == 2) Singleton.getInstance.quest = Quest.finish;
        else if (i == 3) Singleton.getInstance.quest = Quest.fd;

        if (PlayerPrefs.GetInt("BerserkerLevel") == 0) PlayerPrefs.SetInt("BerserkerLevel", 1);
        Singleton.getInstance.Level = PlayerPrefs.GetInt("BerserkerLevel");
        Singleton.getInstance.EnableWorld[0] = 1;
        Singleton.getInstance.EnableWorld[1] = 1;
        Singleton.getInstance.EnableWorld[2] = 0;
        Singleton.getInstance.EnableWorld[3] = 0;
        Singleton.getInstance.EnableWorld[4] = 0;
        Singleton.getInstance.EnableWorld[5] = 0;
        Singleton.getInstance.money = PlayerPrefs.GetInt("Money");
        Singleton.getInstance.Level = PlayerPrefs.GetInt("BerserkerLevel");

        int c = 50;
        int j = Singleton.getInstance.Level;
        for (int d = 1; d < j; d++)
        {
            c += ((d) * 2 + 1);
        }
        Singleton.getInstance.Power = c;
        Singleton.getInstance.skill1lv = PlayerPrefs.GetInt("SKill1");
        Singleton.getInstance.skill2lv = PlayerPrefs.GetInt("SKill2");
        mapname.Add("메마른 오아시스 입구");
        mapname.Add("붉은 사막길3");
        mapname.Add("붉은 사막길2");
        mapname.Add("붉은 사막길1");
        mapname.Add("황폐화된 벌판2");
        mapname.Add("황페화된 벌판1");
        mapname.Add("메마른 오아시스");
        mapname.Add("메마른 오아시스");
        money_text.text = Singleton.getInstance.money.ToString() + " G";

        bossmanager_sc = GetComponent<BossManager>();
        mapname_text = Mapname_gb.GetComponent<Text>();
        createpattern_sc = GetComponent<CreatePattern>();
        monstermananger_sc = GetComponent<MonsterMananger>();
        mapselector_sc = GetComponent<MapSelector>();
        map_sc = Map_gb.GetComponent<Map>();
    }
    void Start () {
        // ShowMapName();
        // 맵 선택 !
        Invoke("PlayGame", 1.5f);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            PlayerPrefs.DeleteAll();
        }
    }
    void PlayGame()
    {
        mapselector_sc.MapSelect(Singleton.getInstance.stage);
        Singleton.getInstance.GameState = GameState.PlayNormal;
    }
    public void ShowMapName()
    {
        Mapname_gb.SetActive(true);
        if(Singleton.getInstance.stage ==7) Singleton.getInstance.bossAlive = true;
        if (Singleton.getInstance.stage == 999) mapname_text.text = "세계수";
        else mapname_text.text = mapname[Singleton.getInstance.stage - 1];
        if (IsInvoking("CreatePattern") == true) CancelInvoke("CreatePattern");
        if (Singleton.getInstance.GameState != GameState.PlayNormal) Invoke("ShowMapName", 0.2f);
        else
        {
            StartCoroutine(FadeInandOut(mapname_text));
        }
    }
    public void Prepare()
    {
        stage = Singleton.getInstance.stage;
        if (IsInvoking("CreatePattern") == true) CancelInvoke("CreatePattern");
        if (IsInvoking("CreateMonster") == true) CancelInvoke("CreateMonster");
        if (IsInvoking("CreateBoss") == true) CancelInvoke("CreateBoss");
        if (stage < 7) Invoke("CreateMonster", 3);
        else if (stage == 7) Invoke("CreateBoss", 3);
    }
    public void CreateMonster()
    {
        monstermananger_sc.Monsters(Singleton.getInstance.stage - 1);
        InvokeRepeating("CreatePattern", 1,1);
    }
    public void CreateBoss()
    {
        int i = 0;
        switch(Singleton.getInstance.stage)
        {
           case 6:
                i = 0;
           break;
            case 7:
                i = 0;
           break;
        }
        bossmanager_sc.bossCreate(i);
    }
    public void MonsterDie()
    {
        monstermananger_sc.Clear();
    }
    public void CreatePattern()
    {
        if(Singleton.getInstance.GameMode == true) createpattern_sc.CreateGesture(3);
    }
    public void ChangeMap(int stage)
    {
        if (IsInvoking("CreateMonster") == true) CancelInvoke("CreateMonster");
        if (IsInvoking("CreateBoss") == true) CancelInvoke("CreateBoss");
        if (IsInvoking("CreatePattern") == true) CancelInvoke("CreatePattern");

        Singleton.getInstance.stage = stage;
        StartCoroutine(StageChangeEffect_corutine());
    }
    IEnumerator StageChangeEffect_corutine()
    {
        SKill1.SetActive(false);
        SKill2.SetActive(false);
        Grandfa.SetActive(false);
        npc.SetActive(false);
        Singleton.getInstance.untouched = false;
        float duration = 1.5f;
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        StageChangeEffect.transform.localPosition = new Vector3(1196, 312, -2);
        createpattern_sc.Clear();
        while (duration > 0.0f)
        {
            duration -= Time.deltaTime;
            StageChangeEffect.transform.localPosition = Vector3.MoveTowards(StageChangeEffect.transform.localPosition, new Vector3(70, 312, -2), 1600 * Time.smoothDeltaTime);
            yield return waitForEndOfFrame;
        }
        
        if (Singleton.getInstance.stage == 999 || Singleton.getInstance.MyPosition == Inanis_map.WorldTree) 
        {
            Singleton.getInstance.MyPosition = Inanis_map.WorldTree;
             Grandfa.SetActive(true);
             npc.SetActive(true);
             npcsc_sc.Start();
        }
        //
         if (Singleton.getInstance.MyPosition == Inanis_map.OasisEntrance)
         {
            SKill1.SetActive(true);
            SKill2.SetActive(true);
         }

        mapselector_sc.MapSelect(Singleton.getInstance.stage);
        MonsterDie();
        map_sc.Start();
            //

            yield return new WaitForSeconds(0.1f);
        duration = 2;
        while (duration > 0.0f)
        {
            duration -= Time.deltaTime;
            StageChangeEffect.transform.localPosition = Vector3.MoveTowards(StageChangeEffect.transform.localPosition, new Vector3(-1200, 312, -2), 1600 * Time.smoothDeltaTime);
            yield return waitForEndOfFrame;
        }
        Singleton.getInstance.untouched = true;
    }
    IEnumerator FadeInandOut(Text tx)
    {
        MapnameSeal.SetActive(true);
        Mapname_gb.SetActive(false);
        for (float i = 0; i <= 1; i += 0.1f)
        {
            Color color = new Vector4(tx.color.r, tx.color.g, tx.color.b, i);
            mapname_img.color = color;
            yield return new WaitForSeconds(0.06f);
        }     
        yield return new WaitForSeconds(0.2f);
        Mapname_gb.SetActive(true);
        for (float i = 0; i <= 1; i += 0.1f)
        {
            Color color = new Vector4(tx.color.r, tx.color.g, tx.color.b, i);
            tx.color = color;
            yield return new WaitForSeconds(0.05f);
        }
       
        yield return new WaitForSeconds(2);
        for (float i = 1f; i >= 0; i -= 0.05f)
        {
            Color color = new Vector4(tx.color.r, tx.color.g, tx.color.b, i);
            tx.color = color;
            mapname_img.color = color;
            yield return new WaitForSeconds(0.02f);
        }
        Donttouchmovemap.SetActive(false);
        Mapname_gb.SetActive(false);
        MapnameSeal.SetActive(false);
        Prepare();
    }
}
