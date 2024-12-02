using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    int sound;
    public AudioSource BgAudio, BtnAudio;
    public AudioClip BtnClip, BgClip;
    public GameObject OnBtn, OffBtn;
    // Start is called before the first frame update
    void Start()
    {
        sound = PlayerPrefs.GetInt("Sound", 1);
        if (sound == 0)
        {
            BgAudio.mute = true;
            BtnAudio.mute = true;
            OnBtn.SetActive(false);
            OffBtn.SetActive(true);
        }
        else
        {
            BgAudio.mute = false;
            BtnAudio.mute = false;
            OnBtn.SetActive(true);
            OffBtn.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnYesBtnClick()
    {
        BtnAudio.clip = BtnClip;
        BtnAudio.Play();
        StartCoroutine(YesSceneDelay());
    }
    IEnumerator YesSceneDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Play");
    }
    public void OnNoBtnClick()
    {
        BtnAudio.clip = BtnClip;
        BtnAudio.Play();
        StartCoroutine(NoSceneDelay());
    }
    IEnumerator NoSceneDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Home");
    }
    public void clickSound()
    {
        sound = PlayerPrefs.GetInt("Sound", 1);
        if (sound == 1)
        {
            OnBtn.SetActive(false);
            OffBtn.SetActive(true);
            BgAudio.mute = true;
            BtnAudio.mute = true;
            PlayerPrefs.SetInt("Sound", 0);
        }
        else
        {
            OnBtn.SetActive(true);
            OffBtn.SetActive(false);
            PlayerPrefs.SetInt("Sound", 1);
            BgAudio.mute = false;
            BtnAudio.mute = false;
        }

    }
}
