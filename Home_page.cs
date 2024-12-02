using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home_page : MonoBehaviour
{
    public AudioSource BgAudio,BtnAudio;
    public AudioClip BtnClip, BgClip;
    public GameObject OnBtn, OffBtn;
    int sound;    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this);
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
  
    public void OnPlayBtnClick()
    {
        BtnAudio.clip=BtnClip;
        BtnAudio.Play();
        StartCoroutine(playSceneDelay());
       
        Time.timeScale = 1f;
    }
    public void OnPlayerBtnClick()
    {
        BtnAudio.clip = BtnClip;
        BtnAudio.Play();
        StartCoroutine(selectSceneDelay());

    }
    IEnumerator playSceneDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Play");
    }
    IEnumerator selectSceneDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("PlayerSelect");
    }
    public void clickSound()
    {
        sound = PlayerPrefs.GetInt("Sound", 1);
        if (sound == 1)
        {
            BgAudio.mute = true;
            BtnAudio.mute = true;
            OnBtn.SetActive(false);
            OffBtn.SetActive(true);
            PlayerPrefs.SetInt("Sound", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
            BgAudio.mute = false;
            BtnAudio.mute = false;
            OnBtn.SetActive(true);
            OffBtn.SetActive(false);
        }

    }
}
