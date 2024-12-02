using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGenrator : MonoBehaviour
{
    public GameObject[] planPrefab;
    //public GameObject[] monsterPrefab;

    float genrate = 3f;
   public int cnt, i ;
    public static EnemyGenrator instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //int n = PlayerPrefs.GetInt("level");
        //cnt= n;
        //if(cnt==n)
        //{
        //    cnt += 2;
        //}
        InvokeRepeating("generatePlan", 2f, genrate);
      
    }

    // Update is called once per frame
    void Update()
    {
       
       
        
    }
    float randomX;
    void generatePlan()
    {
        
            randomX = Random.Range(-1.55f, 1.55f);
            int random = Random.Range(0, 3);
            Instantiate(planPrefab[random], new Vector2(randomX, transform.position.y), Quaternion.identity);
            i++;
            print(i);
        


    }
    //void GenrateMonster()
    //{
    //    randomX = Random.Range(-1.55f, 1.55f);
    //    int genrate = Random.Range(0, 3);

    //    Instantiate(monsterPrefab[genrate], new Vector2(randomX, transform.position.y), Quaternion.identity);
    //    i++;

    //}

}
