using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lojinha : MonoBehaviour
{
    public int moedas;
    [SerializeField] private TextMeshProUGUI Moedas_txt;

    //Serve para atualizar os itens da loja
    public Item_button[] roupas;

    public static Lojinha Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //Pega da memoria a quantidade de moedas que o player possui
       // moedas = PlayerPrefs.GetInt("Moedas");
        Moedas_txt.text = moedas.ToString();
    }

    //subitrai as moedas
    public void Comprar(int custo)
    {
       moedas -= custo; 
       Moedas_txt.text = moedas.ToString();
       PlayerPrefs.SetInt("Moedas", moedas);
    }

    //Compra as moedas
    /*public void adicionar(int adicionar)
    {
        moedas += adicionar;   
        Moedas_txt.text = moedas.ToString();     
    }*/

}