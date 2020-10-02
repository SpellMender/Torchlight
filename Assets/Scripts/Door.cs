using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject openedDoor;
    private bool unlocked = false;


    // Update is called once per frame
    void Update()
    {
        if (TorchCounter.unlockDoor == true && unlocked == false) 
        {
            unlocked = true;

            //Now show open the door
            openedDoor.GetComponent<SpriteRenderer>().enabled = true;   //The open door sprite
            gameObject.GetComponent<SpriteRenderer>().enabled = false;  //The closed door sprite
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (unlocked == true && collision.tag.Contains("Active"))
        {
            TorchCounter.torchCount = 0;
            TorchCounter.unlockDoor = false;
            GameController.switchChar = 1;
            GameController.activeCharacter = 1;
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
