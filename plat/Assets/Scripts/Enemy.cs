using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    bool isDie;
    float dieTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie)
        {
            if (dieTimer == 0f)
            {
                SoundManager.instance.HitSound();
            }
            dieTimer += Time.deltaTime;
            if (dieTimer >= 1.4f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Die()
    {
        anim.SetBool("isDie", true);
        isDie = true;
    }
}
