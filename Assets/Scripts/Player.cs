using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float hor, vert;
    Rigidbody2D rb;

    Vector3 campos = new Vector3(0f, 0f, -10f);

    public int speed;

    float kd = 2;
    float time = 0;

    public GameObject bullet;
    public GameObject ShootPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        if(time < kd)
        {
            time = time + Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(bullet, ShootPos.transform.position, ShootPos.transform.rotation);
            time = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.transform.Translate(Vector2.down * speed * vert * Time.deltaTime);
        rb.transform.Rotate(Vector3.back * speed * 30 * hor * Time.deltaTime);
    }

    private void LateUpdate()
    {
        campos.x = rb.transform.position.x;
        campos.y = rb.transform.position.y;
        Camera.main.transform.position = campos;
    }
}
