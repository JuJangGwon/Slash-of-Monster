using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScript : MonoBehaviour {

    int stack = 0;
    public bool go = false; 

    public GameObject mulum;
    public GameObject nkim;
    
    public GameObject _1pf;
    public GameObject _2pf;
    public GameObject _3pf;


    public GameObject Questpop;
    public void Start()
    {
        mulum.SetActive(false);
        nkim.SetActive(false);

        if (Singleton.getInstance.quest == Quest.none)
        {
            nkim.SetActive(true);
        }
        else if (Singleton.getInstance.quest == Quest.finish)
        {
            mulum.SetActive(true);
        }
    }

	void Update () {
		if(go == true)
        {
            if(stack == 0)
            {
                _1pf.SetActive(true);
                _2pf.SetActive(false);
                _3pf.SetActive(false);
                if(Input.GetMouseButtonDown(0))
                {
                    stack = 1;
                }
            }
            else if(stack == 1)
            {
                _1pf.SetActive(false);
                _2pf.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    stack = 2;
                }
            }
            else if (stack == 2)
            {
                _2pf.SetActive(false);
                _3pf.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    go = false;
                    stack = 3;
                    _3pf.SetActive(false);
                    Questpop.SetActive(true);
                }
            }
        }
	}
}
