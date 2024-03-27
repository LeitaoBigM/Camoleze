using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Moranguinho : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D box;
    public GameObject coletado;
    public int Pontos;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.gameObject.tag == "Player")
        {
            sr.enabled = false;
            box.enabled = false;
            coletado.SetActive(true);
            ControleGeral.instance.total += Pontos;
            ControleGeral.instance.AttPontos();
            Destroy(gameObject, 0.25f);
        }
    }
}