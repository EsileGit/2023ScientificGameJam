using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using System;

public class ViralBehavior : MonoBehaviour
{
    [Inspectable]
    public List<String> killerTagList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter!" + collision.gameObject.tag);
        // Check if the collision occurred with the border
        if (killerTagList.Exists(s => (s == collision.gameObject.tag)))
        {
            _KillSelf();
        }
    }

    private void _KillSelf()
    {
        Debug.Log(name + " has been killed");
        Destroy(gameObject);
    }
}
