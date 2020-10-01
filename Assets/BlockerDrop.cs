using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody2D>().velocity.y < -0.1f)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
}
