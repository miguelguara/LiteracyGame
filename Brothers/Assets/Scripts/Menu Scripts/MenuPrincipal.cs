using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public Image Logo;
    [SerializeField]
    private RectTransform Pannel_Levels;
    //Verifica na memoria se o jogo já foi aberto

    private int aberto;
    public void Awake()
    {
        //faz a logo mudar de escala parecendo uma animação
        Logo.gameObject.LeanScale(new Vector3(1f,1f),0.45f).setLoopPingPong();
        aberto = PlayerPrefs.GetInt("Jogo-Aberto");
        if (aberto == 1) 
        {
            PannelIN();
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
}
