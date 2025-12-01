using UnityEngine;
using UnityEngine.SceneManagement;
public class Botao_Numero : MonoBehaviour
{
    [Header("Id para atribuir o numero")]
    public int ID;
    [SerializeField]
    private int Numero_Inicial, Numero_Final;

    public int pontosAtual;

    [SerializeField]
    private GameObject[] estrelas;

    public void Atribuir(int pontos)
    {   
        if(pontos>pontosAtual)
        for (int i = 0;i<pontos;i++)
        {
            estrelas[i].SetActive(true);
            pontosAtual = pontos;
        } 
    }

    public void CarregaP(int pontos)
    {
         for (int i = 0;i<pontos;i++)
        {
            estrelas[i].SetActive(true);
            pontosAtual = pontos;
        }  
    }
    public void Carregar_Fase()
    {
        //Salva os numeros no playerprefs para serem usados na cena de fases de numeros
        PlayerPrefs.SetInt("N_I", Numero_Inicial);
        PlayerPrefs.SetInt("N_F", Numero_Final);

        Atribuidor_Points.instance.SelectedButtonN(this.ID);
        //Carrwega a cena de fases de numeros
        SceneManager.LoadScene("Numeros");

    }
}
