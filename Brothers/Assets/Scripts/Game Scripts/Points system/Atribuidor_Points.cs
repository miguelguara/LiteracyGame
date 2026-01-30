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

  private Botao_Numero[] btsN;
  private int pontuacao;
  public static Atribuidor_Points instance;

  //Transform responsável por agrupar o botões
  [SerializeField]
  private Transform btsTrasnform;
  [SerializeField]
  private Transform btsNTransform;

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
        //Encontra o transform do objeto pai dos botões
        btsTrasnform = GameObject.Find("Content_Letras").transform;
        btsNTransform = GameObject.Find("Content_Num").transform;
        btsF = btsTrasnform.GetComponentsInChildren<Botao_Fase>();
        btsN = btsNTransform.GetComponentsInChildren<Botao_Numero>();
        Load();
    }

    void OnSceneLoaded(Scene cena, LoadSceneMode mode)
    {
        
        if (cena.name == "Menu")
        {
            btsTrasnform = GameObject.Find("Content_Letras").transform;
            btsNTransform = GameObject.Find("Content_Num").transform;
            btsF = btsTrasnform.GetComponentsInChildren<Botao_Fase>();
            btsN = btsNTransform.GetComponentsInChildren<Botao_Numero>();
            Load();


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
             foreach (Botao_Numero b in btsN)
            {
                if (b.ID == ID_botaoN)
                {
                    b.Atribuir(pontuacao);
                    ID_botaoN = 0;
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

    //Regioes responsáveis por salvar os pontos do jogo:
    public void Save()
    {
        //instancia o objeto que será trasformado em Json
        PontosSalvos p = new PontosSalvos();
        p.pontuacaoLetras = new List<int>();
        p.pontuacaoNum = new List<int>();

    // Salva todos os botões
    for (int i = 0; i < btsF.Length; i++)
        p.pontuacaoLetras.Add(btsF[i].pontosAtual);
    
    for (int i = 0; i < btsN.Length; i++)
        p.pontuacaoNum.Add(btsN[i].pontosAtual);

    //strings de path e do arquivo Json
    string path = Path.Combine(Application.persistentDataPath, "Dados.json");
    string json = JsonUtility.ToJson(p);

    File.WriteAllText(path, json);

    Debug.Log("Salvo em: " + path);  
    }



public void Load()
{
    string path = Path.Combine(Application.persistentDataPath, "Dados.json");


    if (!File.Exists(path))
    {
        Debug.LogWarning("Arquivo de dados não encontrado em: " + path);
        return;
    }
    string json = File.ReadAllText(path);
    PontosSalvos p = JsonUtility.FromJson<PontosSalvos>(json);

    for (int i = 0; i < btsF.Length -1; i++)
    {
        btsF[i].pontosAtual = p.pontuacaoLetras[i];
        btsF[i].CarregarP(p.pontuacaoLetras[i]);
    }

     for (int i = 0; i < btsN.Length; i++)
    {
        btsN[i].pontosAtual = p.pontuacaoNum[i];
        btsN[i].CarregaP(p.pontuacaoNum[i]);
    }

}

}
//classe de dados que será transformada em arquivo Json
[Serializable]
public class PontosSalvos
{
    public List<int> pontuacaoLetras;
    public List<int> pontuacaoNum;
}

