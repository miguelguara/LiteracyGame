using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Botao_Fase : MonoBehaviour
{
    [SerializeField]
    private int Numero_de_Letras;
    [SerializeField]
    private int Numero_imagem;

    public void Carregar_Fase() 
    {
        //Salva a quantidade de letras na palavra
        PlayerPrefs.SetInt("QTD_Letras",Numero_de_Letras);
        SceneManager.LoadScene("Tela_Inicial");
    }
}
