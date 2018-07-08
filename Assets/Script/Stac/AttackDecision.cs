using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackDecision : MonoBehaviour {

    int skill1 = 20;
    int skill2 = 10;

    float _time = 0;

    bool finishskill = false;
    public int useskill = 0;
    public int skill_gauge = 0;
    public GameObject Character;
    public GameObject Gesture_boom_effect_pf;
    public GameObject buffup;

    public GameObject Gesture_boom_effect_parents;
    Animator charactor_animator;

    MonsterMananger monstermanager_cs;
    BossManager bossmanager_cs;
    Sound sound_sc;

    Image selectedImage;

    public GameObject sk1;
    public GameObject sk2;

    Image sk11;
    Image sk22;

    public AudioClip ac1;
    public AudioClip ac2;

    AudioSource acs;

    void Awake()
    {
        sk11 = sk1.GetComponent<Image>();
        sk22 = sk2.GetComponent<Image>();
        acs = GetComponent<AudioSource>();
        bossmanager_cs = GetComponent<BossManager>();
        sound_sc = GetComponent<Sound>();
        charactor_animator = Character.GetComponent<Animator>();
        monstermanager_cs = GetComponent<MonsterMananger>();
    }
    void aaa()
    {
        charactor_animator.SetTrigger("cancle");    
        useskill = 0;
        skill_gauge = 0;
        Singleton.getInstance.useSKill = false;
    }
    void Update()
    {
        if (Singleton.getInstance.skill1Cooltime > 0)
        {
            sk1.SetActive(true);
            _time += Time.smoothDeltaTime;
            if(_time >1)
            {
                Singleton.getInstance.skill1Cooltime -= 1;
                _time = 0;
                sk11.fillAmount = ((float)Singleton.getInstance.skill1Cooltime / (float)skill1);
            }
        }
        else
        {
            sk1.SetActive(false);
        }
        if (Singleton.getInstance.skill2Cooltime > 0)
        {
            Debug.Log(Singleton.getInstance.skill2Cooltime);
            sk2.SetActive(true);
            _time += Time.smoothDeltaTime;
            if (_time > 1)
            {
                Singleton.getInstance.skill2Cooltime -= 1;
                _time = 0;
                sk22.fillAmount = ((float)Singleton.getInstance.skill2Cooltime / (float)skill2);
            }
        }
        else
        {
            sk2.SetActive(false);
        }

    }

    public void Attack_Decision(Result Result_Gesture)
    {
        if (Singleton.getInstance.GameState == GameState.PlayBoss)
        {
            Debug.Log(Result_Gesture);
            if (Result_Gesture == Result.Circle && Singleton.getInstance.useSKill == false && Singleton.getInstance.skill2lv > 0 && Singleton.getInstance.skill2Cooltime <1)
            {
                Debug.Log("파멸의일격");               
                useskill = 1;
                skill_gauge = 1;
                Debug.Log(skill_gauge);
                Singleton.getInstance.useSKill = true;
                charactor_animator.SetTrigger("skill1");
                acs.clip = ac1;
                acs.Play();
            }
            else if(Result_Gesture == Result.triangle1 && Singleton.getInstance.useSKill == false && Singleton.getInstance.skill1lv > 0 && Singleton.getInstance.skill1Cooltime < 1)
            {
                Debug.Log("강해져랏!");

                Singleton.getInstance.useSKill = true;
                useskill = 2;
                skill_gauge = 1;
            }
            else if (Singleton.getInstance.useSKill == true)
            {
                 Debug.Log("들옴");
                if (useskill == 1)
                {
                    if (skill_gauge == 1)
                    {
                        if (Result_Gesture == Result.Z)
                        {
                            Debug.Log(skill_gauge);
                            charactor_animator.SetTrigger("skill2");
                            skill_gauge = 2;
                            acs.clip = ac1;
                            acs.Play();
                        }
                        else
                        {
                            Singleton.getInstance.useSKill = false;
                            skill_gauge = 0;
                            useskill = 0;
                            charactor_animator.SetTrigger("cancle");
                        }
                    }
                    else if (skill_gauge == 2)
                    {
                        if (Result_Gesture == Result.Z)
                        {
                            Singleton.getInstance.skill2Cooltime = 10;

                            Debug.Log(skill_gauge);
                            skill_gauge = 0;
                            useskill = 0;
                            Singleton.getInstance.useSKill = false;
                            charactor_animator.SetTrigger("skill3");
                            bossmanager_cs.Boss_hitby(2);
                            acs.clip = ac2;
                            acs.Play();
                            finishskill = true;
                        }
                        else
                        {
                            charactor_animator.SetTrigger("cancle");
                            Singleton.getInstance.useSKill = false;
                            skill_gauge = 0;
                            useskill = 0;
                        }
                    }
                }
                else if(useskill == 2)
                {
                    if (skill_gauge == 1)
                    {
                        if (Result_Gesture == Result.down)
                        {
                            Singleton.getInstance.skill1Cooltime = 20;
                            skill_gauge = 0;
                            useskill = 0;
                            Singleton.getInstance.useSKill = false;
                            StartCoroutine(enu());
                        }
                        else
                        {
                            skill_gauge = 0;
                            useskill = 0;
                            Singleton.getInstance.useSKill = false;
                        }
                    }
                }
            }
            if (Singleton.getInstance.bossState == BossState.normal && Singleton.getInstance.useSKill == false)
            {
                if (finishskill == true)
                {
                    finishskill = false;
                }
                else
                {
                    bossmanager_cs.Boss_hitby(1);
                    CharacterAttackAniamtion(Result_Gesture);
                }
            }
            else if (Singleton.getInstance.bossState == BossState.attack)
            {
                bossmanager_cs.BossattackDecision(Result_Gesture);
            }
        }
        if (Singleton.getInstance.GameState == GameState.PlayNormal)
        {
            if (Singleton.getInstance.WrongRecognize == false)
            {
                if (CreatePattern.Pattern_list_num.Count > 0)
                {
                    if ((int)Result_Gesture == CreatePattern.Pattern_list_num.Peek())
                    {
                        /// boom effect//
                        GameObject boom_effect_gb = Instantiate(Gesture_boom_effect_pf);
                        boom_effect_gb.transform.SetParent(Gesture_boom_effect_parents.transform);
                        boom_effect_gb.transform.localPosition = new Vector3(CreatePattern.Pattern_list[0].transform.localPosition.x - 10, CreatePattern.Pattern_list[0].transform.localPosition.y + 293, -1);
                        boom_effect_gb.transform.localScale = new Vector3(1, 1, 1);
                        Destroy(boom_effect_gb, 0.5f);
                        // 삭제 
                        Debug.Log(CreatePattern.Pattern_list.Count);
                        Destroy(CreatePattern.Pattern_list[0]);
                        CreatePattern.Pattern_list.RemoveRange(0, 1);
                        CreatePattern.Pattern_list_num.Dequeue();
                        Debug.Log(CreatePattern.Pattern_list.Count);

                        CharacterAttackAniamtion(Result_Gesture);
                        monstermanager_cs.Monster_hitby();
                    }
                    else
                    {
                        Fail();
                    }
                }
            }
        }
       
    }
    void Fail()
    {
        Debug.Log("1");
        selectedImage = CreatePattern.Pattern_list[0].GetComponent<Image>();
        StartCoroutine("FailCoruntine", selectedImage);
    }
    IEnumerator enu()
    {
        buffup.SetActive(true);
        Singleton.getInstance.attackbuffup = true;
        yield return new WaitForSeconds(9.7f);
        Singleton.getInstance.attackbuffup = false;
        buffup.SetActive(false);
    }
    IEnumerator FailCoruntine()
    {
        Debug.Log("2");
        Singleton.getInstance.WrongRecognize = true;
        for (int i = 0; i < 7; i++)
        {
            selectedImage.color = new Color32(220, 220, 220, 255);
            yield return new WaitForSeconds(0.07f);
            selectedImage.color = new Color32(150, 150, 150, 255);
            yield return new WaitForSeconds(0.07f);
            selectedImage.color = new Color32(80, 80, 80, 255);
            yield return new WaitForSeconds(0.07f);
            selectedImage.color = new Color32(150, 150, 150, 255);
            yield return new WaitForSeconds(0.07f);
            selectedImage.color = new Color32(220, 220, 220, 255);
            yield return new WaitForSeconds(0.07f);
        }
        selectedImage.color = new Color32(255, 255, 255, 255);
        yield return new WaitForSeconds(0.07f);
        Singleton.getInstance.WrongRecognize = false;
    }
    void CharacterAttackAniamtion(Result Result_Gesture)
    {
        if (Result_Gesture == Result.left || Result_Gesture == Result.leftup || Result_Gesture == Result.leftdown)
        {
            if(Singleton.getInstance.attackbuffup == false) charactor_animator.SetTrigger("attack3");
            else charactor_animator.SetTrigger("ragattack3");
            sound_sc.PlayAttackSound(1);
            if (Singleton.getInstance.GameState == GameState.PlayNormal) Singleton.getInstance.An = AttackAnim.left;
        }
        else if (Result_Gesture == Result.right || Result_Gesture == Result.rightdown || Result_Gesture == Result.rightup)
        {
            if (Singleton.getInstance.attackbuffup == false) charactor_animator.SetTrigger("attack2");
            else charactor_animator.SetTrigger("ragattack2");
            sound_sc.PlayAttackSound(2);
            if (Singleton.getInstance.GameState == GameState.PlayNormal) Singleton.getInstance.An = AttackAnim.right;
        }
        else
        {
            if (Singleton.getInstance.attackbuffup == false) charactor_animator.SetTrigger("attack1");
            else charactor_animator.SetTrigger("ragattack1");
            sound_sc.PlayAttackSound(3);
            if (Singleton.getInstance.GameState == GameState.PlayNormal) Singleton.getInstance.An = AttackAnim.up;
        }
    }

}
