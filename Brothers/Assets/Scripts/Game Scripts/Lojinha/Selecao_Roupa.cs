using System.Collections.Generic;
using UnityEngine;

public class Selecao_Roupa : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer chapeu_utilizado;
    public List<Sprite> chapeus = new List<Sprite>();
    //O indicador do chapeu atual
    private int index;

    public static Selecao_Roupa instance;

    void Awake()
    {
        instance = this;
    }

    //função para adicionar chapeus a lista
    public void Adicionar_Roupa(Sprite sp)
    {
        chapeus.Add(sp);        
    }

    //funções para alterar os chapeus
    public void Prox_Chapel()
    {
        index ++;
        if (index > chapeus.Count -1)
        {
            index = 0;  
        }
        chapeu_utilizado.sprite = chapeus[index];
    }
    public void Ant_Chapel()
    {
            index --;
        if (index < 0)
        {
            index = chapeus.Count -1;  
        }
        chapeu_utilizado.sprite = chapeus[index]; 
    }

}
