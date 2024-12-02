using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour
{
    Renderer space;
    public float yOffset = 0f;
    // Start is called before the first frame update
    void Start()
    {
        space = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        yOffset = Time.time * 0.8f;
        space.material.SetTextureOffset("_MainTex", new Vector2(0, yOffset));    }
    
}
