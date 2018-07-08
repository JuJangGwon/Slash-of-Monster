using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData : MonoBehaviour {

 
    public List<Attribute> monster_list = new List<Attribute>();

    [System.Serializable]
    public class Attribute
    {
        public int level;
        public int maxHP;
        public int defence;
        public int gainExp;
        public int gainGold;
    }

}
