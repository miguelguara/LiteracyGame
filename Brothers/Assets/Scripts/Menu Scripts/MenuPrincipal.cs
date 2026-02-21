using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public Image Logo;
    //Fica responsável por mover a camera
    [SerializeField] private Transform Cam;
    [SerializeField] private RectTransform Pannel_Levels, Pannel_Numeros,TemaPrincipal,Lojinha,maos;
    //Verifica na memoria se o jogo ja foi aberto
    private int aberto;

    private bool Lojinha_Aberta;

    public void Awake()
    {
        //faz a logo mudar de escala parecendo uma animacao
        Logo.gameObject.LeanScale(new Vector3(1f, 1f), 0.45f).setLoopPingPong();
        aberto = PlayerPrefs.GetInt("Jogo-Aberto");
        //Verifica qual jogo o player abriu por ultimo
        switch (aberto)
        {
            case 1:
            PannelIN();
            break;
            case 2:
            PannelIN_Numeros();
            break;
        }
    }

    void Start()
    {
        Lojinha_Aberta = false;
    }

    public void Chamar_Loja()
    {
        Lojinha_Aberta = !Lojinha_Aberta;

        if (Lojinha_Aberta)
        {
            Abrir_Loja();
        }
        else
        {
            Fechar_Loja();
        }
        
    }

    public void PannelIN()
    {
        Pannel_Levels.LeanMoveX(30f, 1f);
        aberto = 1;
        PlayerPrefs.SetInt("Jogo-Aberto", aberto);
    }

    public void PannelOUT() 
    {
        Pannel_Levels.LeanMoveX(820f, 0.7f);
    }

    private void OnApplicationQuit()
    {
        aberto = 0;
        PlayerPrefs.SetInt("Jogo-Aberto", aberto);
    }

    public void PannelIN_Numeros()
    {
        Pannel_Numeros.LeanMoveX(30f, 1f);
        aberto = 2;
        PlayerPrefs.SetInt("Jogo-Aberto", aberto);
    }
    
     public void PannelOut_Numeros(){
        Pannel_Numeros.LeanMoveX(820f, 1f);    
    }

    public void Abrir_Loja()
    {
        TemaPrincipal.LeanMoveY(376f, 1.2f).setEaseInElastic();
        Lojinha.LeanMoveX(671f,1.2f).setEaseInElastic();
        Cam.LeanMoveX(-2.43f,1f);
        maos.LeanMoveY(-59f,1f).setEaseInElastic();
    }

    public void Fechar_Loja()
    {
       TemaPrincipal.LeanMoveLocalY(0f, 1.2f).setEaseInElastic();
       Lojinha.LeanMoveX(930f,1.2f).setEaseInElastic();
       Cam.LeanMoveX(0.1f,1f);
       maos.LeanMoveY(-270f,1f).setEaseInElastic();
    }
}