using UnityEngine;

public class Number_Manager : MonoBehaviour
{
    [SerializeField]
    private int Conter;

    //Isso vai limitar quantas vezes irá espawnar os numeros!!!!
    private int limit;
    public GameObject Numeros;

    void Start()
    {
        Conter = 0;
    }
    public void instanciar()
    {
        float x = Random.Range(-9f, 9f);
        float y = Random.Range(-4f, 3f);
        Instantiate(Numeros, new Vector2(x, y), Quaternion.identity);
        Conter ++;
    }

}
