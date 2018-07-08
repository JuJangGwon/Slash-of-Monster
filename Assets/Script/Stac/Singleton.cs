using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Quest
{
    none,
    going,
    finish,
    fd
}

public enum World
{
    WorldTree =0,
    Inanis
}
public enum Inanis_map
{
    none,
    RedDesertRoad1,
    RedDesertRoad2,
    RedDesertRoad3,
    DepletedField1,
    DepletedField2,
    BarrenOasisEntrance,
    OasisEntrance,
    WorldTree
}
public enum BossState
{
    none,
    normal,
    attack,
    die
}
public enum GameState
{
    none,
    Loading,
    CreateMonster,
    CreatePattern,
    ChangeStage,
    stop,
    MonsterDie,
    PlayNormal,
    showmenu,
    PlayBoss,
    worldTree
}

public enum Job
{
    Beserek = 1,
    magician =2,
    shamen = 3,
}
public enum Gesture
{
    leftup= 0,
    up,
    rightup,
    right,
    rightdown,
    down,
    leftdown,
    left,
    triangle1,
    triangle2,
    Circle,
    Square,
    Z,
    none
}
public enum AttackAnim
{
    none,
    left,
    right,
    up
}

public class Singleton : MonoBehaviour
{

    private static Singleton instance;

    public static Singleton getInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(Singleton)) as Singleton;
            }

            if (instance == null)
            {
                GameObject obj = new GameObject("obj");
                instance = obj.AddComponent(typeof(Singleton)) as Singleton;
            }

            return instance;
        }
    }
    public bool Character_Live = true;

    public int world = 1;
    public int stage = 1;
    public int Level = 1;

    public int skill1lv = 0;
    public int skill2lv = 0;

    public bool buskill1 = false;
    public bool buskill2 = false;

    public int EnableStage = 1;

    public int money = 1000;

    public bool useSKill = false;
    public bool Popup_open = false;
    public bool PausePopup_open = false;
    public bool CreditPopup_open = false;

    public bool attackbuffup = false;
    public Gesture Gesture_i = Gesture.none;
    public BossState bossState = BossState.none;
    public float defense_time = 0;
    public bool monster_s = false;
    public bool attacks = false;
    public bool GameMode = true;
    public int mode = 4;
    public bool skill1_start = false;
    public int skill_shootbullet = 0;

    // 보스모드 8방향 레벨 // 
    public int leftUp_Lv = 1;
    public int Up_Lv = 1;
    public int rightUp_Lv = 1;
    public int right_Lv = 1;
    public int rightdown_Lv = 1;
    public int down_Lv = 1;
    public int leftdown_Lv = 1;
    public int left_Lv = 1;
    public int Boss_hp = 0;

    public int[] depend_pattern = new int[3] { -1, -1, -1 };
    public bool bossattacktime = false;

    public bool Character_def = false;
    public int dmg = 0;
    public bool Camerashake = false;
    public bool useCorutine = false;
    public bool Uppermap_useCorutine = false;
    public Job Job = Job.Beserek;

    public bool WrongRecognize = false;
    public bool untouched = false;
    public bool DonMove = false;

    public int[] EnableWorld = new int[6];

    public int Power = 50;
    public World myworld = World.Inanis;
    public int i = 0;
    public GameState GameState = GameState.none;
    public bool bossAlive = false;
    public AttackAnim An = AttackAnim.none;

    public int RuneEffect_money_percent = 0;
    public int RuneEffect_cooltime_percent = 0;
    public int RuneEffect_attack_percent = 0;
    public int RuneEffect_criticial_percent = 0;

    public bool OOO = false;
    public bool KKK = false;

    public Quest quest = Quest.none;

    public bool killboss1 = false;

    public int skill1Cooltime = 0;
    public int skill2Cooltime = 0;

    public Inanis_map MyPosition = Inanis_map.none;
}



