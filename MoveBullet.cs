using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEngine.UIElements;

public class MoveBullet : MonoBehaviour
{
    float speed = 0.1f;
    int cnt,i,max;
    public static MoveBullet instance;
   
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed);
    }
    
}
