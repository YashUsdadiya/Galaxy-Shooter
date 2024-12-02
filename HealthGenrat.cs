using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartGanrate : MonoBehaviour
{

    public GameObject  helathPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenaretHelath", 2f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenaretHelath()
    {
        float randomX = Random.Range(-1.55f, 1.55f);
        if (randomX < 0)
        {
            float randomHelath = Random.Range(-1.55f, 1.55f);
            Instantiate(helathPrefab, new Vector2(randomHelath, transform.position.y), Quaternion.identity);
        }

    }
}
