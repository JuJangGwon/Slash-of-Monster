using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class strangeattack : MonoBehaviour
{
    public GameObject Upgrade_t;
    public GameObject nee123dMoney_t;
    public GameObject upMoney_t;

    public GameObject Power_t;
    Text needmoney_t;
    Text upmoney_t;
    Text power_t;

    void Awake()
    {
        power_t = Power_t.GetComponent<Text>();
        upmoney_t = upMoney_t.GetComponent<Text>();
        needmoney_t = nee123dMoney_t.GetComponent<Text>();

        int a = 0;
        int j = 0;
        switch(Singleton.getInstance.skill2lv)
        {
            case 0:
                a = 450;
                break;
            case 1:
                a = 900;
                break;
            case 2:
                a = 1800;
                break;
            case 3:
                a = 3000;
                break;
            case 4:
                a = 4500;
                break; 
        }
        switch (Singleton.getInstance.skill2lv)
        {
            case 0:
                j = 300;
                break;
            case 1:
                j = 400;
                break;
            case 2:
                j = 600;
                break;
            case 3:
                j = 800;
                break;
            case 4:
                j = 00000;
                break;
        }
        int powers = j;
        power_t.text = powers.ToString();
        needmoney_t.text = a.ToString() + "g";
        upmoney_t.text = Singleton.getInstance.money.ToString() + " G";
    }

    public void AttackUpGrade()
    {
        int j = Singleton.getInstance.skill1lv;
        int a = 400 + j * 250;

        switch (Singleton.getInstance.skill2lv)
        {
            case 0:
                a = 450;
                break;
            case 1:
                a = 900;
                break;
            case 2:
                a = 1800;
                break;
            case 3:
                a = 3000;
                break;
            case 4:
                a = 4500;
                break;
        }
        switch (Singleton.getInstance.skill2lv)
        {
            case 0:
                j = 300;
                break;
            case 1:
                j = 400;
                break;
            case 2:
                j = 600;
                break;
            case 3:
                j = 800;
                break;
            case 4:
                j = 1000;
                break;
        }

        if (Singleton.getInstance.money >= a)
        {
            Singleton.getInstance.money -= a;
            Singleton.getInstance.skill2lv++;

            switch (Singleton.getInstance.skill2lv)
            {
                case 0:
                    a = 450;
                    break;
                case 1:
                    a = 900;
                    break;
                case 2:
                    a = 1800;
                    break;
                case 3:
                    a = 3000;
                    break;
                case 4:
                    a = 4500;
                    break;
            }
            switch (Singleton.getInstance.skill2lv)
            {
                case 0:
                    j = 4000;
                    break;
                case 1:
                    j = 5000;
                    break;
                case 2:
                    j = 6000;
                    break;
                case 3:
                    j = 8000;
                    break;
                case 4:
                    j = 10000;
                    break;
            }
            needmoney_t.text = a.ToString() + "g";
            upmoney_t.text = Singleton.getInstance.money.ToString() + " G";
            int powers = j;
            power_t.text = powers.ToString();

            PlayerPrefs.SetInt("SKill2", Singleton.getInstance.skill2lv);
            PlayerPrefs.SetInt("Money", Singleton.getInstance.money);
            PlayerPrefs.SetInt("BerserkerLevel", Singleton.getInstance.Level);
            PlayerPrefs.Save();
        }
    }
}
