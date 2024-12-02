using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPlan : MonoBehaviour
{
    public GameObject bulletPrefab;
    public static EnemyPlan instance;
    public int health=20;
    public int i;
    int cnt;
   
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        InvokeRepeating("genreteBullet", 1f, 1f);
        

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<0.11f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.05f);
        }
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.05f);
        if (health == 0)
        {
            cnt = PlayerPrefs.GetInt("score", 0);
            cnt += 10;
            PlayerPrefs.SetInt("score", cnt);
            Destroy(this.gameObject);
            i = PlayerPrefs.GetInt("lev", 0);
            i++;
            PlayerPrefs.SetInt("lev", i);
            print("i=" + i);
            if (i == 10)
            {
                i = 0;
                //cnt = 0;
                PlayerPrefs.SetInt("lev", i);
                print("i=0" + i);
                //i= PlayerPrefs.GetInt("lev", 0); 
                SceneManager.LoadScene("Win");
                
            }
        }
    }

    void genreteBullet()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform);
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
           // EnemyPlan demo = collision.gameObject.GetComponent<EnemyPlan>();
            health -= 10;
            Destroy(collision.gameObject);

        }
    }

}
