using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject bullet, bulletPrefab,healthPrefab;
    public GameObject Left,Right;
    public Sprite[] sprites;
    public Slider health;
    bool isRight, isLeft;
    int life=5;
    int control;
    float xPos;
    float yPos;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("genreteBullet", 1f, 0.2f);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[PlayerPrefs.GetInt("select",0)];

    }
    float speed = 0.1f;
    float planRotation = 0f;
    // Update is called once per frame
    void Update()
    {
        control = PlayerPrefs.GetInt("Controls",3);
        switch(control)
        {
            case 1:
                Left.SetActive(false);
                Right.SetActive(false);
                xPos = Mathf.Clamp(transform.position.x, -1.5f, 1.5f);//object screen ni bar move na thai
                 yPos = Mathf.Clamp(transform.position.y, -4, 3);
                if (Input.GetKey(KeyCode.LeftArrow))//left arrow key access karva mate
                {
                    transform.position = new Vector2(xPos - speed, transform.position.y);
                    if (transform.rotation.z < 0.2)
                    {
                        planRotation += Time.deltaTime * 5f;
                    }
                    transform.rotation = Quaternion.Euler(0, 0, planRotation);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position = new Vector2(xPos + speed, transform.position.y);
                    if (transform.rotation.z > -0.2)
                    {
                        // print(transform.rotation.z);
                        planRotation -= Time.deltaTime * 5f;
                    }
                    transform.rotation = Quaternion.Euler(0, 0, planRotation);
                }
                if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    planRotation = 0f;
                    transform.rotation = Quaternion.Euler(0, 0, planRotation);
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.position = new Vector2(transform.position.x, yPos + speed);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.position = new Vector2(transform.position.x, yPos - speed);
                }
                break;

            case 2:

                Left.SetActive(true);
                Right.SetActive(true);
                 xPos = Mathf.Clamp(transform.position.x, -1.5f, 1.5f);//object screen ni bar move na thai
                 yPos = Mathf.Clamp(transform.position.y, -4, 3);
                if (isLeft)//left arrow key access karva mate
                {
                    transform.position = new Vector2(xPos - speed, transform.position.y);
                    if (transform.rotation.z < 0.2)
                    {
                        planRotation += Time.deltaTime * 5f;
                    }
                    transform.rotation = Quaternion.Euler(0, 0, planRotation);
                }
                if ( isRight)
                {
                    transform.position = new Vector2(xPos + speed, transform.position.y);
                    if (transform.rotation.z > -0.2)
                    {
                        // print(transform.rotation.z);
                        planRotation -= Time.deltaTime * 5f;
                    }
                    transform.rotation = Quaternion.Euler(0, 0, planRotation);
                }
                
                
                break;

                case 3:
                touchMovePlan();
                break;

                case 4:
                accelartionMovePlan();
                break;

        }
        
    }
    public void rightDown()
    {
        isRight = true;
    }
    public void leftDown()
    {
        isLeft = true;
    }
    public void rightUp()
    {
        isRight = false;
        planRotation = 0f;
        transform.rotation = Quaternion.Euler(0, 0, planRotation);
    }
    public void leftUp()
    {
        isLeft = false;
        planRotation = 0f;
        transform.rotation = Quaternion.Euler(0, 0, planRotation);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            if (life == 0)
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                Destroy(collision.gameObject);
                life--;
                health.value = life;
            }
            
        }
        if (collision.gameObject.tag == "health")
        {
            Destroy(collision.gameObject);
            health.value += 4;
        }
    }
    

void genreteBullet()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity, bullet.transform);
        //print("hello");

    }
    void touchMovePlan()
    {
        Left.SetActive(false);
        Right.SetActive(false);
        xPos = Mathf.Clamp(transform.position.x, -1.5f, 1.5f);//object screen ni bar move na thai
        yPos = Mathf.Clamp(transform.position.y, -4, 3);
        if (Input.touchCount>0)
        {
            float screenHalf=Screen.width/2;
            Touch t=Input.GetTouch(0);
            Vector2 touchPos=t.position;
            if (touchPos.x > screenHalf)
            {
                transform.position = new Vector2(xPos + speed, transform.position.y);
                
               
            }
            else
            {
                transform.position = new Vector2(xPos - speed, transform.position.y);
             
            }

        }
        else
        {
            if (transform.rotation.z < 0.2)
            {
                planRotation += Time.deltaTime * 5f;
            }
            transform.rotation = Quaternion.Euler(0, 0, planRotation);

            if (transform.rotation.z > -0.2)
            {
                // print(transform.rotation.z);
                planRotation -= Time.deltaTime * 5f;
            }
            transform.rotation = Quaternion.Euler(0, 0, planRotation);
        }
    }

    void accelartionMovePlan()
    {
        Left.SetActive(false);
        Right.SetActive(false);
        xPos = Mathf.Clamp(transform.position.x, -1.5f, 1.5f);//object screen ni bar move na thai
        yPos = Mathf.Clamp(transform.position.y, -4, 3);
        if (Input.acceleration.x <- 0.1f) 
        {
            transform.position = new Vector2(xPos - 0.05f, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(xPos + 0.05f, transform.position.y);
           
        }
    }

}
