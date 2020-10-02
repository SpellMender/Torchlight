using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * code base found free to use at https://sharpcoderblog.com/blog/2d-platformer-character-controller
 * modified by John Miller ThunderBroJohn on github
 */

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]



public class CharacterControllerFather : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public Camera mainCamera;

    // Who is moving?
    // 1 = father, 2 = boy, 3 = daughter
    private static int activeCharacter = 0;
    //private int switchChar = 0;

    // Physics
    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    Collider2D mainCollider;
    // Check every collider except Player and Ignore Raycast
    LayerMask layerMask = ~(1 << 2 | 1 << 8);
    Transform t;

    // Use this for initialization
    void Start()
    {
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<Collider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        gameObject.layer = 8;

        if (mainCamera)
            cameraPos = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //check active character
        activeCharacter = GameController.activeCharacter;
        if (activeCharacter != 1)
        {
            return;
        }

        // Movement controls
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (isGrounded || r2d.velocity.x > 0.01f))
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
            GetComponent<Animator>().Play("Walk");
        }
        else
        {
            if (isGrounded || r2d.velocity.magnitude < 0.01f)
            {
                moveDirection = 0;
            }
            GetComponent<Animator>().Play("Idle");
        }

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        // Camera follow
        if (mainCamera)
            mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
    }

    void FixedUpdate()
    {
        //if (Input.GetKeyUp(KeyCode.E) && switchChar)
        //{
        //    GameController.switchChar = true;
        //    GameController.activeCharacter = 1;
        //}
        //switchChar = false;

        Bounds colliderBounds = mainCollider.bounds;
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, 0.1f, 0);
        // Check if player is grounded
        activeCharacter = GameController.activeCharacter;
        if (activeCharacter != 1)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = Physics2D.OverlapCircle(groundCheckPos, 0.23f, layerMask);
        }

        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);

        // Simple debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, 0.23f, 0), isGrounded ? Color.green : Color.red);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Torch")
        {
                GameController.switchChar = 1;
            //else { GameController.switchChar = 0; }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Torch")
        {
                GameController.switchChar = 1;
            //else { GameController.switchChar = 0; }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Torch")
        {
            GameController.switchChar = 0;
        }
    }
}