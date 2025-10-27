using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Fase_Letra_Config : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;
    [SerializeField]
    private InputField inputField;
    private string Palavra;
    public void Ativar()
    {
        Panel.SetActive(true);
    }

    public void Desativar()
    {
        Panel.SetActive(false);
    }
    
    public void criar()
    {
        Palavra = inputField.text.ToUpper();
        PlayerPrefs.SetString("Word", Palavra);
        SceneManager.LoadScene("Tela_Inicial");
    }

}
