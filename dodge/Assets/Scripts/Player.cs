using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int hp = 3;

    public int GetHP()
    {
        return hp;
    }

    public void SetHP(int hp)
    {
        this.hp = hp;
    }


    void Start()
    {

    }

    void Update()
    {
        if (hp > 0) 
        {
            float posX=0.0f;
            float posY=0.0f;
            posX = Input.GetAxisRaw("Horizontal");
            posY = Input.GetAxisRaw("Vertical");
            Vector3 pos = gameObject.transform.position;
            pos.x += posX * Time.deltaTime * 10;
            pos.y += posY * Time.deltaTime * 10;

            if (pos.x < -8.3f)
            {
                pos.x = -8.3f;
            }
            else if (pos.x > 8.3f)
            {
                pos.x = 8.3f;
            }

            if (pos.y < -4.7f) 
            {
                pos.y = -4.7f;
            }
            else if (pos.y > 4.7f)
            { 
                pos.y = 4.7f;
            }

            gameObject.transform.position = pos;
           }

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Enemy")
        {
            hp -= 1;
            Debug.Log(hp);
        }
    }
}
