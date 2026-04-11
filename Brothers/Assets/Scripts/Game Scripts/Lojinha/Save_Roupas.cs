using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Save_Roupas : MonoBehaviour
{
    [HideInInspector]
    public static Save_Roupas instance;

    void Awake()
    {
        if (instance == null) instance = this;
    }
    public void Salvar_Roupas()
    {
        string path = Path.Combine(Application.persistentDataPath,"Roupas.json");
        DadosRoupas dados = new DadosRoupas();
        for(int i = 0; i <Lojinha.Instance.roupasButtons.Count;i++)
        {
            //recebe o valor boleano da loja
            dados.itensComprados.Add(Lojinha.Instance.roupasButtons[i].Comprado);
        }
        foreach(Sprite s in Selecao_Roupa.instance.chapeus)
        {
            dados.nomeSprites.Add(s.name);
        }

        string RoupasData = JsonUtility.ToJson(dados);
        File.WriteAllText(path,RoupasData);
        Debug.Log("Os dados foram salvos: "+path);

    }

    public void Delete()
    {
      string path = Path.Combine(Application.persistentDataPath,"Roupas.json");
      File.Delete(path);  
    }

    public void Load_Roupas()
    {   
        //caminho dos dados
        string path = Path.Combine(Application.persistentDataPath,"Roupas.json");
        //checa se os dados existem
        if(File.Exists(path))
        {
            string Json = File.ReadAllText(path);
            DadosRoupas dados = JsonUtility.FromJson<DadosRoupas>(Json);
            for(int i = 0; i <dados.itensComprados.Count;i++)
            {
            Lojinha.Instance.roupasButtons[i].Comprado = dados.itensComprados[i];
            }
            foreach (string nome in dados.nomeSprites)
            {
            Sprite sp = Resources.Load<Sprite>("Chapeus/" + nome);
            Selecao_Roupa.instance.chapeus.Add(sp);
            }
            Debug.Log("Os dados foram carregados com sucesso!");
        }
        else{Debug.Log("Mano esse dado não existe!");}
    }

}

[System.Serializable]
class DadosRoupas
{
    public List<string> nomeSprites = new List<string>();
    public List<bool> itensComprados = new List<bool>();    
}
