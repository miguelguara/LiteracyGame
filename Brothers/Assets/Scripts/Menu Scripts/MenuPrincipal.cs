using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public Image Logo;
    [SerializeField]
    private RectTransform Pannel_Levels, Pannel_Numeros;
    //Verifica na memoria se o jogo ja foi aberto

    private int aberto;
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
}