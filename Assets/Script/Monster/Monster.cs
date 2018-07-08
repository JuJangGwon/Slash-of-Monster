using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public GameObject Monster_parents;
    public Material fontmatarial;
    public Material normalMatarial;
    Image mat;

    void Awake()
    {
        mat = GetComponent<Image>();
    }
    public void hitby_changecolor(int i)
    {
        Debug.Log("f");
        if (i == 1) mat.material = fontmatarial;
        else if (i == 2) mat.material = normalMatarial;
    }
}
