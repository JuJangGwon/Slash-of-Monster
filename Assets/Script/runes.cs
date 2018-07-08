using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class runes : MonoBehaviour {

    float _time = 0;
    float __time = 0;
    Image img;
    
    void Awake()
    {
        img = GetComponent<Image>();
    }
	void Update () {
        transform.localPosition = Vector3.Lerp(transform.localPosition,new Vector3(0,80,0),Time.smoothDeltaTime);
        _time += Time.smoothDeltaTime;
        if(_time >2)
        {
            __time += Time.smoothDeltaTime;
            if (__time > 0.01f)
            {
                __time = 0;
                img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a-0.01f);
            }
            Destroy(gameObject, 1);
        }
	}
}
