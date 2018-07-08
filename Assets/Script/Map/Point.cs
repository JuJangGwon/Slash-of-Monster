using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {

    float _time = 0;

    bool left = true;
    float y;
    float x;
	void Start () {
        y = transform.localPosition.y;
        x = transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.smoothDeltaTime;
        if (left == true)
        {
            if (_time > 0.01f)
            {
                transform.localPosition = new Vector2(transform.localPosition.x - 1, transform.localPosition.y + 0.3f);
                if (transform.localPosition.x + 20 < x) left = false;
            }
        }
        if (left == false)
        {
            if (_time > 0.01f)
            {
                transform.localPosition = new Vector2(transform.localPosition.x + 1, transform.localPosition.y + 0.3f);
                if (transform.localPosition.x > x + 20) left = true;
            }
        }
    }
}
