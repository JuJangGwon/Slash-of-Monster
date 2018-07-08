using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    //public GameObject 

    public void change(int a)
    {
        switch(a)
        {
            case 1:
                Singleton.getInstance.mode = 0;
                break;
            case 2:
                Singleton.getInstance.mode = 4;
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }

}
