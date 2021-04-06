using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private float jumpPower = 6.2f;

    public Transform groundChecker;
    public float groundRadius = 1.8f;
    public LayerMask groundLayer;

    private Rigidbody2D rig;
    bool isGround = true;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetBool("isAttack", true);
            SoundManager.instance.AttackSound();

            Collider2D col = Physics2D.OverlapCircle(transform.position, 1.5f, (1 << LayerMask.NameToLayer("Enemy")));
            if (col != null)
            {
                //Debug.Log(col.gameObject.name);
                col.GetComponent<Enemy>().Die();
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.SetBool("isAttack", false);
        }
        isGround = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundLayer);
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }


    void Jump()
    {
        if((Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.Space))&&isGround){
            rig.AddForce(Vector2.up*jumpPower, ForceMode2D.Impulse);
            isGround=false;
        }
    }

    void Move()
    {
        float posX = Input.GetAxisRaw("Horizontal");
        if (posX != 0)
        {
            if (posX >= 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        transform.Translate(Mathf.Abs(posX) * Vector3.right * moveSpeed * Time.deltaTime);
    }
}
