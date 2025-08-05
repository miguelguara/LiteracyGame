using UnityEngine;
using UnityEngine.UI;
public class Letras : MonoBehaviour
{
    public AudioClip SomdaLetra;
    private AudioControl AC;
    public char Nome_Letra;

    private void Start()
    {
        AC = FindAnyObjectByType<AudioControl>();
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
