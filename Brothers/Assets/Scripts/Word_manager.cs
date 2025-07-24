using UnityEngine;
using UnityEngine.UI;

public class Word_manager : MonoBehaviour
{
    public bool[] Sequencia;
    [SerializeField]
    public RectTransform Vitoria_Panel;
    //A foto a ser mostrada na imagem
    public Sprite[] Fotos;

    private GameObject ReturnButton;

    [SerializeField]
    private AudioClip Yay;

      private AudioControl AC;
    //Vai mostrar a foto do objeto da palavra
    public Image Imagem_Exemplo;

    //Vai receber o numero do playerPrefs
    private int num;
    
    void Start()
    {
        num = PlayerPrefs.GetInt("QTD_Letras");

        AC = Object.FindFirstObjectByType<AudioControl>();
        ReturnButton = Object.FindFirstObjectByType<Return_Script>().gameObject;
        Sequencia = new bool[num];

        for(int i =0; i< Sequencia.Length; i++)
        {
            Sequencia[i] = false;
        }
    }

    //Percorre pelo vetor de bool e deixa o primeiro em TRUE
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

    //Percorre pelo vetor de bool e deixa o primeiro em FALSE caso a letra seja retirada do quadrado
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

    private bool Checagem() 
    {
        for (int i = 0; i < Sequencia.Length; i++)
        {
            if (Sequencia[i]==false)
                return false;
        }
        return true;
    }

    public void Verificacao()
    {
        bool Correto = Checagem();
        if (Correto)
        {
            Vitoria_Panel.LeanMoveY(50f, 0.5f);
            ReturnButton.SetActive(false);
            AC.Tocar_SFX(Yay);
        }
        else 
        {
            Debug.Log("A criança errou");
        } 
    }
}
