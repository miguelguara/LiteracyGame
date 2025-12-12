using UnityEngine;
using TMPro;
public class Number_Manager : MonoBehaviour
{

    public static Number_Manager instance;
    private int Conter;

    public AudioClip Yay;

    [SerializeField]
    private TextMeshProUGUI ContadorUI;

    //Isso vai limitar quantas vezes irá espawnar os numeros!!!!
    [SerializeField]
    private int limit;
    //spaw preefabs
    public GameObject [] Balao_Numeros,Numeros;
    [SerializeField]
    RectTransform Vitoria_Panel;

    private int Num_Ini, Num_Fin;

    //Serve para pausar o Timer!
    [HideInInspector]
    public bool finalizado;

    [SerializeField]
    public void Adicionar(int n) 
    {
        Conter += n;
    }
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //Carregas as informações passadas pelo playerprefs no botão
        Conter = 0;
        Num_Ini = PlayerPrefs.GetInt("N_I");
        Num_Fin = PlayerPrefs.GetInt("N_F");

        //Instancia os numeros e o balão inicial
       // criar_numeros();
        instanciar();
    }


    public void instanciar()
    {
        if (Conter < limit)
        {
            float x = Random.Range(-9f, 9f);
            float y = Random.Range(-4f, 3f);
            int n = Random.Range(Num_Ini, Num_Fin-1);
            Instantiate(Balao_Numeros[n], new Vector2(x, y), Quaternion.identity);
        }
        else
        {
          AudioControl.instance.Tocar_SFX(Yay);
          finalizado =  true;
          if (finalizado)
            {
          Vitoria_Panel.LeanMoveY(50f, 0.5f);  
          Parabens.instance.PreencherStar();
          int p = CronometroTimer.instance.Pontuacao();
          Atribuidor_Points.instance.pontos(p);
        } 
        }
    }

    public void AtualizarUI()
    {
        Conter++;
        ContadorUI.text = Conter.ToString();
    }

    void criar_numeros()
    {
        for (int i = Num_Ini; i < Num_Fin; i++)
        {
         float x = Random.Range(-9f, 9f);
         float y = Random.Range(-4f, 3f);
         Instantiate(Numeros[i],new Vector2(x,y), Quaternion.identity);
        }
    }

}
