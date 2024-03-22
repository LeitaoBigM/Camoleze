using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mola : MonoBehaviour
{
    public float impulso;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Player"))
        {
            colisao.gameObject.GetComponent<Rigidbody2D>()
                .AddForce(Vector2.up * impulso, ForceMode2D.Impulse);
            anim.Play("Anima_mola");
        }
    }
}