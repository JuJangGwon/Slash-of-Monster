using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHitbyANim : MonoBehaviour {

    public GameObject Shine;

    void SlimeAnim(GameObject shines)
    {
       
    }
    void hitby(int i)
    {
        GameObject shines = Instantiate(Shine);
        shines.transform.SetParent(gameObject.transform);
        shines.transform.localScale = new Vector3(1, 1, 1);
        if (i == 1)
        {
            switch (Singleton.getInstance.An)
            {
                case AttackAnim.left:
                    shines.transform.localPosition = new Vector3(-155, -132, 0);
                    break;
                case AttackAnim.right:
                    shines.transform.localPosition = new Vector3(160, -120, 0);
                    break;
                case AttackAnim.up:
                    shines.transform.localPosition = new Vector3(0, 0, 0);
                    break;
            }
        }
        else if (i == 2)
        {
            switch (Singleton.getInstance.An)
            {
                case AttackAnim.left:
                    shines.transform.localPosition = new Vector3(-155, -132, 0);
                    break;
                case AttackAnim.right:
                    shines.transform.localPosition = new Vector3(160, -120, 0);
                    break;
                case AttackAnim.up:
                    shines.transform.localPosition = new Vector3(0, 0, 0);
                    break;
            }
        }
        Singleton.getInstance.An = AttackAnim.none;
    }
}
