using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldText : MonoBehaviour {

    Text money_text;

    bool usecoruntine = false;

    void Awake()
    {
        money_text = GetComponent<Text>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Gold")
        {
            Singleton.getInstance.money += 3;
            moneytext_toStirng();
            if (usecoruntine == true) StopCoroutine(shake());
            StartCoroutine(shake());
            PlayerPrefs.SetInt("Money", Singleton.getInstance.money);
            PlayerPrefs.Save();
        }
    }

    void moneytext_toStirng()
    {
        money_text.text = Singleton.getInstance.money.ToString() + " G";
    }

    IEnumerator shake()
    {
        usecoruntine = true;
        transform.rotation = Quaternion.Euler(0, 10, 13);
        yield return new WaitForSeconds(0.04f);
        transform.rotation = Quaternion.Euler(0, -10, -6);
        yield return new WaitForSeconds(0.04f);
        transform.rotation = Quaternion.Euler(0, 0, 13);
        yield return new WaitForSeconds(0.04f);  
        transform.rotation = Quaternion.Euler(0, 0, 0);
        usecoruntine = false;
    }
}
