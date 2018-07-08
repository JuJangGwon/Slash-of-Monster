using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skipbutton : MonoBehaviour {

    public GameObject Canvas;
    public GameObject blackImage;

    IntroManager it;

    void Awake()
    {
        it = Canvas.GetComponent<IntroManager>();
    }
    public void SKipB()
    {
        blackImage.SetActive(true);
        Invoke("akak", 3);
    }
    void akak()
    {
        it.state = 27;
        it.Start();
    }
}
