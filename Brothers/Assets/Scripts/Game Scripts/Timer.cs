using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI TimerTxt;
    private float time;

    //Variáveis que vão armazenar os segundos e minutos;
    [HideInInspector]
    public int Sec,Min;

 public static Timer instance;

    void Awake()
    {
     instance = this;   
    }
    // Update is called once per frame
    void Update()
    {
        if(!Word_manager.instance.Correto)
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
        else if(time>70&&time<120)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }
}
