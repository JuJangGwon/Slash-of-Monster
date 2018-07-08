using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFiquarShell : MonoBehaviour {

    void Start()
    {
        StartCoroutine(FiquarCycle());
        Destroy(gameObject,2.1f);
    }
    IEnumerator FiquarCycle()
    {
        for(int i = 0; i< 35; i++)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y+3, transform.localPosition.z);
            yield return new WaitForSeconds(0.05f);
        }
       
    }
}
