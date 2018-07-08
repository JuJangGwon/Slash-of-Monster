using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Skeel : MonoBehaviour {

    int Pattern = -1;
    public GameObject Aim;
    public GameObject CommenView;
    public GameObject skill1CommenView;
    public GameObject GameScreen;
    pattern patterns;
    Image CommenView_img;
    Image SKill1_CommenView_img;
    float time;
    
    void Start () {
        CommenView_img = CommenView.GetComponent<Image>();
      //  SKill1_CommenView_img = skill1CommenView.GetComponent<Image>();
        patterns = transform.GetComponent<pattern>();
    }

    void Update () {
        if (Singleton.getInstance.mode == 2)
            skill1();
        
	}
    void skill1()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Pattern = 17;
        }
        if (Pattern == -1)
        {
            Singleton.getInstance.skill_shootbullet = 0;
            Singleton.getInstance.mode = 2;
            StartCoroutine("FadeOut", CommenView_img);
            Pattern++;
        }
        if (Pattern == 0)
        {
            time += Time.smoothDeltaTime;
            if (time > 0.5f) Pattern = 1;

        }
        else if (Pattern == 1)
        {
            Aim.SetActive(true);
            Aim.transform.localPosition = Vector3.Lerp(Aim.transform.localPosition, new Vector3(-193, -208, 0), 0.08f);
            if (Aim.transform.localPosition.x < -170)
            {
                Pattern = 2;
                StartCoroutine("FadeIn", SKill1_CommenView_img);
            }
        }
        else if (Pattern == 2)
        {
            skill1CommenView.SetActive(true);
            Aim.transform.localPosition = Vector3.Lerp(Aim.transform.localPosition, new Vector3(-266, 17, 0), 0.08f);
            if (Aim.transform.localPosition.x < -250) Pattern = 3;
        }
        else if (Pattern == 3)
        {
            Aim.transform.localPosition = Vector3.Lerp(Aim.transform.localPosition, new Vector3(133, -244, 0), 0.08f);
            if (Aim.transform.localPosition.x > 120) Pattern = 4;
        }
        else if (Pattern == 4)
        {
            Aim.transform.localPosition = Vector3.Lerp(Aim.transform.localPosition, new Vector3(210, 110, 0), 0.08f);
            if (Aim.transform.localPosition.x > 196)
            {
                Pattern = 5;
                Singleton.getInstance.Gesture_i = Gesture.none;
                patterns.Create();
            }
        }
        else if (Pattern == 5)
        {
            time += Time.smoothDeltaTime;
            if (time > 1)
            {
                Singleton.getInstance.skill1_start = true;
                Aim.transform.localPosition = Vector3.Lerp(Aim.transform.localPosition, new Vector3(-67, -87, 0), 0.05f);
            }
            if (Singleton.getInstance.skill_shootbullet == 1) Pattern = 7;
        }
        else if (Pattern == 7)
        {
            Aim.transform.localPosition = Vector3.Lerp(Aim.transform.localPosition, new Vector3(-267, -87, 0), 0.05f);
            if (Aim.transform.localPosition.x < -265) Pattern = 8;
            if (Singleton.getInstance.skill_shootbullet == 2) Pattern = 9;
        }
        else if (Pattern == 8)
        {
            if (Singleton.getInstance.skill_shootbullet == 2) Pattern = 9;
        }
        else if (Pattern == 9)
        {
            Aim.transform.localPosition = Vector3.Lerp(Aim.transform.localPosition, new Vector3(160, -87, 0), 0.1f);
            if (Aim.transform.localPosition.x > 132) Pattern = 10;
            if (Singleton.getInstance.skill_shootbullet == 3) Pattern = 11;
        }
        else if (Pattern == 10)
        {
            if (Singleton.getInstance.skill_shootbullet == 3) Pattern = 11;
        }
        else if (Pattern == 11)
        {
            Singleton.getInstance.mode = 3;
            Singleton.getInstance.skill1_start = false;
        }
        else if (Pattern == 17)
        {
            StartCoroutine("CanvasShake");
            Debug.Log("CANV");
            Pattern = 6;
        }
    }
    IEnumerator FadeOut(Image img)
    {
        for (float i = 1f; i >= 0; i -= 0.1f)
        {
            Color color = new Vector4(1, 1, 1, i);
            img.color = color;
            yield return 0;
        }
    }
    IEnumerator FadeIn(Image img)
    {
        for (float i = 0; i <= 255; i += 0.1f)
        {
            Color color = new Vector4(img.color.r, img.color.g, img.color.b, i);
            img.color = color;
            yield return new WaitForSeconds(0.03f);
        }
    }
    IEnumerator CanvasShake()
    {
        Debug.Log("CANVASSHAKE");
        for (float i = 1f; i <= 6; i ++)
        {
            if (i % 4 == 0) GameScreen.transform.localPosition  = new Vector3(0, i* 1.6f, 0);
            if (i % 4 == 1) GameScreen.transform.localPosition = new Vector3(0, -i * 1.6f, 0);
            if (i % 4 == 2) GameScreen.transform.localPosition = new Vector3(0, i * 1.6f, 0);
            if (i % 4 == 3) GameScreen.transform.localPosition = new Vector3(0, -i * 1.6f, 0);

            yield return new WaitForSeconds(0.018f);
        }
        GameScreen.transform.localPosition = new Vector3(0, 0, 0);
        yield return 0;
    }
}
