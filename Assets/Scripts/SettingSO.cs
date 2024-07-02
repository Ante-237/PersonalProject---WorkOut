using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SettingSO")]
public class SettingSO : ScriptableObject 
{
    public List<GameObject> boxEffects;
    public List<AudioClip> boxSounds;
    public GameObject RightBox;
    public GameObject LeftBox;

    public bool RightHand = false;
    public bool LeftHand = false;
    public bool StartGame = false;
    public int FailCount = 0;

    public int Boxes = 0;
    public int Score = 0;
    public float BoxSpeed = 0.5f;
    public int ScoreFactor = 30;


    public void PlayBoxSound(AudioSource audio)
    {
        audio.PlayOneShot(boxSounds[UnityEngine.Random.Range(0, boxSounds.Count)]);
    }
}
