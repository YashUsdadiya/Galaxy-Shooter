using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    public Sprite[] playerShip;  
    public Sprite selectedSprite;
    int sound;
    public AudioSource BgAudio, BtnAudio;
    public AudioClip BtnClip, BgClip;
    public GameObject OnBtn, OffBtn;

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

    public void OnPlayBtnClick()
    {
        BtnAudio.clip = BtnClip;
        BtnAudio.Play();
        StartCoroutine(playSceneDelay());

        Time.timeScale = 1f;
    }
    IEnumerator playSceneDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Play");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onBtnClick(int no)
    {
        BtnAudio.clip = BtnClip;
        BtnAudio.Play();
        PlayerPrefs.SetInt("select", no);
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
