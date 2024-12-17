using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    void Start()
    {
        speed = 5f;
        rb = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        Vector3 R = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        float angle = Mathf.Atan2(R.y, R.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3 (0, 0, angle);
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.AddForce(dir);
    }
}
