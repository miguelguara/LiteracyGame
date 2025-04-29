using UnityEngine;
using UnityEngine.UI;
public class Letras : MonoBehaviour
{
    public AudioClip SomdaLetra;
    private AudioControl AC;
    private Rigidbody2D rb;

    private void Start()
    {
        AC = FindAnyObjectByType<AudioControl>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        AC.Tocar_SFX(SomdaLetra);
    }

    private void OnMouseDrag()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = dir;
    }

}
