using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class settingd : MonoBehaviour
{
    public GameObject setting,controls;
    public GameObject OnBtn, OffBtn;
    public AudioSource BgAudio, BtnAudio;
    public AudioClip BtnClip, BgClip;
    int sound;
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
    public void onBtnClick()
    {
        BtnAudio.clip = BtnClip;
        BtnAudio.Play();
        setting.SetActive(true);
        Time.timeScale = 0f;
    }
    public void CloseSetting()
    {
        BtnAudio.clip = BtnClip;
        BtnAudio.Play();
        setting.SetActive(false);
        Time.timeScale = 1f;
    }
    public void HomeBtn()
    {
        BtnAudio.clip = BtnClip;
        BtnAudio.Play();
        Time.timeScale = 1f;
        StartCoroutine(homeSceneDelay());
    }
    public void SelectBtn()
    {
        BtnAudio.clip = BtnClip;
        BtnAudio.Play();
        Time.timeScale = 1f;
        StartCoroutine(selectSceneDelay());
    }
    IEnumerator selectSceneDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("PlayerSelect");
    }
    IEnumerator homeSceneDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Home");
    }
    public void SelectControlBtn()
    {
        BtnAudio.clip = BtnClip;
        BtnAudio.Play();
        setting.SetActive(false);
        controls.SetActive(true);
    }
    public void CloseControls()
    {
        BtnAudio.clip = BtnClip;
        BtnAudio.Play();
        controls.SetActive(false);
        //Time.timeScale = 1f;
    }
    public void clickSound()
    {
       sound= PlayerPrefs.GetInt("Sound", 1);
        if(sound==1)
        {
            OnBtn.SetActive(false);
            OffBtn.SetActive(true);
           BgAudio.mute = true;
            BtnAudio.mute = true;
            PlayerPrefs.SetInt("Sound", 0);
        }else
        {
            OnBtn.SetActive(true);
            OffBtn.SetActive(false);
            PlayerPrefs.SetInt("Sound", 1);
            BgAudio.mute = false;
            BtnAudio.mute = false;
        }
        
    }
}
