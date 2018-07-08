using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour {

    public GameObject Canvas;
    public GameObject shell;
    public GameObject DamageFiqureParent;
    int num = 0;
    int i = 0;
    int s = 0;
    public GameObject[] fiqure_prf = new GameObject[10];

	//void Update () {
 //       if(Input.GetKeyDown(KeyCode.Z))
 //       {
 //           DamageChecker(7575);
 //       }
	//	if(Singleton.getInstance.dmg != 0)
 //       {
            
 //       }
	//}
    public void DamageChecker(int dmg)
    {
        i = dmg;
        s = i;
        while (i > 9)
        {
            i /= 10;
            num++;
        }
        int[] sksk = new int[num + 1];
        for (int ia = num; ia >= 0; ia--)
        {
            sksk[num - ia] = s / (int)Mathf.Pow(10, (ia)) % 10;
        }
        CreateReosource(num, sksk);
        num = 0;
    }
    void CreateReosource(int nums, int[] sk)
    {
        Vector3 Pos = new Vector3(0, 330, -1.5f);
        GameObject shells = Instantiate(shell);
        shells.transform.SetParent(DamageFiqureParent.transform);
        shells.transform.localScale = Vector3.one;
        shells.transform.localPosition = Pos;
        
        for(int i = 0; i <= nums; i++)
        {
            GameObject ak = Instantiate(fiqure_prf[sk[i]], transform.position, transform.rotation);
            ak.transform.SetParent(shells.transform);
            ak.transform.localPosition = new Vector3(0 + 40 * i, 0, 0);
            ak.transform.localScale = new Vector3(2,2,2);
        }
    }
}