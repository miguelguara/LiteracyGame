using UnityEngine;

public class Number_Ballon : MonoBehaviour
{
    //O nimero que será comparado como uma TAG
    [SerializeField]
    private int numero;
    [SerializeField]
    private AudioClip popClip;
    private Number_Manager NM;
    private AudioControl AC;
    private Animator anim;
    void Start()
    {
        NM = FindFirstObjectByType<Number_Manager>();
        anim = GetComponent<Animator>();
        AC = Object.FindFirstObjectByType<AudioControl>();
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.GetComponent<Number>().numero == numero)
        {
            // c.gameObject.GetComponent<Number>().som_Numero();
            anim.SetBool("Pop", true);
            NM.instanciar();
            AC.Tocar_SFX(popClip);
            Destroy(this.gameObject, 0.3f);
        }
    }
}
