using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Botao_Fase : MonoBehaviour
{
    [Header("ID -para o atribuidor de pontos identificar o botão")]
    public int ID;

    [SerializeField]
    private string Palavra;
    [SerializeField]
    private int Numero_imagem;
    [SerializeField]
    private GameObject[] estrelas;

    [HideInInspector]
    public int pontosAtual;

   public void Atribuir(int pontos)
    {
        if(pontos>pontosAtual)
        for (int i = 0;i<pontos;i++)
        {
            estrelas[i].SetActive(true);
            pontosAtual = pontos;
        } 
    }

    public void CarregarP(int pontos)
    {
        pontosAtual = pontos;
        for (int i = 0;i<pontosAtual;i++)
        {
            estrelas[i].SetActive(true);
        } 
    }
    

    public void Carregar_Fase() 
    {
        //Salva a quantidade de letras na palavra
        PlayerPrefs.SetString("Word", Palavra.ToUpper());
        PlayerPrefs.SetInt("IDX_Imagem",Numero_imagem);
        //Passa o ID para o atribuidor de pontos
        Atribuidor_Points.instance.SelectedButtonF(this.ID);
        //Carrega a fase
        SceneManager.LoadScene("Fase");
    }
}
