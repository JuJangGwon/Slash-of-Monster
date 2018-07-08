using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    int i = 0;
    int d = 0;
    public GameObject blackScreen;
    public GameObject[] iv = new GameObject[6];
    public GameObject[] iv_1 = new GameObject[2];
    public GameObject[] iv_2 = new GameObject[3];
    public GameObject[] iv_3 = new GameObject[3];
    public GameObject[] iv_4 = new GameObject[3];
    public GameObject[] iv_5 = new GameObject[4];
    public GameObject[] iv_6 = new GameObject[4];

    bool iv_bool;

    void Awake()
    {
  
    }
    void Update()
    {
        if(iv_bool == true)
        {
            switch(d)
            {
                case 1:
                if (i == 0)
                {
                    iv_1[0].SetActive(true);
                    iv_1[1].SetActive(false);
                    if (Input.GetMouseButtonUp(0))
                    {
                        i = 1;
                        iv_1[0].SetActive(false);
                        iv_1[1].SetActive(true);
                    }
                }
                if (i == 1)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        i = 0;
                        iv_bool = false;
                        StartCoroutine(StageChangeEffect_corutine2());
                    }
                }
                break;
                case 2:
                    if (i == 0)
                    {
                        iv_2[0].SetActive(true);
                        iv_2[1].SetActive(false);
                        iv_2[2].SetActive(false);

                        if (Input.GetMouseButtonUp(0))
                        {
                            i = 1;
                            iv_2[0].SetActive(false);
                            iv_2[1].SetActive(true);
                        }
                    }
                    else if (i == 1)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            i = 2;
                            iv_2[1].SetActive(true);
                            iv_2[2].SetActive(false);
                        }
                    }
                    else if (i == 2)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            i = 0;
                            iv_bool = false;
                            StartCoroutine(StageChangeEffect_corutine2());
                        }
                    }
                    break;
                case 3:
                    if (i == 0)
                    {
                        iv_3[0].SetActive(true);
                        iv_3[1].SetActive(false);
                        iv_3[2].SetActive(false);

                        if (Input.GetMouseButtonUp(0))
                        {
                            i = 1;
                            iv_3[0].SetActive(false);
                            iv_3[1].SetActive(true);
                        }
                    }
                    else if (i == 1)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            i = 2;
                            iv_3[1].SetActive(true);
                            iv_3[2].SetActive(false);
                        }

                    }
                   else if (i == 2)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            i = 0;
                            iv_bool = false;
                            StartCoroutine(StageChangeEffect_corutine2());
                        }
                    }
                    break;
                case 4:
                    if (i == 0)
                    {
                        iv_4[0].SetActive(true);
                        iv_4[1].SetActive(false);
                        if (Input.GetMouseButtonUp(0))
                        {
                            i = 1;
                            iv_4[0].SetActive(false);
                            iv_4[1].SetActive(true);
                        }
                    }
                    else if(i ==1)
                    {
                        if(Input.GetMouseButtonUp(0))
                        {
                            i = 2;
                            iv_4[1].SetActive(false);
                            iv_4[2].SetActive(true);
                        }
                    }
                    else if (i == 2)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            i = 0;
                            iv_bool = false;
                            StartCoroutine(StageChangeEffect_corutine2());
                        }
                    }
                    break;
                case 5:
                    if (i == 0)
                    {
                        iv_5[0].SetActive(true);
                        iv_5[1].SetActive(false);
                        iv_5[2].SetActive(false);
                        iv_5[3].SetActive(false);
                        if (Input.GetMouseButtonUp(0))
                        {
                            i = 1;
                            iv_5[0].SetActive(false);
                            iv_5[1].SetActive(true);
                        }
                    }
                    else if (i == 1)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            i = 2;
                            iv_5[1].SetActive(false);
                            iv_5[2].SetActive(true);
                        }
                    }
                    else if (i == 2)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            i = 3;
                            iv_5[2].SetActive(false);
                            iv_5[3].SetActive(true);
                        }
                    }
                   else  if (i == 3)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            i = 0;
                            iv_bool = false;
                            StartCoroutine(StageChangeEffect_corutine2());
                        }
                    }
                    break;
                case 6:
                    if (i == 0)
                    {
                        iv_6[0].SetActive(true);
                        iv_6[1].SetActive(false);
                        iv_6[2].SetActive(false);
                        iv_6[3].SetActive(false);
                        if (Input.GetMouseButtonUp(0))
                        {
                            i = 1;
                            iv_6[0].SetActive(false);
                            iv_6[1].SetActive(true);
                        }
                    }
                    else if (i == 1)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            i = 2;
                            iv_6[1].SetActive(false);
                            iv_6[2].SetActive(true);
                        }
                    }
                    else if (i == 2)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            i = 3;
                            iv_6[2].SetActive(false);
                            iv_6[3].SetActive(true);
                        }
                    }
                   else if (i == 3)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            i = 0;
                            iv_bool = false;
                            StartCoroutine(StageChangeEffect_corutine2());
                        }
                    }
                    break;
            }
        }
    }
    public void akak(int i)
    {
        d = i;
        StartCoroutine(StageChangeEffect_corutine());
    }
    IEnumerator StageChangeEffect_corutine()
    {
        Singleton.getInstance.untouched = false;
        float duration = 1.5f;
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        blackScreen.transform.localPosition = new Vector3(1196, 0, -2);
        while (duration > 0.0f)
        {
            duration -= Time.deltaTime;
            blackScreen.transform.localPosition = Vector3.MoveTowards(blackScreen.transform.localPosition, new Vector3(70, 0, -2), 1600 * Time.smoothDeltaTime);
            yield return waitForEndOfFrame;
        }

        //
        iv[d-1].SetActive(true);
        iv_bool = true;
        //

        yield return new WaitForSeconds(0.1f);
        duration = 2;
        while (duration > 0.0f)
        {
            duration -= Time.deltaTime;
            blackScreen.transform.localPosition = Vector3.MoveTowards(blackScreen.transform.localPosition, new Vector3(-1200, 0, -2), 1600 * Time.smoothDeltaTime);
            yield return waitForEndOfFrame;
        }
        Singleton.getInstance.untouched = true;
    }
    IEnumerator StageChangeEffect_corutine2()
    {
        Singleton.getInstance.untouched = false;
        float duration = 1.5f;
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        blackScreen.transform.localPosition = new Vector3(1196, 0, -2);
        while (duration > 0.0f)
        {
            duration -= Time.deltaTime;
            blackScreen.transform.localPosition = Vector3.MoveTowards(blackScreen.transform.localPosition, new Vector3(70, 0, -2), 1600 * Time.smoothDeltaTime);
            yield return waitForEndOfFrame;
        }

        //
        for (int i = 0; i < 6; i++)
        {
            iv[i].SetActive(false);
        }

        //

        yield return new WaitForSeconds(0.1f);
        duration = 2;
        while (duration > 0.0f)
        {
            duration -= Time.deltaTime;
            blackScreen.transform.localPosition = Vector3.MoveTowards(blackScreen.transform.localPosition, new Vector3(-1200, 0, -2), 1600 * Time.smoothDeltaTime);
            yield return waitForEndOfFrame;
        }
        Singleton.getInstance.untouched = true;
    }
}
