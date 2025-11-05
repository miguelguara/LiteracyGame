using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Botao_Fase : MonoBehaviour
{
    [SerializeField]
    private string Palavra;
    [SerializeField]
    private int Numero_imagem;


    public void Carregar_Fase() 
    {
        //Salva a quantidade de letras na palavra
        PlayerPrefs.SetString("Word", Palavra.ToUpper());
        PlayerPrefs.SetInt("IDX_Imagem",Numero_imagem);
        SceneManager.LoadScene("Fase");
    }
}
