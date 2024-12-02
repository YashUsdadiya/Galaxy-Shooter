using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    
    public static Manager instance;
    public Text scoreText, levelText;
    public int score,level;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        level=PlayerPrefs.GetInt("level", 1);
    }

    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetInt("score",0);
        scoreText.text = score + "";
        //if (EnemyGenrator.instance.i == 5 * Level.instance.currentLevel) 
        //{
        //   Level.instance.LevelUp();

        //    levelText.text = "Level-" +level;
        //}

        
    }
}
