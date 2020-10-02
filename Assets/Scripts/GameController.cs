using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public static int activeCharacter = 1;
    public static int switchChar = 0;
    public GameObject boy;
    public GameObject daughter;
    public GameObject father;
    public GameObject fatherTorch;
    public GameObject daughterTorch;
    public GameObject boyTorch;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        fatherTorch.GetComponent<SpriteRenderer>().enabled = false;
        daughterTorch.GetComponent<SpriteRenderer>().enabled = false;
        boyTorch.GetComponent<SpriteRenderer>().enabled = false;

        boy.GetComponent<Rigidbody2D>().mass = 0.001f;
        daughter.GetComponent<Rigidbody2D>().mass = 0.001f;
        ActivateFather();
    }

    // AC 1
    void ActivateFather()
    {
        daughter.tag = "Player";
        father.tag = "Active";
        boy.tag = "Player";

        father.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        father.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        boy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        daughter.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

        father.GetComponent<CapsuleCollider2D>().isTrigger = false;
        boy.GetComponent<CapsuleCollider2D>().isTrigger = true;
        daughter.GetComponent<CapsuleCollider2D>().isTrigger = true;

        daughter.GetComponent<Animator>().Play("Torchless");
        boy.GetComponent<Animator>().Play("Torchless");
        father.GetComponent<Animator>().Play("Idle");

        fatherTorch.GetComponent<SpriteRenderer>().enabled = true;
        daughterTorch.GetComponent<SpriteRenderer>().enabled = false;
        boyTorch.GetComponent<SpriteRenderer>().enabled = false;
    }

    // AC 2
    void ActivateBoy()
    {
        daughter.tag = "Player";
        father.tag = "Player";
        boy.tag = "Active";

        fatherTorch.GetComponent<SpriteRenderer>().enabled = false;
        daughterTorch.GetComponent<SpriteRenderer>().enabled = false;
        boyTorch.GetComponent<SpriteRenderer>().enabled = true;

        father.GetComponent<CapsuleCollider2D>().isTrigger = true;
        boy.GetComponent<CapsuleCollider2D>().isTrigger = false;
        daughter.GetComponent<CapsuleCollider2D>().isTrigger = true;

        father.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        boy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        boy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        daughter.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

        daughter.GetComponent<Animator>().Play("Torchless");
        boy.GetComponent<Animator>().Play("Idle");
        father.GetComponent<Animator>().Play("Torchless");
    }

    // AC 3
    void ActivateDaughter()
    {
        daughter.tag = "Active";
        father.tag = "Player";
        boy.tag = "Player";

        fatherTorch.GetComponent<SpriteRenderer>().enabled = false;
        daughterTorch.GetComponent<SpriteRenderer>().enabled = true;
        boyTorch.GetComponent<SpriteRenderer>().enabled = false;

        father.GetComponent<CapsuleCollider2D>().isTrigger = true;
        boy.GetComponent<CapsuleCollider2D>().isTrigger = true;
        daughter.GetComponent<CapsuleCollider2D>().isTrigger = false;

        father.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        boy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        daughter.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        daughter.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        daughter.GetComponent<Animator>().Play("Idle");
        boy.GetComponent<Animator>().Play("Torchless");
        father.GetComponent<Animator>().Play("Torchless");
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        // if needing to reset press r
        if (Input.GetKeyDown(KeyCode.R))
        {
            activeCharacter = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        // if character active is touching character not active and presses "e" swap active character to non active
        if (Input.GetKeyUp(KeyCode.E))
        {
            switch (switchChar)
            {
                case 1:
                    activeCharacter = 1;
                    ActivateFather();
                    switchChar = 0;
                    break;
                case 2:
                    activeCharacter = 2;
                    ActivateBoy();
                    switchChar = 0;
                    break;
                case 3:
                    activeCharacter = 3;
                    ActivateDaughter();
                    switchChar = 0;
                    break;
                default:
                    switchChar = 0;
                    break;
            }
        }
    }
}
