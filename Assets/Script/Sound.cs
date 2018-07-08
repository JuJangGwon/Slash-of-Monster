using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    AudioSource As;
    public AudioClip[] attack_sound = new AudioClip[4];
    public AudioClip[] Fireattack_sound = new AudioClip[4];
 
    void Awake()
    {
        As = GetComponent<AudioSource>();
    }

    public void PlayAttackSound(int i)
    {
        if(Singleton.getInstance.attackbuffup == false)   As.clip = attack_sound[i];
        else if (Singleton.getInstance.attackbuffup == true) As.clip = Fireattack_sound[i];
        As.Play();
    }
}
