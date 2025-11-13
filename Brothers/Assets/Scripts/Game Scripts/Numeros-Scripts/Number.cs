using UnityEngine;
public class Number : MonoBehaviour
{
    public int numero;

    [SerializeField]
    private AudioClip somNumero;

    private AudioControl AC;

    void Start()
    {
        AC = GameObject.FindFirstObjectByType<AudioControl>();
    }
    public void som_Numero()
    {
        AC.Tocar_SFX(somNumero);
    }
    void OnMouseDrag()
    {
        Vector2 pos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
    }
}
