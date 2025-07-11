using UnityEngine;

public class Word_manager : MonoBehaviour
{
    public bool[] Sequencia;
    //Vai receber o numero do playerPrefs
    private int num;
    
    void Start()
    {
        num = PlayerPrefs.GetInt("QTD_Letras");

        Sequencia = new bool[num];

        for(int i =0; i< Sequencia.Length; i++)
        {
            Sequencia[i] = false;
        }
    }

    public void Acerto() 
    {
        for (int i = 0; i < Sequencia.Length; i++) 
        {
            if (Sequencia[i] == false) 
            {
                Sequencia[i] = true;
                break;
            }
        }
    }

    public void Erro() 
    {
        for(int i = 0;i< Sequencia.Length; i++) 
        {
            if (Sequencia[i] == true)
            {
                Sequencia[i] = false;
                break;
            }
        }
    }

    private bool Verificar() 
    {
        for (int i = 0; i < Sequencia.Length; i++)
        {
            if (Sequencia[i]==false)
                return false;
        }
        return true;
    } 
    
}
