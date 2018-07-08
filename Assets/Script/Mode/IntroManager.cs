using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {

    public int state = 0;
    public GameObject blackImage;

    public GameObject gb1;
    public GameObject gb2;
    public GameObject gb3;
    public GameObject gb4;
    public GameObject gb5;
    Animator gb1_anim;
    Animator gb2_anim;
    Animator gb3_anim;
    Animator gb4_anim;
    Animator gb5_anim;

    private Text Selected_text;

    public GameObject s1_t;
    Text sl_text;
    public GameObject s2_t;
    Text s2_text;
    public GameObject s2_1t;
    Text s2_1text;
    public GameObject s3_1t;
    Text s3_1text;
    public GameObject s3_2t;
    Text s3_2text;
    public GameObject s4_1t;
    Text s4_1text;
    public GameObject s4_2t;
    Text s4_2text;
    public GameObject s5_1t;
    Text s5_1text;
    public GameObject s5_2t;
    Text s5_2text;

    void Awake()
    {
        int id = PlayerPrefs.GetInt("ShowIntro");
        if (id != 0) Application.LoadLevel("InGame11");
        Screen.SetResolution(540, 960, false);

        gb1_anim = gb1.GetComponent<Animator>();
        gb2_anim = gb2.GetComponent<Animator>();
        gb3_anim = gb3.GetComponent<Animator>();
        gb4_anim = gb4.GetComponent<Animator>();
        gb5_anim = gb5.GetComponent<Animator>();
        sl_text = s1_t.GetComponent<Text>();
        s2_text = s2_t.GetComponent<Text>();
        s2_1text = s2_1t.GetComponent<Text>();
        s3_1text = s3_1t.GetComponent<Text>();
        s3_2text = s3_2t.GetComponent<Text>();
        s4_1text = s4_1t.GetComponent<Text>();
        s4_2text = s4_2t.GetComponent<Text>();
        s5_1text = s5_1t.GetComponent<Text>();
        s5_2text = s5_2t.GetComponent<Text>();
    }
    public void Start()
    {
        switch (state)
        {
            // 1
            case 0:
                gb1.SetActive(true);
                state++;
                Invoke("Start", 1.5f);
                break;
            case 1:
                s1_t.SetActive(true);
                StartCoroutine("FadeIn", sl_text);
                state++;
               Invoke("Start", 4.6f);
                break;
            case 2:
                gb1_anim.SetTrigger("disappear");
                state++;
                Invoke("Start", 1.2f);
                break;
            case 3:
                StartCoroutine("FadeOut", sl_text);
                state++;
                Invoke("Start", 2);             
                break;
            case 4:
                gb1.SetActive(false);
                gb2.SetActive(true);
                state++;
                Invoke("Start", 1.5f);
                break;
            case 5:
                s2_t.SetActive(true);
                StartCoroutine("FadeIn", s2_text);
                state++;
                Invoke("Start", 3f);
                break;
            case 6:
                s2_1t.SetActive(true);
                StartCoroutine("FadeOut", s2_text);
                StartCoroutine(MoveCoroutine(s2_1text,new Vector2(0,-275),2.2f));
                StartCoroutine("FadeIn", s2_1text);
                state++;
                Invoke("Start", 1.2F);
                break;
            case 7:
                gb2_anim.SetTrigger("disappear");
                state++;
                Invoke("Start", 0.5f);
                break;
            case 8:
                state++;
                Invoke("Start", 1);
                break;
            case 9:
                gb2.SetActive(false);
                StartCoroutine("FadeOut", s2_1text);
                state++;
                Invoke("Start", 2);
                break;
            case 10:
                s3_1t.SetActive(true);
                StartCoroutine("FadeIn", s3_1text);
                state++;
                Invoke("Start", 0.35f);
                s2_1t.SetActive(false);
                s2_t.SetActive(false);
                break;
            case 11:
                gb3.SetActive(true);
                state++;
                Invoke("Start", 3.9f);
                break;
            case 12:
                s3_2t.SetActive(true);
                StartCoroutine("FadeOut", s3_1text);
                state = 999;
                Invoke("Start", 1.3f);
                break;
            case 999:
                StartCoroutine("FadeIn", s3_2text);
                state = 13;
                Invoke("Start", 3.5f);
                break;
            case 13:
                gb3_anim.SetTrigger("disappear");
                state++;
                Invoke("Start", 0.6f);
                break;
            case 14:
                StartCoroutine("FadeOut", s3_2text);
                state++;
                Invoke("Start", 2f);
                break;
            case 15:
                gb4.SetActive(true);
                state++;
                Invoke("Start",0.8f);
                break;
            case 16:
                s4_1t.SetActive(true);
                StartCoroutine("FadeIn", s4_1text);
                state = 998;
                Invoke("Start", 3.6f);
                break;
            case 998:
                StartCoroutine("FadeOut", s4_1text);
                gb4_anim.SetTrigger("go");
                state = 997;
                Invoke("Start",0.2f);
                break;
            case 997:
                state = 17;
                Invoke("Start", 2.8f);
                break;
            case 17:
                s4_2t.SetActive(true);
                StartCoroutine("FadeIn", s4_2text);
                state++;
                Invoke("Start", 3f);
                break;
            case 18:
                state++;
                Invoke("Start", 0.2f);
                break;
            case 19:
                gb4_anim.SetTrigger("disappear");
                state++;
                Invoke("Start", 0.3f);
                break;
            case 20:
                s4_1t.SetActive(false);
                StartCoroutine("FadeOut", s4_2text);
                state++;
                Invoke("Start", 3);
                break;
            case 21:
                s4_2t.SetActive(false);
                state++;
                Invoke("Start", 1.4f);
                break;
            case 22:
                gb5.SetActive(true);
                s5_1t.SetActive(true);
                StartCoroutine("FadeIn", s5_1text);
                state = 995;
                Invoke("Start",3.7f);
                break;
            case 995:
                StartCoroutine("FadeOut", s5_1text);
                state = 23;
                Invoke("Start", 0.9f);
                break;
            case 23:
                s5_2t.SetActive(true);
                StartCoroutine("FadeIn", s5_2text);
                state++;
                Invoke("Start", 3.1f);
                break;
            case 24:
                state++;
                Invoke("Start", 0.8f);
                break;
            case 25:
                gb5_anim.SetTrigger("disappear");
                state++;
                Invoke("Start", 0.8f);
                break;
            case 26:
                s5_1t.SetActive(false);
                StartCoroutine("FadeOut", s5_2text);
                state++;
                Invoke("Start", 3f);
                break;
            case 27:
                PlayerPrefs.SetInt("Money",1000);
                PlayerPrefs.SetInt("ShowIntro",5);
                PlayerPrefs.Save();
                Application.LoadLevel("InGame11");
                break;
        }
    }
    IEnumerator FadeIn(Text text)
    {
         for (float i = 0f; i <= 1; i += 0.03f)
         {
             Color color = new Vector4(1, 1, 1, i);
            text.color = color;
             yield return 0;
         }
    
    }
    IEnumerator MoveCoroutine(Text text,Vector2 endPos, float duration)
    {
        while (text.transform.localPosition.y < endPos.y)
        {
            text.transform.localPosition += new Vector3(0, 2);
            yield return new WaitForSeconds(0.002f);
        }
        yield return null;
    }
    IEnumerator FadeOut(Text text)
    {
         for (float i = 1f; i >= 0; i -= 0.02f)
         {
             Color color = new Vector4(1, 1, 1, i);
             text.color = color;
             yield return 0;
         }
    }
}
