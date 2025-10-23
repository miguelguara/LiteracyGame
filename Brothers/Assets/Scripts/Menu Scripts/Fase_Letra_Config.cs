using UnityEngine;
public class Fase_Letra_Config : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;

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
        
    }

}
