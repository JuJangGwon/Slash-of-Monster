using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lagranok : MonoBehaviour
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

        int j = Singleton.getInstance.skill1lv;
        int a = 0;
        float b = 0;
        switch (Singleton.getInstance.skill1lv)
        {
            case 0:
                a = 300;
                b = 1.5f;
                break;
            case 1:
                a = 600;
                b = 2;
                break;
            case 2:
                a = 1200;
                b = 4;
                break;
            case 3:
                a = 2400;
                b = 6;
                break;
            case 4:
                a = 4800;
                b = 9;
                break;
            case 5:
                b = 15;
                a = 999900;
                break;
        }
        power_t.text = b.ToString();
        needmoney_t.text = a.ToString() + "g";
        upmoney_t.text = Singleton.getInstance.money.ToString() + " G";
    }
    public void AttackUpGrade()
    {
        int a = 0;
        float b = 0;
        switch (Singleton.getInstance.skill1lv)
        {
            case 0:
                a = 300;
                b = 1.5f;
                break;
            case 1:
                a = 600;
                b = 2;
                break;
            case 2:
                a = 1200;
                b = 4;
                break;
            case 3:
                a = 2400;
                b = 6;
                break;
            case 4:
                a = 4800;
                b = 9;
                break;
            case 5:
                b = 15;
                a = 999900;
                break;
        }
        if (Singleton.getInstance.money >= a)
        {
            Singleton.getInstance.money -= a;
            Singleton.getInstance.skill1lv++;
            switch (Singleton.getInstance.skill1lv)
            {
                case 0:
                    a = 300;
                    b = 1.5f;
                    break;
                case 1:
                    a = 600;
                    b = 2;
                    break;
                case 2:
                    a = 1200;
                    b = 4;
                    break;
                case 3:
                    a = 2400;
                    b = 6;
                    break;
                case 4:
                    a = 4800;
                    b = 9;
                    break;
                case 5:
                    b = 15;
                    a = 999900;
                    break;
            }
            needmoney_t.text = a.ToString() + "g";
            upmoney_t.text = Singleton.getInstance.money.ToString() + " G";
            power_t.text = b.ToString();
            PlayerPrefs.SetInt("SKill1", Singleton.getInstance.skill1lv);
            PlayerPrefs.SetInt("Money", Singleton.getInstance.money);
            PlayerPrefs.SetInt("BerserkerLevel", Singleton.getInstance.Level);
            PlayerPrefs.Save();
        }
    }
}
