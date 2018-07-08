using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour {

    public int Hp = 0;
    public int gainExp = 0;
    public int gainGold = 0;

    public Property monster_property;

    public Animator animator;
    public virtual void Awake()
    {
        animator = GetComponent<Animator>();
        monster_property = Property.none;
    }
    public virtual void die()
    {
        //animator.SetBool("die", true);
    }
}
