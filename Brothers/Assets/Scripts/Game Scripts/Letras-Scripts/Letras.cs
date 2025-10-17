using UnityEngine;
using UnityEngine.UI;
public class Letras : MonoBehaviour
{
    public AudioClip SomdaLetra;
    private AudioControl AC;
    public char Nome_Letra;
    private Rigidbody2D rb;

    private void Start()
    {
        AC = FindAnyObjectByType<AudioControl>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.linearVelocity.y <1f)
        {
            rb.linearVelocity = Vector2.zero;    
        }
    }
    public void SomLetra()
    {
        AC.Tocar_SFX(SomdaLetra);
    }

    private void OnMouseDrag()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = dir;
    }

}
