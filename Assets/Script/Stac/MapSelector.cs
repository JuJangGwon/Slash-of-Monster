using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelector : MonoBehaviour {

    public GameObject Camera_gb;
    public AudioClip Inanis_sound1;
    public AudioClip Inanis_sound2;
    public AudioClip WorldTreeSound;
    public AudioClip Ac;
    public GameObject MapName_gb;
    Text MapName_text;

    AudioSource Camera_AudioSource;

    public GameObject Upper_map;
    public GameObject Popup;

    public GameObject Now_using_map;
    public GameObject Map_parents;

    public GameObject Buttons;
    PopupButton pb_sc;

    public GameObject[] Map = new GameObject[20];
    public GameObject WorldTreeMap;

    Ingame ingame_sc;

    void Awake()
    {
        Camera_AudioSource = Camera_gb.GetComponent<AudioSource>();
        pb_sc = Buttons.GetComponent<PopupButton>();
        ingame_sc = GetComponent<Ingame>();
        // As = Camera.GetComponent<AudioSource>();
        MapName_text = MapName_gb.GetComponent<Text>();
    }
    public void closemap()
    {
        Debug.Log("closemap");
        Upper_map.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(MoveCoroutine(new Vector2(0, -500), 1));
    }

    public void MapSelect(int stage)
    {
        Singleton.getInstance.untouched = true;
        if(Singleton.getInstance.Popup_open == true) closemap();
        else
        {
            Singleton.getInstance.GameMode = true;
            Singleton.getInstance.GameState = GameState.PlayNormal;
            ingame_sc.ShowMapName();
            pb_sc.Clear(6);
        }
        if (Now_using_map != null) Destroy(Now_using_map);
        if (Singleton.getInstance.world == 1)
        {
            if (stage == 1 || stage == 2)   
            {
                Now_using_map = Instantiate(Map[0]);
                Camera_AudioSource.clip = Inanis_sound2;
                Camera_AudioSource.Play();
            }
            else if (stage == 3 || stage == 4)
            {
                Now_using_map = Instantiate(Map[1]);
                Camera_AudioSource.clip = Inanis_sound2;
                Camera_AudioSource.Play();
            }
            else if (stage == 5 || stage == 6)
            {
                Now_using_map = Instantiate(Map[2]);
                Camera_AudioSource.clip = Inanis_sound2;
                Camera_AudioSource.Play();
            }
            else if (stage == 7)
            {
                Now_using_map = Instantiate(Map[3]);
                Camera_AudioSource.clip = Inanis_sound1;
                Camera_AudioSource.Play();
            }
            else if(stage == 999)
            {
                Singleton.getInstance.myworld = World.WorldTree;
                Now_using_map = Instantiate(WorldTreeMap);
                Camera_AudioSource.clip = WorldTreeSound;
                Camera_AudioSource.Play();
            }
        }
        Now_using_map.transform.SetParent(Map_parents.transform);
        Now_using_map.transform.localScale = new Vector3(1, 1, 1);
        Now_using_map.transform.localPosition = new Vector3(0, 635, 0);
    }
    IEnumerator MoveCoroutine(Vector2 endPos, float duration)
    {
        yield return new WaitForSeconds(0.6f);
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        Vector2 startPos = Popup.transform.localPosition;
        while (duration > 0.0f)
        {
            duration -= Time.deltaTime;
            Popup.transform.localPosition = Vector2.Lerp(Popup.transform.localPosition, endPos, Time.smoothDeltaTime * 5f);
            yield return waitForEndOfFrame;
        }
        Popup.transform.localPosition = endPos;
        Singleton.getInstance.GameMode = true;
        Singleton.getInstance.GameState = GameState.PlayNormal;
        ingame_sc.ShowMapName();
        Singleton.getInstance.Popup_open = false;
        Singleton.getInstance.i = -1;
        pb_sc.Clear(6);
        yield return null;
    }
}
