using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControleGeral : MonoBehaviour
{
    public int total;
    public TextMeshProUGUI pontuacao; 
    public static ControleGeral instance;
    void Start()
    {
        instance = this;
    }
    public void AttPontos()
    {
        pontuacao.text = total.ToString();
    }
}
 