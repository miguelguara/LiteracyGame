using UnityEngine;
using TMPro;
public class Number_Manager : MonoBehaviour
{
    private int Conter;

    [SerializeField]
    private TextMeshProUGUI ContadorUI;
    //Isso vai limitar quantas vezes irá espawnar os numeros!!!!
    [SerializeField]
    private int limit;
    public GameObject Numeros;
    [SerializeField]
    RectTransform Vitoria_Panel;

    void Start()
    {
        Conter = 0;
    }
    public void instanciar()
    {
        if (Conter < limit)
        {
            float x = Random.Range(-9f, 9f);
            float y = Random.Range(-4f, 3f);
            Instantiate(Numeros, new Vector2(x, y), Quaternion.identity);
            AtualizarUI();
        }
        else
        {
          Vitoria_Panel.LeanMoveY(50f, 0.5f);  
        }
    }

    public void AtualizarUI()
    {
        Conter++;
        ContadorUI.text = Conter.ToString();
    }

}
