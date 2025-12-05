using System.Collections.Generic;
using UnityEngine;

public class Fase_Builder : MonoBehaviour
{
    //mexe nas escalas dos objetos
    private float scale_box,scale_letra;
    public string Palavra;
    [SerializeField]
    private Check_Letras[] Boxes;
    [SerializeField]
    private Letras[] Letras;

    [SerializeField]
    private Transform posicao_Inicial;

    private Word_manager instance;

    //Variável responsável por somar a posição x do fase builder
    [SerializeField]
    private float soma,distancia = 2.35f;

    //listas para deletar os objetos em cena e reconstruir-los
    private List<GameObject> listletras = new List<GameObject>();
    private List<GameObject> listboxes = new List<GameObject>();

    void Start()
    {
        soma = 0;
        Palavra = PlayerPrefs.GetString("Word");
        scale_letra = 1f;
        scale_box = 0.60f;
        instance = Word_manager.instance;
        Construir();
    }

    public void Construir()
    {
        //esse foreach vai passar por cada letra e instanciar dependendo de seu nome
        foreach (char l in Palavra.ToCharArray())
        {
            soma += distancia;

            //for responsável por construir as letras
            for (int j = 0; j < Letras.Length; j++)
            {
                //atribui posições aleatórias para as letras
                float x = Random.Range(-8.50f, 4.50f);
                float y = Random.Range(3.66f, -0.35f);
                if (l == Letras[j].Nome_Letra)
                {
                    Vector3 pos = new Vector3(x, y);
                    var CBO = Instantiate(Letras[j].gameObject, pos, Quaternion.identity);
                    //serve para definir a escala das letras 
                    CBO.gameObject.transform.localScale = new Vector3(scale_letra, scale_letra, scale_letra);
                    listletras.Add(CBO);
                    break;
                }
            }

            //for responsável por contruir as caixas
            for (int i = 0; i < Boxes.Length; i++)
            {
                if (l == Boxes[i].Letra_Verificada)
                {
                    //instancia as caixas de checagem
                    Vector3 pos = new Vector3(posicao_Inicial.position.x + soma, posicao_Inicial.position.y);
                    var CBO = Instantiate(Boxes[i].gameObject, pos, Quaternion.identity);
                    
                    instance.Adicionar_CheckBox(CBO.gameObject.GetComponent<Check_Letras>());
                    CBO.gameObject.transform.localScale = new Vector3(scale_box, scale_box, scale_box);
                    listboxes.Add(CBO);
                    break;
                }
            }
        }

    }

    public void Recriar()
    {
        //destroy all gameobjects in scene
        foreach (var box in listboxes)
        {
            Destroy(box);
        }
        foreach (var letter in listletras)
        {
            Destroy(letter);
        }
        //clear all the needed lists
        listboxes.Clear();
        listletras.Clear();
        instance.Letras_Erradas.Clear();

        //redução de escalas e distancias
        distancia -= 0.35f;
        soma = 0;
        scale_box -= 0.085f;
        scale_letra -=0.18f;

        Construir();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "CheckBox")
        {
            Recriar();
        }
    }
}
