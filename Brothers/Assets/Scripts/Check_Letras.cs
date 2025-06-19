using UnityEngine;

public class Check_Letras : MonoBehaviour
{
    public char Letra_Verificada;
    //Will send a message if the letter is right
    private Word_manager WM;

    private void Start()
    {
        WM = FindObjectOfType<Word_manager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.GetComponent<Letras>().Nome_Letra == Letra_Verificada) 
        {
            WM.Acerto();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Letras>().Nome_Letra == Letra_Verificada)
        {
            WM.Erro();
        }
    }
}
