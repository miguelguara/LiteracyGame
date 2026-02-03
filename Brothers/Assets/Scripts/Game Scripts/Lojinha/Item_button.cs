using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Item_button : MonoBehaviour
{
    [SerializeField]
    private Sprite chapeu;
    [SerializeField]
    private int custo;
    [HideInInspector]
    public bool Comprado;
    public TextMeshProUGUI text;
    public Image imagemChapeu;

    void Start()
    {
        //checa se o chapeu já foi comprado e já atualiza o texto do jogo
         imagemChapeu.sprite = chapeu;
        if(Comprado)
        {
            Atualizar_UI();
        }
        else
        {
          text.text = custo.ToString();  
        }
        
    }

    public void Comprar_Chapeu()
    {
        if(Lojinha.Instance.moedas >= custo && Comprado == false)
        {
            Lojinha.Instance.Comprar(custo);
            Selecao_Roupa.instance.Adicionar_Roupa(chapeu);
            Comprado = true;
            Atualizar_UI();
        }
    }

   //essa função serve pra atualizar a UI no momento que é comprado
    public void Atualizar_UI()
    {
        if(Comprado)
        { 
        text.text = "Comprado"; 
        text.fontSize = 18;
        text.color = Color.green;
        }
    }

}
