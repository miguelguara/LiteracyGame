using UnityEngine;

public class Letras : MonoBehaviour
{
    private bool selected;


    private void OnMouseDrag()
    {
        Debug.Log("Voce esta segurando");
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = dir;
    }

}
