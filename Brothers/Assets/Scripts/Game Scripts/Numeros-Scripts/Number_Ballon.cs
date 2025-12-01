using Unity.Mathematics;
using UnityEngine;

public class Number_Ballon : MonoBehaviour
{
    //O numero que será comparado como uma TAG
    [SerializeField]
    private int numero;
    [SerializeField]
    private AudioClip popClip;

    //Referencia o sprite do numero para ser destruido na animação de explosão do balão
    private GameObject NumberObj;
    private Number_Manager NM;
    private AudioControl AC;
    private Animator anim;
    void Start()
    {
        NM = FindFirstObjectByType<Number_Manager>();
        anim = GetComponent<Animator>();
        AC = Object.FindFirstObjectByType<AudioControl>();
        NumberObj = transform.GetChild(0).gameObject;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.GetComponent<Number>().numero == numero)
        {
            // c.gameObject.GetComponent<Number>().som_Numero();
            anim.SetBool("Pop", true);
            //Instancia um novo balão e atualiza o contador
            NM.instanciar();
            NM.AtualizarUI();
            AC.Tocar_SFX(popClip);
            Destroy(NumberObj);
            Destroy(this.gameObject, 0.25f);
        }
    }
}
