using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Parabens : MonoBehaviour
{

    public static Parabens instance;
    [SerializeField]
    private int FaseIndex;
    //Esse vetor de objetos ficara responsável por ativar as estrelas
    [SerializeField]
    private GameObject[] stars;

    void Awake()
    {
        instance = this;
    }
    public void Reload() 
    {
        FaseIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(FaseIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PreencherStar()
    {
        //Ele preenche as estrelas do painel de parabens!!!
        int star = CronometroTimer.instance.Pontuacao();
        for (int i = 0; i < star; i++)
        {
           stars[i].SetActive(true);
           stars[i].LeanScale(new Vector3(1.2f, 1.2f),0.78f).setLoopPingPong();
        }
    }
}
