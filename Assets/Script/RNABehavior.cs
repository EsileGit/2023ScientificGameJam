using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using System;

public class RNABehavior : MonoBehaviour
{
    [Inspectable]
    public List<String> killerTagList;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision occurred with the border
        if (killerTagList.Exists(s => (s == collision.gameObject.tag)))
        {
            _KillSelf();
        }
    }

    private void _KillSelf()
    {
        Destroy(gameObject);
    }
}
