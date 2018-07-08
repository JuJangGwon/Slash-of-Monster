using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftrightbuttons : MonoBehaviour {


    public GameObject Rune;

    Rune rune;

    void Awake()
    {
        rune = Rune.GetComponent<Rune>();
    }

	public void sksk(int i)
    {
        switch(i)
        {
            case 1:

                Debug.Log("dd");
                if (rune.page > 1)
                {
                    rune.page--;
                    rune.ShowRunePage();
                }
                break;
            case 2:
                Debug.Log("bdd");

                rune.page++;
                rune.ShowRunePage();
                break;
        }
    }
}
