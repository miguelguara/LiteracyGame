using System;
using System.Collections.Generic;
using System.IO;
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

  //Transform responsável por agruar o botões
  private Transform btsTrasnform;

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
    void Start()
    {
        btsF = btsTrasnform.GetComponentsInChildren<Botao_Fase>();
        Load();
    }

    void OnSceneLoaded(Scene cena, LoadSceneMode mode)
    {
        btsTrasnform = GameObject.Find("Content_Letras").transform;
        if (cena.name == "Menu")
        {
            btsF = btsTrasnform.GetComponentsInChildren<Botao_Fase>();

            Load();

            // Quando voltar ao menu, aplicar os pontos
            foreach (Botao_Fase b in btsF)
            {
                if (b.ID == ID_botaoF)
                {
                    b.Atribuir(pontuacao);
                    ID_botaoF = 0;
                    Save();
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

    //Depois atribuir o valor do jogo dos balões
    //Regioes responsáveis por salvar os pontos do jogo:
    public void Save()
    {
        PontosSalvos p = new PontosSalvos();
        p.pontuacaoLetras = new List<int>();

    // Salva todos os botões
    for (int i = 0; i < btsF.Length; i++)
        p.pontuacaoLetras.Add(btsF[i].pontosAtual);
    

    //strings de path e do arquivo Json
    string path = Path.Combine(Application.persistentDataPath, "Dados.json");
    string json = JsonUtility.ToJson(p);

    File.WriteAllText(path, json);

    Debug.Log("Salvo em: " + path);  
    }


public void Load()
{
    string path = Path.Combine(Application.persistentDataPath, "Dados.json");

    string json = File.ReadAllText(path);
    PontosSalvos p = JsonUtility.FromJson<PontosSalvos>(json);

    for (int i = 0; i < btsF.Length -1; i++)
    {
        btsF[i].pontosAtual = p.pontuacaoLetras[i];
        btsF[i].CarregarP(p.pontuacaoLetras[i]);
    }
}

}
//classe de dados que será transformada em arquivo Json
[Serializable]
public class PontosSalvos
{
    public List<int> pontuacaoLetras;
    //public List<int> pontuacaoNum;
}

