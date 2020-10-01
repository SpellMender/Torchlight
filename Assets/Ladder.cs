using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject foldedLadder;
    public GameObject droppedLadder;

    private bool dropLadder = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dropLadder)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                foldedLadder.SetActive(false);
                droppedLadder.SetActive(true);
            }
        }
        dropLadder = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Active") || collision.gameObject.tag == "Torch")
        {
            dropLadder = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Active") || collision.gameObject.tag == "Torch")
        {
            dropLadder = true;
        }
    }

}
