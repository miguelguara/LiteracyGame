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
        if(!PlayerPrefs.HasKey("Moedas"))
        {
            PlayerPrefs.SetInt("Moedas", 0);
        }
    }

    void Start()
    {
        moedas = PlayerPrefs.GetInt("Moedas");
        Moedas_txt.text = moedas.ToString();
    }

    //subitrai as moedas
    public void Comprar(int custo)
    {
       moedas -= custo; 
       Moedas_txt.text = moedas.ToString();
       PlayerPrefs.SetInt("Moedas", moedas);
    }

}