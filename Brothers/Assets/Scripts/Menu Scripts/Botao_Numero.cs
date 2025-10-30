using UnityEngine;
using UnityEngine.SceneManagement;
public class Botao_Numero : MonoBehaviour
{
    [SerializeField]
    private int Numero_Inicial, Numero_Final;

    public void Carregar_Fase()
    {
        //Salva os numeros no playerprefs para serem usados na cena de fases de numeros
        PlayerPrefs.SetInt("N_I", Numero_Inicial);
        PlayerPrefs.SetInt("N_F", Numero_Final);
        //Carrwega a cena de fases de numeros
        SceneManager.LoadScene("Fases_Numeros");

    }
}
