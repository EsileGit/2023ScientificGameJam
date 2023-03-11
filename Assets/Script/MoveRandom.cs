using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using System;

[Inspectable]
public class MoveRandom : MonoBehaviour
{
    [Inspectable]
    public Vector2 direction = new Vector2 (0, 1);
    [Inspectable]
    public float speed = 0.001f; // pix/s
    [Inspectable]
    public float chanceOfChangingDirection = 0.1f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start " + name);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(speed * direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter!" + collision.gameObject.tag);
        // Check if the collision occurred with the border
        if (collision.gameObject.tag == "CellBoundary")
        {
            // Handle the collision with the border
            Debug.Log("Collision with border detected!");
        }
    }
}
