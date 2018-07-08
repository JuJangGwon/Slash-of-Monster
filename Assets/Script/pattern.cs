using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pattern : MonoBehaviour {

    float _time = 0;
    public GameObject Canvas;
    public GameObject box;
    public GameObject CommenView;
    public GameObject skill1CommenView;
    // 프리팹;
    public GameObject Blind_pf;
    public GameObject MonsterParents;
    public GameObject Character;

    public GameObject[] arrows = new GameObject[10];
    GameObject[] Spawn = new GameObject[12];

    GameObject[] skill1_blind = new GameObject[3];
    GameObject[] skill1_spawn = new GameObject[3];

    public Animator Character_animator;

    int[] bayule = new int[12];
    int[] boss_Gesture = new int[10];
    int index = 0;

    void Start () {

        // for (int i=0; i<10;i++)
        //{
        //    bayule[i] = Random.Range(0, 10);
        //    Spawn[i] = Instantiate(arrows[bayule[i]]) as GameObject;
        //    Spawn[i].transform.SetParent(CommenView.transform);
        //    Spawn[i].transform.localPosition = new Vector3(-310 + i * 110, 0, 0);
        //    Spawn[i].transform.localScale = new Vector3(0.8f, 0.8f, 1);
        //     Debug.Log(bayule[i]);
        //}
     //   Character_animator = Character.GetComponent<Animator>();
	}
	void Update () {
        if(Singleton.getInstance.untouched == false)
        {
            _time += Time.smoothDeltaTime;
            if (_time > 2) Singleton.getInstance.untouched = true;
        }
        if ((int)Singleton.getInstance.Gesture_i == bayule[0] && Singleton.getInstance.mode == 1)   // 제스쳐가 처맞았을때
        {
            Debug.Log("Clear");
            Destroy(Spawn[0]);
            for (int i = 0; i < 9; i++)
            {
                bayule[i] = bayule[i + 1];
                Spawn[i] = Spawn[i + 1];
            }
            bayule[9] = Random.Range(0, 10);
            Spawn[9] = Instantiate(arrows[bayule[9]]) as GameObject;
            Spawn[9].transform.SetParent(CommenView.transform);
            Spawn[9].transform.localPosition = new Vector3(680, 0, 0);
            Spawn[9].transform.localScale = new Vector3(0.8f, 0.8f, 1);
            Singleton.getInstance.Gesture_i = Gesture.none;
            Singleton.getInstance.attacks = true;
        }
        else if(Singleton.getInstance.mode == 2 && Singleton.getInstance.skill1_start == true) 
        {
            Debug.Log(Singleton.getInstance.skill_shootbullet);

           if(Singleton.getInstance.Gesture_i != Gesture.none)
            {
                Singleton.getInstance.Gesture_i = Gesture.none;
                Singleton.getInstance.skill_shootbullet++;
            }
        }
        for(int i = 0; i<10; i++)
        {
        //   Spawn[i].transform.localPosition = Vector3.Lerp(Spawn[i].transform.localPosition, new Vector3(-310 + 110*i, 0, 0), Time.smoothDeltaTime*15);
        }
	}
  
    //void Skills(int index)
    //{
    //}
    int code(Gesture a)
    {
        int cs = -1;
        switch(a)
        {
            case Gesture.leftup:
                cs = 0;
                break;
            case Gesture.up:
                cs = 1;
                break;

        }
        return cs;
    }
    public void attack(int a)
    {
        Singleton.getInstance.Gesture_i = Gesture.none;
        switch (a)
        {
            case 1:
                GameObject boxs = Instantiate(box, transform.position, Quaternion.Euler(0, 0, 8));
                boxs.transform.SetParent(Canvas.transform);
                boxs.transform.localScale = new Vector3(1, 1, 1);
                boxs.transform.localPosition = new Vector3(0, -100, 0);

                for (int i = 0; i < 3; i++)
                {
                    int rand = Random.Range(0, 10);
                    GameObject item = Instantiate(arrows[rand], transform.position, transform.rotation);
                    item.transform.SetParent(boxs.transform);
                    item.transform.localScale = new Vector3(1, 1, 1);
                    item.transform.localPosition = new Vector3(-200 + i * 200, 0, 0);
                    boss_Gesture[index] = rand;
                    index++;
                }
                break;
            case 2:
                GameObject boxs2 = Instantiate(box, transform.position, Quaternion.Euler(0, 0, -8));
                boxs2.transform.SetParent(Canvas.transform);
                boxs2.transform.localScale = new Vector3(1, 1, 1);
                boxs2.transform.localPosition = new Vector3(0, 100, 0);

                for (int i = 0; i < 3; i++)
                {
                    int rand = Random.Range(0, 10);
                    GameObject item = Instantiate(arrows[rand], transform.position, transform.rotation);
                    item.transform.SetParent(boxs2.transform);
                    item.transform.localScale = new Vector3(1, 1, 1);
                    item.transform.localPosition = new Vector3(-200 + i * 200, 0, 0);
                    boss_Gesture[index] = rand;
                    index++;
                }
                break;
            case 3:
                GameObject boxs3 = Instantiate(box, transform.position, Quaternion.Euler(0, 0, -8));
                boxs3.transform.SetParent(Canvas.transform);
                boxs3.transform.localScale = new Vector3(1, 1, 1);
                boxs3.transform.localPosition = new Vector3(0, 100, 0);

                for (int i = 0; i < 3; i++)
                {
                    int rand = Random.Range(0, 10);
                    GameObject item = Instantiate(arrows[rand], transform.position, transform.rotation);
                    item.transform.SetParent(boxs3.transform);
                    item.transform.localScale = new Vector3(1, 1, 1);
                    item.transform.localPosition = new Vector3(-200 + i * 200, 0, 0);
                    boss_Gesture[index] = rand;
                    index++;
                }
                break;
        }      
    }
    public void Create()
    {
        for (int i = 0; i < 3; i++)
        {
            skill1_spawn[i] = Instantiate(arrows[i], transform.position, transform.rotation);
            skill1_spawn[i].transform.SetParent(skill1CommenView.transform);
            skill1_spawn[i].transform.localScale = new Vector3(1, 1, 1);
            skill1_spawn[i].transform.localPosition = new Vector3(-200 + 200*i, 0, 0);
        }
        for (int i = 0; i < 3; i++)
        {
            skill1_blind[i] = Instantiate(Blind_pf, transform.position, transform.rotation);
            skill1_blind[i].transform.SetParent(skill1CommenView.transform);
            skill1_blind[i].transform.localScale = new Vector3(1, 1, 1);
            skill1_blind[i].transform.localPosition = new Vector3(-200 + 200 * i, 0, 0);
        }
    }
}
