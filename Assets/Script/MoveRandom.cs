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
    public float speed = 0.1f; // pix/s
    [Inspectable]
    public float chanceOfChangingDirection = 0.1f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AddRandomImpulse();
    }

    // Update is called once per frame
    void Update()
    {
        if (_GetRand() < chanceOfChangingDirection * Time.deltaTime)
        {
            AddRandomImpulse();
        }
    }

    void AddRandomImpulse()
    {
        Vector2 normRandomVec = new Vector2(_GetRand(), _GetRand());
        normRandomVec.Normalize();
        rb.AddForce(normRandomVec * speed, ForceMode2D.Impulse);
    }

    private float _GetRand()
    {
        return UnityEngine.Random.Range(0.0f, 1.0f);
    }
}
