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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * direction);
    }

}
