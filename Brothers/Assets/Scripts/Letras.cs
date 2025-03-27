using UnityEngine;

public class Letras : MonoBehaviour
{
    public AudioClip SomdaLetra;
    private AudioControl AC;

    private void Start()
    {
        AC = FindAnyObjectByType<AudioControl>();   
    }

    private void OnMouseDown()
    {
        AC.Tocar_SFX(SomdaLetra);
    }

    private void OnMouseDrag()
    {
        Debug.Log("Voce esta segurando");
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = dir;
    }
}
