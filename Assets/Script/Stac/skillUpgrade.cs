using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillUpgrade : MonoBehaviour {

    public GameObject Upgrade_t;
    public GameObject needMoney_t;
    public GameObject upMoney_t;
    public GameObject Power_gb;
    Text text_;
    Text needmoney_t;
    Text upmoney_t;
    Text Power_t;

    public GameObject need_money;
    void Awake()
    {
        text_ = Upgrade_t.GetComponent<Text>();
        needmoney_t = needMoney_t.GetComponent<Text>();
        upmoney_t = upMoney_t.GetComponent<Text>();
        Power_t = Power_gb.GetComponent<Text>();

        int j = Singleton.getInstance.Level;
        int a = 0;
        for (int i = 0; i <= j; i++)
        {
            a += i * 3;
        }
        // 3 5 8/
        int c = 50;
        for (int i = 0; i < j; i++)
        {
            c += ((i) * 2 + 1);
        }
        Singleton.getInstance.Power = c;
        needmoney_t.text = a.ToString() + "g";
        upmoney_t.text = Singleton.getInstance.money.ToString() + " G";
        text_.text = "" + Singleton.getInstance.Level;
        Power_t.text = "" + Singleton.getInstance.Power;
    }

    public void AttackUpGrade()
    {
        int j = Singleton.getInstance.Level;
        int a = 0;
        for (int i = 0; i <= j; i++)
        {
            a += i * 3;
        }
        if (Singleton.getInstance.money >= a)
        {
            Singleton.getInstance.money -= a;
            Singleton.getInstance.Level++;
            j = Singleton.getInstance.Level;
            a = 0;
            for (int i = 0; i <= j; i++)
            {
                a += i * 3;
            }
            int c = 50;
            for (int i = 1; i < j; i++)
            {
                c += ((i) * 2 + 1);
            }
            needmoney_t.text = a.ToString() + "g";
            upmoney_t.text = Singleton.getInstance.money.ToString() + " G";
            PlayerPrefs.SetInt("Money", Singleton.getInstance.money);
            PlayerPrefs.SetInt("BerserkerLevel", Singleton.getInstance.Level);
            Singleton.getInstance.Power = c;
            Power_t.text = "" + Singleton.getInstance.Power;
            PlayerPrefs.Save();
        }
        text_.text = ""+ Singleton.getInstance.Level;
        
    }
}
