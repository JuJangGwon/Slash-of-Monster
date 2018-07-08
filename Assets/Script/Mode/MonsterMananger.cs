using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterMananger : MonoBehaviour {
    
    bool monster_live = false;

    int monsterHp = 0;
    int Coin_num = 0;

    AudioSource As;

    public GameObject Money_gb;
    Text Money_t;

    public GameObject[] Slime_pf = new GameObject[4];
    public GameObject[] Janyak_pf = new GameObject[4];
    public GameObject[] Ork_pf = new GameObject[3];
    public GameObject[] Golam_pf = new GameObject[3];
    public GameObject[] Cobra_pf = new GameObject[2];
    public GameObject[] Horus_pf = new GameObject[2];
    public GameObject[] Anubis_pf = new GameObject[2];
    public GameObject[] Hog_pf = new GameObject[2];

    public GameObject[] Rune_pf = new GameObject[8];

    public GameObject[] monster = new GameObject[10];
    public GameObject MonsterParents;
    public GameObject Now_Monster;
    public RuneType Now_rune = RuneType.none;
    public GameObject hp_bar;
    public GameObject hp_bloody;

    public GameObject DropRunes;
    Image hp_bar_img;

    public GameObject Money_pf;
    public GameObject Money_parent;

    Animator anim;

    Ingame ingame_sc;
    Figure fiqure_sc;

    int MaxHp;
    int NowHp;
    int GainGold = 0;

    List<GameObject> money_infield = new List<GameObject>();

    int i = 0;
    void Awake()
    {
        Money_t = Money_gb.GetComponent<Text>();
        As = Money_parent.GetComponent<AudioSource>();
        ingame_sc = GetComponent<Ingame>();
        fiqure_sc = GetComponent<Figure>();
        hp_bar_img = hp_bloody.GetComponent<Image>();
    }
    void RedDesertLoad1_m()
    {
        int Rand = Random.Range(1, 5);
        int Rand2 = Random.Range(1, 101);
        switch(Rand)
        {
            case 1:
                Now_Monster = Instantiate(Slime_pf[0]);
                MaxHp = 250;
                if (Rand2 < 61) GainGold = 1;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 3;
                else if (Rand2 > 95) GainGold =5;
               break;
            case 2:
                Now_Monster = Instantiate(Slime_pf[1]);
                MaxHp = 300;
                if (Rand2 < 61) GainGold = 3;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 6;
                else if (Rand2 > 95) GainGold = 10;
                break;
            case 3:
                Now_Monster = Instantiate(Janyak_pf[0]);
                MaxHp = 350;
                if (Rand2 < 61) GainGold = 5;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 9;
                else if (Rand2 > 95) GainGold = 15;
                break;
            case 4:
                Now_Monster = Instantiate(Golam_pf[0]);
                MaxHp = 400;
                if (Rand2 < 61) GainGold = 7;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 12;
                else if (Rand2 > 95) GainGold = 20;
                break;
        }
    }
    void RedDesertLoad2_m()
    {
        int Rand = Random.Range(1, 5);
        int Rand2 = Random.Range(1, 101);
        switch (Rand)
        {
            case 1:
                Now_Monster = Instantiate(Slime_pf[2]);
                MaxHp = 500;
                if (Rand2 < 61) GainGold = 15;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 18;
                else if (Rand2 > 95) GainGold = 35;
                break;
            case 2:
                Now_Monster = Instantiate(Slime_pf[3]);
                MaxHp = 600;
                if (Rand2 < 61) GainGold = 17;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 21;
                else if (Rand2 > 95) GainGold = 40;
                break;
            case 3:
                Now_Monster = Instantiate(Janyak_pf[1]);
                MaxHp = 700;
                if (Rand2 < 61) GainGold = 19;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 24;
                else if (Rand2 > 95) GainGold = 45;
                break;
            case 4:
                Now_Monster = Instantiate(Golam_pf[1]);
                MaxHp = 800;
                if (Rand2 < 61) GainGold = 22;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 27;
                else if (Rand2 > 95) GainGold = 50;
                break;
        }
    }
    void RedDesertLoad3_m()
    {
        int Rand = Random.Range(1, 5);
        int Rand2 = Random.Range(1, 101);
        switch (Rand)
        {
            case 1:
                Now_Monster = Instantiate(Janyak_pf[2]);
                MaxHp = 1000;
                if (Rand2 < 61) GainGold = 30;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 36;
                else if (Rand2 > 95) GainGold = 50;
                break;
            case 2:
                Now_Monster = Instantiate(Janyak_pf[3]);
                MaxHp = 1100;
                if (Rand2 < 61) GainGold = 35;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 41;
                else if (Rand2 > 95) GainGold = 55;
                break;
            case 3:
                Now_Monster = Instantiate(Golam_pf[2]);
                MaxHp = 1200;
                if (Rand2 < 61) GainGold = 40;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 46;
                else if (Rand2 > 95) GainGold = 60;
                break;
            case 4:
                Now_Monster = Instantiate(Ork_pf[0]);
                MaxHp = 1350;
                if (Rand2 < 61) GainGold = 50;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 56;
                else if (Rand2 > 95) GainGold = 70;
                break;
        }
    }
    void Field1_m()
    {
        int Rand = Random.Range(1, 5);
        int Rand2 = Random.Range(1, 101);
        switch (Rand)
        {
            case 1:
                Now_Monster = Instantiate(Ork_pf[1]);
                MaxHp = 1700;
                if (Rand2 < 61) GainGold = 50;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 58;
                else if (Rand2 > 95) GainGold = 90;
                break;
            case 2:
                Now_Monster = Instantiate(Hog_pf[1]);
                MaxHp = 2100;
                if (Rand2 < 61) GainGold = 60;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 70;
                else if (Rand2 > 95) GainGold = 110;
                break;
            case 3:
                Now_Monster = Instantiate(Cobra_pf[0]);
                MaxHp = 2600;
                if (Rand2 < 61) GainGold = 70;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 85;
                else if (Rand2 > 95) GainGold = 130;
                break;
            case 4:
                Now_Monster = Instantiate(Anubis_pf[1]);
                MaxHp = 3000;
                if (Rand2 < 61) GainGold = 80;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 90;
                else if (Rand2 > 95) GainGold = 150;
                break;
        }
    }
    void Field2_m()
    {
        int Rand = Random.Range(1, 4);
        int Rand2 = Random.Range(1, 101);
        switch (Rand)
        {
            case 1:
                Now_Monster = Instantiate(Ork_pf[2]);
                MaxHp = 3500;
                if (Rand2 < 61) GainGold = 100;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 130;
                else if (Rand2 > 95) GainGold = 200;
                break;
            case 2:
                Now_Monster = Instantiate(Cobra_pf[1]);
                MaxHp = 3800;
                if (Rand2 < 61) GainGold = 130;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 170;
                else if (Rand2 > 95) GainGold = 250;
                break;
            case 3:
                Now_Monster = Instantiate(Horus_pf[1]);
                MaxHp = 4200;
                if (Rand2 < 61) GainGold = 150;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 200;
                else if (Rand2 > 95) GainGold = 300;
                break;
        }
    }
    void OasisEntrance_m()
    {
        Debug.Log("dd");
        int Rand = Random.Range(1, 4);
        int Rand2 = Random.Range(1, 101);
        switch (Rand)
        {
            case 1:
                Now_Monster = Instantiate(Hog_pf[0]);
                MaxHp = 4500;
                Now_rune = RuneType.fire;
                if (Rand2 < 61) GainGold = 180;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 225;
                else if (Rand2 > 95) GainGold = 350;
                break;
            case 2:
                Now_Monster = Instantiate(Horus_pf[0]);
                MaxHp = 5500;
                Now_rune = RuneType.ground;
                if (Rand2 < 61) GainGold = 350;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 400;
                else if (Rand2 > 95) GainGold = 550;
                break;
            case 3:
                Now_Monster = Instantiate(Anubis_pf[0]);
                MaxHp = 5000;
                Now_rune = RuneType.wind;
                if (Rand2 < 61) GainGold = 200;
                else if (Rand2 > 60 && Rand2 < 96) GainGold = 260;
                else if (Rand2 > 95) GainGold = 400;
                break;
        }
    }
    public void Monsters(int type)
    {
        hp_bar.transform.localScale = new Vector3(1, 1, 1);
        monster_live = true;
        Now_rune = RuneType.none;
        switch (Singleton.getInstance.MyPosition)
        {
            case Inanis_map.RedDesertRoad1:
                RedDesertLoad1_m();
                break;
            case Inanis_map.RedDesertRoad2:
                RedDesertLoad2_m();
                break;
            case Inanis_map.RedDesertRoad3:
                RedDesertLoad3_m();
                break;
            case Inanis_map.DepletedField1:
                Field1_m();
                break;
            case Inanis_map.DepletedField2:
                Field2_m();
                break;
            case Inanis_map.BarrenOasisEntrance:
                OasisEntrance_m();
                break;
        }
        NowHp = MaxHp;

        Now_Monster.transform.SetParent(MonsterParents.transform);

        Now_Monster.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        Now_Monster.transform.localPosition = new Vector3(0, 263, 0);
        
        anim = Now_Monster.GetComponent<Animator>();
        hp_bar.SetActive(true);
        Hp_scaleChecker();
    }
    public void Monster_hitby()
    {
        if (monster_live == true)
        {
            float damage = Singleton.getInstance.Power + Random.Range(-4,5);
            int ciritical = 10 + Singleton.getInstance.RuneEffect_criticial_percent;
            bool criticialbuff = false;
            float runepower = 0;
            int i = Singleton.getInstance.Level;
            if (Rune.UseBigRune == RuneType.fire && Now_rune == RuneType.wind) ciritical = 35;
            else if (Rune.UseBigRune == RuneType.water && Now_rune == RuneType.fire) runepower = (float)damage * 0.2f;
            else if (Rune.UseBigRune == RuneType.wind && Now_rune == RuneType.ground) ; // 보스한테만 적용 
            else if (Rune.UseBigRune == RuneType.ground && Now_rune == RuneType.water) criticialbuff = true;

            damage += (Singleton.getInstance.RuneEffect_attack_percent / 100) * damage + (int)runepower;
            // 크리
            int ciriticalrand = Random.Range(1, 101);
            if (ciriticalrand <= ciritical)
            {
                if (criticialbuff == false) damage *= 1.5f;
                else
                {
                    damage *= 2;
                }
            }
            NowHp -= (int)damage;

            fiqure_sc.DamageChecker((int)damage);
            Hp_scaleChecker();
            if (Singleton.getInstance.stage <7) anim.SetTrigger("hitby");
        }
    }
    void Update()
    {
        for (int i = 0; i < money_infield.Count; i++)
        {
            money_infield[i].transform.localPosition = Vector3.Lerp(money_infield[i].transform.localPosition, new Vector3(0, 650 + 359, 0), Time.smoothDeltaTime * 5f);
            if(money_infield[i].transform.localPosition.y > 590+359)
            {
                Destroy(money_infield[i]);
                money_infield.RemoveRange(i, 1);
            }
        }
    }

    void CreateCoin()
    {
        Coin_num--;
        
        GameObject moneys = Instantiate(Money_pf);
        moneys.transform.SetParent(Money_parent.transform);
        moneys.transform.localScale = new Vector3(1, 1, 1);
        moneys.transform.localPosition = new Vector3(0, 310, 0);
        money_infield.Add(moneys);
        if (Coin_num > 0) Invoke("CreateCoin", 0.12f);
        if (Coin_num == 0) As.Play();
    }

    void Hp_scaleChecker()
    {
        if (NowHp <= 0)
        {
            ingame_sc.Prepare();
            hp_bar.SetActive(false);
            anim.SetTrigger("die");
            monster_live = false;
            Destroy(Now_Monster, 1.5f);
            //
            int money = (Singleton.getInstance.RuneEffect_money_percent / 100) * GainGold + GainGold;
            Debug.Log(money);
            CreateCoin();
            Coin_num = 4;
            Singleton.getInstance.money += money;
            Money_t.text = Singleton.getInstance.money + " G";
            PlayerPrefs.SetInt("Money", Singleton.getInstance.money);
            PlayerPrefs.Save();

            int rand = Random.Range(0, 100);
            if(rand<3)
            {
                int rands = Random.Range(0, 8);
                GameObject ruenss = Instantiate(Rune_pf[rands]);
                ruenss.transform.SetParent(DropRunes.transform);
                ruenss.transform.localScale = new Vector3(1, 1, 1);
                ruenss.transform.localPosition = new Vector3(0, -60, 0);
                switch(rand)
                {
                    case 0:
                        Rune.possess_Rune.Add(RuneType.blue);
                        break;
                    case 1:
                        Rune.possess_Rune.Add(RuneType.purple);
                        break;
                    case 2:
                        Rune.possess_Rune.Add(RuneType.red);
                        break;
                    case 3:
                        Rune.possess_Rune.Add(RuneType.yellow);
                        break;
                    case 4:
                        Rune.possess_Rune.Add(RuneType.blue2);
                        break;
                    case 5:
                        Rune.possess_Rune.Add(RuneType.purple2);
                        break;
                    case 6:
                        Rune.possess_Rune.Add(RuneType.red2);
                        break;
                    case 7:
                        Rune.possess_Rune.Add(RuneType.yellow2);
                        break;
                }
            }
        }
        hp_bar_img.fillAmount = (float)NowHp /(float)MaxHp;
    }


    public void Clear()
    {
        if(Now_Monster != null) Destroy(Now_Monster);
        hp_bar.SetActive(false);
    }
}
