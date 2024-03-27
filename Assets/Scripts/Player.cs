using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
public class Player : MonoBehaviour
{
    Rigidbody2D rig;
    Animator anim;
    public float Speed;
    bool chao, puloDuplo;
    public int jump = 10;
    public int vida;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();   
    }
    void Update()
    {
        Move();
        Pulo();
        Morte();
        if (rig.velocity.y < 0f)
        {
            anim.Play("Anima_fall");
            anim.SetBool("fall", true);
        }
        else
        {
            anim.SetBool("fall", false);
        }
    }
    void Move()
    {
        rig.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, rig.velocity.y);

        if(Input.GetAxis("Horizontal") > 0f) 
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector2(0f, 180f);
        }
        if (Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("walk", false);
        }

    }
    void Morte()
    {
        if(vida == 0)
        {
            anim.Play("Anima_morte");
            Destroy(this.gameObject, 0.3f);
        }
    }
    void Pulo()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (chao)
            {
                rig.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                chao = false;
                puloDuplo = true;
                anim.SetBool("jump", true);
            }else if(puloDuplo)
            {
                rig.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                chao = false;
                puloDuplo = false;
                anim.SetBool("dj", true);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D colisao)
    {
        if(colisao.gameObject.CompareTag("Chão"))
        {
            chao = true;
            puloDuplo = false;
            anim.SetBool("jump", false);
            anim.SetBool("dj", false);
        }
        if (colisao.gameObject.CompareTag("Espinho"))
        {
            vida = vida - 1;
            anim.Play("Anima_hit");
        }
    }
}