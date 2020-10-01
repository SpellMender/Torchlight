using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject litTorch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Torch")
            litTorch.GetComponent<SpriteRenderer>().enabled = true;
    }
}
