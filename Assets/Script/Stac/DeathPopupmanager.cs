using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathPopupmanager : MonoBehaviour {

    public GameObject Character;

    public GameObject CharacterDeathPopup;
    public GameObject Canvas;
    public GameObject death_show;
    public GameObject mid;
    public GameObject worldmap;

    public GameObject npc;
    public GameObject Grandfa;
    public GameObject SKill1;
    public GameObject SKill2;
    Image death_show_img;
    MapSelector mapselector_sc;
    Animator Anim;

    Image img;
    Animator CharacaterDeathPoup_anim;
    Ingame ingame_cs;

    void Awake()
    {
        Anim = Character.GetComponent<Animator>();

        ingame_cs = Canvas.GetComponent<Ingame>();
        death_show_img = death_show.GetComponent<Image>();
        mapselector_sc = Canvas.GetComponent<MapSelector>();
        CharacaterDeathPoup_anim = CharacterDeathPopup.GetComponent<Animator>();
    }
	public void alive(int i)
    {
        if(i == 1)
        {
            Singleton.getInstance.stage = 999;
            ingame_cs.ChangeMap(Singleton.getInstance.stage);
            CharacaterDeathPoup_anim.SetTrigger("turnoff");
            SKill1.SetActive(false);
            SKill2.SetActive(false);
            Grandfa.SetActive(true);
            npc.SetActive(true);
            StartCoroutine(en());
        }
    }
    IEnumerator en()
    {
        if (Singleton.getInstance.OOO == true)
        {
            Singleton.getInstance.OOO = false;
            Anim.SetTrigger("diefalse");
        }
        yield return new WaitForSeconds(1.3f);
        while (death_show_img.color.a >= 0)
        {
            float a = death_show_img.color.a;
            death_show_img.color = new Vector4(0, 0, 0, a - 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        mid.transform.localPosition = new Vector3(-24,0,0);
        CharacterDeathPopup.SetActive(false);
        worldmap.SetActive(true);
        yield return null;
    }
}
