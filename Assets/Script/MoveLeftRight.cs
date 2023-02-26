using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    private float speed = 10f;
    private bool moveLeft = true;
    private Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        Color colors = new Color(r: Random.Range(0, 1F), g: Random.Range(0, 1F), b: Random.Range(0, 1F));
        renderer.material.color = colors;
        speed = Random.Range(5, 10);
    }

    void Update()
    {
        Move();

    }

    private void Move()
    {
        if (transform.position.x <= -10)
        {
            moveLeft = false;

        }
        else if (transform.position.x >= 10)
        {
            moveLeft = true;
        }
        if (moveLeft)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (!moveLeft)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
