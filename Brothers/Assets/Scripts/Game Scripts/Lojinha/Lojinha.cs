using System;
using System.Collections.Generic;
using UnityEngine;

public class Lojinha : MonoBehaviour
{
    public int moedas;

    //Serve para atualizar os itens da loja
    public Item_button[] roupas;

    public static Lojinha Instance;

    void Awake()
    {
        Instance = this;
    }
    
    //subitrai as moedas
    public void Comprar(int custo)
    {
       moedas -= custo; 
    }

    //Compra as moedas
    public void adicionar(int adicionar)
    {
        moedas += adicionar;        
    }

}