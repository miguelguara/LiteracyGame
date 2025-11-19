using UnityEngine;
using UnityEngine.SceneManagement;
public class Atribuidor_Points : MonoBehaviour
{
//Esses ints recebem o ID dos botões para atribuir seus pontos no MENU
[SerializeField]
  private int ID_botaoF,ID_botaoN;

// Vai procurar os botõesF
private Botao_Fase[] btsF;
  private int pontuacao;
  public static Atribuidor_Points instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void OnSceneLoaded(Scene cena, LoadSceneMode mode)
    {
        if (cena.name == "Menu")
        {
            btsF = Object.FindObjectsByType<Botao_Fase>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

            // Quando voltar ao menu, aplicar os pontos
            foreach (Botao_Fase b in btsF)
            {
                if (b.ID == ID_botaoF)
                {
                    b.Atribuir(pontuacao);
                    ID_botaoF = 0;
                    break;
                }
            }
        }
    }

    public void pontos(int p)
    {
       pontuacao = p; 
    }
    //passa os vaores para as variáveis dos botoes
    public void SelectedButtonF(int b)
    {
        ID_botaoF = b;        
    }

     public void SelectedButtonN(int b)
    {
        ID_botaoN = b;        
    }
}
