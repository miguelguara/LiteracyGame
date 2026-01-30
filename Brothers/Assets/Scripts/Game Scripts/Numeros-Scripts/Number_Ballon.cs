using System.Collections;
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
            StartCoroutine(Estourar(c));
        }
    }

    IEnumerator Estourar(Collision2D c)
    {
            anim.SetBool("Pop", true);
            //Instancia um novo balão e atualiza o contador
            NM.Prox_Num();
            AC.Tocar_SFX(popClip);
            yield return new WaitForSeconds(0.3f);
            c.gameObject.GetComponent<Number>().som_Numero();
            Destroy(NumberObj);
            Destroy(this.gameObject, 0.25f);
    }
}
