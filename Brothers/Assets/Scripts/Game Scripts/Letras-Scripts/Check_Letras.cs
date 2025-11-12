using UnityEngine;
public class Check_Letras : MonoBehaviour
{
    public char Letra_Verificada;

    private Word_manager WM;

    private GameObject Letra_errada;


    private void Start()
    {
        WM = Object.FindFirstObjectByType<Word_manager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Caso a letra entre em contato com a caixa correta saira o som :)
        if (col.gameObject.GetComponent<Letras>().Nome_Letra == Letra_Verificada)
        {
            WM.Acerto();
            col.gameObject.GetComponent<Letras>().SomLetra();
        }
        else
        {
            Letra_errada = col.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Letras>().Nome_Letra == Letra_Verificada)
        {
            WM.Erro();
        }
        else if (col.gameObject.GetComponent<Letras>().Nome_Letra != Letra_Verificada)
        {
            Letra_errada = null;
        }
    }

    public void expulsar_Letra()
    {
        if (Letra_errada != null)
        {
            Letra_errada.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 9f, ForceMode2D.Impulse);
        }    
    }
}
