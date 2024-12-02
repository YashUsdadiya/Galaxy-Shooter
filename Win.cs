using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Text level;
    int levelNum;
    int sound;
    public AudioSource BgAudio, BtnAudio;
    public AudioClip BtnClip, BgClip;
    public GameObject OnBtn, OffBtn;
    // Start is called before the first frame update
    void Start()
    {
        levelNum=PlayerPrefs.GetInt("Level", 1);
        level.text = "Level-"+levelNum.ToString();
        PlayerPrefs.SetInt("score", 0);

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
    public void OnClick()
    {
        levelNum++;
        PlayerPrefs.SetInt("Level",levelNum);
        level.text ="Level-"+ levelNum.ToString();
        BtnAudio.clip = BtnClip;
        BtnAudio.Play();
        StartCoroutine(playSceneDelay());
    }
    public void OnClickPlayer()
    {
        BtnAudio.clip = BtnClip;
        BtnAudio.Play();
        StartCoroutine(selectSceneDelay());
    }
    public void OnClickMenu()
    {
        BtnAudio.clip = BtnClip;
        BtnAudio.Play();
        StartCoroutine(menuSceneDelay());
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
    IEnumerator menuSceneDelay()
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

