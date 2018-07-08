using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreatePattern : MonoBehaviour {

    public GameObject[] Gesture_pf = new GameObject[13]; 
    public GameObject Pattern_parent;
    public static List<GameObject> Pattern_list = new List<GameObject>();
    public static Queue<int> Pattern_list_num = new Queue<int>();

    
    void Update()
    {
        for (int i = 0; i < Pattern_list.Count; i++)
        {
            Pattern_list[i].transform.localPosition = Vector3.Lerp(Pattern_list[i].transform.localPosition, new Vector3(-290+98*i,0,0),Time.deltaTime*3);
        }
    }
    public void Clear()
    {
    //  GameObject[] Dir = new GameObject[Pattern_list.Count];
        if (Pattern_list.Count > 0)
        {
            for (int i = 0; i < Pattern_list.Count; i++)
            {
                Destroy(Pattern_list[i],2);
            }
            Pattern_list.Clear();
            Pattern_list_num.Clear();
        }
        
    }
    public void CreateGesture(int num)
    {
        if (Pattern_list.Count < 12)
        {
            int rootin = 0;
            while (rootin != num)
            {
                DE:
                int rand = Random.Range(0, 13);
                if(rand == 8 || rand == 9 || rand == 11 || rand == 3)
                {
                    goto DE;
                }
                GameObject pattern = Instantiate(Gesture_pf[rand]);
                pattern.transform.SetParent(Pattern_parent.transform);
                pattern.transform.localScale = new Vector3(0.85f, 0.85f, 1);
                pattern.transform.localPosition = new Vector3(420 + rootin * 700, 0, 0);
                Pattern_list.Add(pattern);
                Pattern_list_num.Enqueue(rand);
                rootin++;
            }
        }
    }
}
