using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    public AreaChecker areaChecker;
    public int cellCount = 1;
    public List<GameObject> cellsIncorperated = new List<GameObject>();

    public SpriteRenderer spriteRenderer { get; private set; }
    public Rigidbody2D rb2d;
    public float moveSpeed { get; private set; } = 4f;
    [field: SerializeField] private bool dead = false;

    [field: SerializeField] private Vector2 input;


    private void Awake()
    {
        GameMan.player = this;
    }

    // Runs each frame
    public void Update() //Input goes here
    {
        if (dead) Destroy(gameObject); //if dead destroy player

        //Movement Logic
        input.x = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            input.x = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            input.x = 1f;
        }

        input.y = 0f;

        if (Input.GetKey(KeyCode.S))
        {
            input.y = -1f;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            input.y = 1f;
        }

        input = input.normalized;
    }

    private void FixedUpdate() //Physics go here, runs every physics tick
    {
        rb2d.MovePosition(rb2d.position + input * moveSpeed * Time.fixedDeltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death Zone"))
        {
            dead = true;
        }
    }


}
