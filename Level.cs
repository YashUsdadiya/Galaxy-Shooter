using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int currentLevel;
    public static Level instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelUp()
    {
        currentLevel++;
    }
}
