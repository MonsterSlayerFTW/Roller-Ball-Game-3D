using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public float FadeIn = 0.02f;
    public float FadeOut = 2;
    public AudioSource AS;
    public AudioClip Moving, Landing, Dying;

    public void Update()
    {
        PlayingMusic();
    }
    public void PlayingMusic()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            AS.clip = Moving;
            AS.loop = true;
            AS.Play();
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            AS.Stop();
            AS.loop=false;
        }
    }
}
