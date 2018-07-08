using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour {

    public GameObject tutorial;
    Tutorial tutorial_cs;


    void Awake()
    {
        tutorial_cs = tutorial.GetComponent<Tutorial>();
    }

    public void Buttons(int i)
    {
        tutorial_cs.akak(i);
    }
}
