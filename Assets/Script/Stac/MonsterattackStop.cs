using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterattackStop : MonoBehaviour {

    bool monster_attack = false;

    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void AttackStop()
    {
        if(monster_attack == false)
        {
            anim.speed = 0;
            monster_attack = true;
            Invoke("AttackStop", 2.5f);
        }
        else if(monster_attack == true)
        {
            anim.speed = 1;
            monster_attack = false;
        }   
    }
}
