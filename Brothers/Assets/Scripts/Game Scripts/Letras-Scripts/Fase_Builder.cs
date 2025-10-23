using UnityEngine;

public class Fase_Builder : MonoBehaviour
{
    public string Palavra;

    [SerializeField]
    private Check_Letras[] Boxes;
    [SerializeField]
    private Letras[] Letras;

    [SerializeField]
    private Transform posicao_Inicial;

    //Variável responsável por somar a posição x do fase builder
    [SerializeField]
    private float soma;

    void Start()
    {
        soma = 0;
        Construir();
    }
    
    public void Construir()
    {
        //esse foreach vai passar por cada letra e instanciar dependendo de seu nome
        foreach (char l in Palavra.ToCharArray())
        {
            soma += 2.35F;

            //for responsável por construir as letras
            for (int j = 0;j<Letras.Length;j++)
            {
                //atribui posições aleatórias para as letras
                float x = Random.Range(-13f,0f);
                float y = Random.Range(4.80f, 1f);
                  if (l == Letras[j].Nome_Letra)
                {
                    Vector3 pos = new Vector3(x,y);
                    Instantiate(Letras[j].gameObject, pos, Quaternion.identity);
                    break;
                }
            }

            //for responsável por contruir as caixas
            for (int i = 0; i < Boxes.Length; i++)
            {
                if (l == Boxes[i].Letra_Verificada)
                {
                    Vector3 pos = new Vector3(posicao_Inicial.position.x + soma, posicao_Inicial.position.y);
                    Instantiate(Boxes[i].gameObject, pos, Quaternion.identity);
                    break;
                }
            }
        }   
        

    }

}
