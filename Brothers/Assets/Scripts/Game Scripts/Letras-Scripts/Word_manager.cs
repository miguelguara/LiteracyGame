using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Word_manager : MonoBehaviour
{
    public static Word_manager instance;
    public bool Correto;
    //A sequencia de booleanas que será preenchida com cada letra inserida
    public bool[] Sequencia;

    private string Palavra;

    [SerializeField]
    private GameObject Verificar_Button;
    [SerializeField]
    private RectTransform Vitoria_Panel;
    //A foto a ser mostrada na imagem
    public Sprite[] Fotos;
    //public AudioClip [] Palavras;

    private GameObject ReturnButton;

    [SerializeField]
    private AudioClip Yay, Tente_Denovo;

    private AudioControl AC;
    //Vai mostrar a foto do objeto da palavra
    public Image Imagem_Exemplo;

    private int indexImage;

    [HideInInspector]
    public List<Check_Letras> Letras_Erradas = new List<Check_Letras>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {

        Palavra = PlayerPrefs.GetString("Word");
        indexImage = PlayerPrefs.GetInt("IDX_Imagem");

        AC = Object.FindFirstObjectByType<AudioControl>();
        ReturnButton = Object.FindFirstObjectByType<Return_Script>().gameObject;
        Vitoria_Panel = GameObject.Find("Parabens").GetComponent<RectTransform>();

       

        Sequencia = new bool[Palavra.Length];
        Imagem_Exemplo.sprite = Fotos[indexImage];

        for (int i = 0; i < Sequencia.Length; i++)
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
        for (int i = 0; i < Sequencia.Length; i++)
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
            if (Sequencia[i] == false)
                return false;
        }
        return true;
    }

    public void Verificacao()
    {
         Correto = Checagem();
        if (Correto)
        {
            Vitoria_Panel.LeanMoveY(50f, 0.5f);
            Parabens.instance.PreencherStar();
            ReturnButton.SetActive(false);
            Verificar_Button.SetActive(false);
            AC.Tocar_SFX(Yay);
        }
        else
        {
            AC.Tocar_SFX(Tente_Denovo);
            for (int i = 0; i < Letras_Erradas.Count; i++)
            {
                Letras_Erradas[i].expulsar_Letra();
            }
        }
    }
    

    public void Adicionar_CheckBox(Check_Letras obj)
    {
        Letras_Erradas.Add(obj);
    }
    /*IEnumerator Correto()
    {   
        Vitoria_Panel.LeanMoveY(50f, 0.5f);
        ReturnButton.SetActive(false);
        AC.Tocar_SFX(Yay);
    }*/
}
