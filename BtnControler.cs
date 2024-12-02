using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnControler : MonoBehaviour
{
    public GameObject control;
    public AudioSource BtnAudio;
    public AudioClip BtnClip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnBtnClickKey(int n)
    {
        BtnAudio.clip = BtnClip;
        BtnAudio.Play();
        PlayerPrefs.SetInt("Controls", n);
        control.SetActive(false);
        Time.timeScale = 1f;

    }
}
