using UnityEngine;

public class Number_Ballon : MonoBehaviour
{
    [SerializeField]
    private int numero;

    private Number_Manager NM;
    void Start()
    {
        NM = FindFirstObjectByType<Number_Manager>();
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        NM.instanciar();
    }
}
