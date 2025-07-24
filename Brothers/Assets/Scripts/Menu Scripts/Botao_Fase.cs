using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Botao_Fase : MonoBehaviour
{
    [SerializeField]
    private int Numero_de_Letras;
    [SerializeField]
    private int Numero_imagem;

    [SerializeField]
    private int Index_Fase;

    public void Carregar_Fase() 
    {
        //Salva a quantidade de letras na palavra
        PlayerPrefs.SetInt("QTD_Letras",Numero_de_Letras);
        PlayerPrefs.SetInt("IDX_Imagem",Numero_imagem);
        SceneManager.LoadScene(Index_Fase);
    }
}
