using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    int i = 0;
    float time = 0;
    public GameObject Characters;
    Animator Anim;
	void Start () {
      //  Anim = Characters.GetComponent<Animator>();
    }
	
	void Update () {
		if(Singleton.getInstance.Character_def == true)
        {
            if (i == 0)
            {
                Anim.SetBool("def", true);
                i++;
            }
            else if(i == 1)
            {
                time += Time.smoothDeltaTime;
                if(time > 1.5f)
                {
                    time = 0;
                    i = 0;
                    Anim.SetBool("def", false);
                    Singleton.getInstance.Character_def = false;
                }
            }

        }
	}
}
