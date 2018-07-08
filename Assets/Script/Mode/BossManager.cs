using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    // bool boss_attack_time = false;

    public GameObject popup;

    int money;

    AttackDecision Ad;
    public GameObject Shieldeffect_pf;
    
    public GameObject GameScreen;

    bool boss_alive = false;

    int monsterHp = 0;
    int Coin_num = 0;

    public GameObject Imsi_map;

    public GameObject[] attack_Gesture_pf = new GameObject[13];

    public GameObject[] Boss = new GameObject[10];
    public GameObject MonsterParents;
    public GameObject Now_Monster;
    public GameObject hp_bar;

    public GameObject boom_effect;
    public GameObject Gesture_effect_parents;

    public GameObject Money_pf;
    public GameObject Money_parent;

    public GameObject Character;
    Animator character_anim;

    public GameObject Die_gb;
    public GameObject Die_black_gb;

    public GameObject gold_text;
    RuneType Now_rune = RuneType.fire;
    Image Die_black_img;

    Animator anim;
    Animator shieldanim;

    Text gold_t;
    Ingame ingame_sc;
    Figure fiqure_sc;

    List<Image> gesture_i = new List<Image>();

    int[] MaxHp = new int[6] { 500000, 1200, 2800, 4000, 8000, 15000};
    int NowHp;

    List<GameObject> money_infield = new List<GameObject>();

    List<int> Attack_Gesture = new List<int>();
    List<GameObject> Attack_Gesture_gb = new List<GameObject>();
    void Awake()
    {
        gold_t = gold_text.GetComponent<Text>();
        character_anim = Character.GetComponent<Animator>();
        Ad = transform.GetComponent<AttackDecision>();
        Die_black_img = Die_black_gb.GetComponent<Image>();
        ingame_sc = GetComponent<Ingame>();
        fiqure_sc = GetComponent<Figure>();
    }
    
    public void bossAttack()
    {
        Attack_Gesture.Clear();
        Attack_Gesture_gb.Clear();

        for (int i = 0; i < 3; i++)
        {
            b:
            int land = Random.Range(0, 8);
            if (land == 8 || land == 3) goto b;
            {
                Attack_Gesture.Add(land);
            }
        }
        anim.SetTrigger("attack");
        StartCoroutine(bossAttack_courutine());
    }
    public void BossattackDecision(Result GainGesture)
    {
        if(Attack_Gesture[0] == (int)GainGesture)
        {
            if (Singleton.getInstance.useSKill == true)
            {
                Singleton.getInstance.useSKill = false;
                Ad.useskill = 0;
                Ad.skill_gauge = 0;
            }
                // effect boom
            GameObject boom_effect_gb = Instantiate(boom_effect);
            boom_effect_gb.transform.SetParent(Gesture_effect_parents.transform, false);
            boom_effect_gb.transform.localScale = new Vector3(1, 1, 1);
            boom_effect_gb.transform.position = Attack_Gesture_gb[0].transform.position;
            Destroy(boom_effect_gb, 0.5f);
            // Attack_gesture[0] 삭★제
            Destroy(Attack_Gesture_gb[0],0.1f);
            Attack_Gesture_gb.RemoveRange(0, 1);
            Attack_Gesture.RemoveRange(0, 1);
            if(Attack_Gesture.Count == 0)
            {
                GameObject gb = Instantiate(Shieldeffect_pf);
                gb.transform.SetParent(Character.transform);
                gb.transform.localPosition = new Vector3(0, 0, 0);
                gb.transform.localScale = new Vector3(1, 1, 1);
                shieldanim = gb.GetComponent<Animator>();
                Destroy(gb,4.5f);
            }
        }
        if (Attack_Gesture.Count == 0) Singleton.getInstance.bossState = BossState.normal;
    }
    void BossAttack_()
    {
        if(Attack_Gesture.Count>0)
        {
            for (int i = 0; i < Attack_Gesture.Count; i++)
            {
                gesture_i.Add(Attack_Gesture_gb[i].GetComponent<Image>());
                gesture_i[i].color = Color.gray;
                Destroy(gesture_i[i], 0.8f);
            }
            StartCoroutine(CameraShake());
            gesture_i.RemoveRange(0, Attack_Gesture.Count);

            CharacterDie();
            Singleton.getInstance.Character_Live = false;
        }
        else
        {
            Invoke("aa", 0.3f);
        }
        Singleton.getInstance.bossState = BossState.normal;
        Invoke("bossAttack", 8);
    }
    void aa()
    {
            shieldanim.SetTrigger("sheilding");
    }
    void CharacterDie() 
    {
        Singleton.getInstance.OOO = true;

        Singleton.getInstance.bossAlive = false;
        character_anim.SetTrigger("Die");
        Destroy(Now_Monster,2);
        boss_alive = false;
        hp_bar.SetActive(false);
        Singleton.getInstance.bossState = BossState.none;
        if(IsInvoking("bossAttack") == true) CancelInvoke("bossAttack");
        if(IsInvoking("BossAttack_") == true) CancelInvoke("BossAttack_");
        Singleton.getInstance.GameState = GameState.none;
        StartCoroutine(CharacterDie_Corutine());
        Singleton.getInstance.GameMode = false;

        for(int i = 0; i< 5; i++)
        {
            Rune.UsesmallRune[i] = RuneType.none;
        }
        Rune.UseBigRune = RuneType.none;
    }
    IEnumerator bossAttack_courutine()
    {
        Singleton.getInstance.bossState = BossState.attack;
        GameObject gb = Instantiate(attack_Gesture_pf[Attack_Gesture[0]]);
        gb.transform.SetParent(MonsterParents.transform);
        gb.transform.localScale = new Vector3(1, 1, 1);
        gb.transform.localPosition = new Vector3(-195, 150, 0);
        Attack_Gesture_gb.Add(gb);
        yield return new WaitForSeconds(0.15f);
        GameObject gb2 = Instantiate(attack_Gesture_pf[Attack_Gesture[1]]);
        gb2.transform.SetParent(MonsterParents.transform);
        gb2.transform.localScale = new Vector3(1, 1, 1);
        gb2.transform.localPosition = new Vector3(-240, 280, 0);
        Attack_Gesture_gb.Add(gb2);
        yield return new WaitForSeconds(0.15f);
        GameObject gb3 = Instantiate(attack_Gesture_pf[Attack_Gesture[2]]);
        gb3.transform.SetParent(MonsterParents.transform);
        gb3.transform.localScale = new Vector3(1, 1, 1);
        gb3.transform.localPosition = new Vector3(-195, 420, 0);
        Attack_Gesture_gb.Add(gb3);
        yield return new WaitForSeconds(0.15f);
        Invoke("BossAttack_", 2.1f);
    }
    public void bossCreate(int type)
    {
        Singleton.getInstance.bossAlive = true;
        hp_bar.transform.localPosition = new Vector3(0, 542, 0);
        hp_bar.transform.localScale = new Vector3(1, 1, 1);
        boss_alive = true;

        NowHp = MaxHp[0];
        Now_Monster = Instantiate(Boss[type]);
        Now_Monster.transform.SetParent(MonsterParents.transform);
        Now_Monster.transform.localScale = new Vector3(0.9f, 0.9f, 1);
        if (type == 0)
        {
            Now_Monster.transform.localPosition = new Vector3(0, 248, 0);
        }
        anim = Now_Monster.GetComponent<Animator>();
        hp_bar.SetActive(true);
        Hp_scaleChecker();
        Invoke("bossAttack",3);
        Singleton.getInstance.GameState = GameState.PlayBoss;
        Singleton.getInstance.bossState = BossState.normal;
    }
    IEnumerator CharacterDie_Corutine()
    {
      
        yield return new WaitForSeconds(1);
        while (Die_black_img.color.a < 0.7f)
        {
            float a = Die_black_img.color.a;
            Die_black_img.color = new Vector4(0, 0, 0, a+0.01f);
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(0.8f);
        Die_gb.SetActive(true);
        yield return null;
    }
    public void Boss_hitby(int o)    
    {
        if (boss_alive == true)
        {
            if (o == 1)
            {
                float damage = Singleton.getInstance.Power + Random.Range(-4, 5);
                if (Singleton.getInstance.attackbuffup == true)
                {
                    switch(Singleton.getInstance.skill1lv)
                    {
                        case 1:
                            damage = damage * 1.5f;
                            break;
                        case 2:
                            damage = damage * 2f;
                            break;
                        case 3:
                            damage = damage * 4f;
                            break;
                        case 4:
                            damage = damage * 6f;
                            break;
                        case 5:
                            damage = damage * 9f;
                            break;
                    }
                }

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
            }
            if(o ==2)
            {
                int damage = Singleton.getInstance.Power + Random.Range(-4, 5);
                switch (Singleton.getInstance.skill2lv)
                {
                    case 1:
                        damage = damage * 40;
                        break;
                    case 2:
                        damage = damage * 50;
                        break;
                    case 3:
                        damage = damage * 60;
                        break;
                    case 4:
                        damage = damage * 80;
                        break;
                    case 5:
                        damage = damage * 100;
                        break;
                }
                fiqure_sc.DamageChecker(damage);
                NowHp -= damage;
                Hp_scaleChecker();
                anim.SetTrigger("hitby");
                StartCoroutine(CameraShake());
            }
        }
    }
    void Update()
    {
        for (int i = 0; i < money_infield.Count; i++)
        {
            money_infield[i].transform.localPosition = Vector3.Lerp(money_infield[i].transform.localPosition, new Vector3(0, 650 + 359, 0), Time.smoothDeltaTime * 5f);
            if (money_infield[i].transform.localPosition.y > 590 + 359)
            {
                Destroy(money_infield[i]);
                money_infield.RemoveRange(i, 1);
            }
        }
        if (boss_alive == false) if (IsInvoking("bossAttack") == true) CancelInvoke("bossAttack");
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
    }
    void skskd()
    {
        popup.SetActive(true);
    }

    void Hp_scaleChecker()
    {
        if (NowHp <= 0)
        {
            // ingame_sc.Prepare();
            int Randoms = Random.Range(1, 101);
            if (Randoms < 61) money = 2000;
            else if (Randoms > 60 && Randoms < 96) money = 3000;
            else money = 4000;
            money += (Singleton.getInstance.RuneEffect_money_percent / 100) * money;
            Singleton.getInstance.money += money;
            PlayerPrefs.SetInt("Money", Singleton.getInstance.money);
            PlayerPrefs.Save();
            gold_t.text = Singleton.getInstance.money.ToString()+" G";

            if (Singleton.getInstance.quest == Quest.going)
            {
                Singleton.getInstance.killboss1 = true;
                Invoke("skskd", 2.5f);
            }
            
            hp_bar.SetActive(false);
            anim.SetTrigger("die");
            boss_alive = false;
            Destroy(Now_Monster, 3);
            Coin_num = 9;
            CreateCoin();
            Singleton.getInstance.bossAlive = false;
        }
        hp_bar.transform.localScale = new Vector3((float)NowHp / (float)MaxHp[0], 1, 1);
    }
    public void Clear()
    {
        if (Now_Monster != null) Destroy(Now_Monster);
        hp_bar.SetActive(false);
    }
    IEnumerator CameraShake()
    {
        yield return new WaitForSeconds(0.2f);
        GameScreen.transform.localPosition = new Vector2(0,10);
        yield return new WaitForSeconds(0.03f);
        GameScreen.transform.localPosition = new Vector2(20, 10);
        yield return new WaitForSeconds(0.03f);
        GameScreen.transform.localPosition = new Vector2(0, 0);
        yield return new WaitForSeconds(0.03f);
        GameScreen.transform.localPosition = new Vector2(10, -10);
        yield return new WaitForSeconds(0.03f);
        GameScreen.transform.localPosition = new Vector2(20, 10);
        yield return new WaitForSeconds(0.03f);
        GameScreen.transform.localPosition = new Vector2(0, 0);
        yield return new WaitForSeconds(0.03f);
        GameScreen.transform.localPosition = new Vector2(0, 10);
        yield return new WaitForSeconds(0.03f);
        GameScreen.transform.localPosition = new Vector2(20, 10);
        yield return new WaitForSeconds(0.03f);
        GameScreen.transform.localPosition = new Vector2(0, 0);
        yield return new WaitForSeconds(0.03f);
        GameScreen.transform.localPosition = new Vector2(10, -10);
        yield return new WaitForSeconds(0.03f);
        GameScreen.transform.localPosition = new Vector2(20, 10);
        yield return new WaitForSeconds(0.03f);
        GameScreen.transform.localPosition = new Vector2(0, 0);
        yield return new WaitForSeconds(0.03f);
    }
}

