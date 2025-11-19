using UnityEngine;
using UnityEngine.SceneManagement;

public class Return_Script : MonoBehaviour
{
    [SerializeField]
    private GameObject BG_Retorno;
    
    public void AtivarMenu()
    {
        BG_Retorno.SetActive(true);
    }

    public void Retornar_TelaSelecao() 
    {
        Atribuidor_Points.instance.pontos(0);
        SceneManager.LoadScene("Menu");
    }

    public void Nao() 
    {
        BG_Retorno.SetActive(false);
    }
}
