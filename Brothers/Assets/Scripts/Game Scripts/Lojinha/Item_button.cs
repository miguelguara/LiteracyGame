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
        imagemChapeu.sprite = chapeu;
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

    public void Atualizar_UI()
    {
        if(Comprado) text.text = "Comprado";
    }

}
