using UnityEngine;
using TMPro;

public class CronometroTimer : MonoBehaviour
{
      [SerializeField]
    private TextMeshProUGUI TimerTxt;
    private float time;

    //Variáveis que vão armazenar os segundos e minutos;
    [HideInInspector]
    public int Sec,Min;
    
    public static CronometroTimer instance;
    //boleanas para pausar o timer
    private Word_manager word_Manager;
    private Number_Manager number_Manager;
    void Awake()
    {
     instance = this;   
    }

    void Start()
    {
        word_Manager = Word_manager.instance;
        number_Manager = Number_Manager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        //isso é pra rodar insependente da fase escolhida
        if( word_Manager != null  && !Word_manager.instance.Correto)
        {
        time+= Time.deltaTime;
        Sec = Mathf.FloorToInt(time % 60);
        Min = Mathf.FloorToInt(time/ 60);
        TimerTxt.text = string.Format("{0:00}:{1:00}",Min,Sec); 
        } 
        else if(number_Manager != null && !Number_Manager.instance.finalizado)
        {
        time+= Time.deltaTime;
        Sec = Mathf.FloorToInt(time % 60);
        Min = Mathf.FloorToInt(time/ 60);
        TimerTxt.text = string.Format("{0:00}:{1:00}",Min,Sec);  
        }
    }

    public int Pontuacao()
    {
        if(time<40)
        {
            return 3;
        }
        else if(time>40&&time<120)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }
}
