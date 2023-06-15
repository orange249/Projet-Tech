using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code3 : MonoBehaviour
{
    public Transform player;
    public Transform background;
    public Transform obstacles;
    public Transform diamonds;

    private Animator anim;
    private Rigidbody2D body;
    private bool grounded;
    public int jumps;

    [SerializeField] private float speed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Tu peut aussi utiliser Input.GetKeyDown ou Input.GetKeyUp

        if (Input.GetKey("a"))
        {
            player.Translate(new Vector3(-0.01f, 0, 0));
        }
        if (Input.GetKey("d"))
        {
            player.Translate(new Vector3(0.01f, 0, 0));
        }
        if (Input.GetKeyDown("space") && jumps < 3)
        {
            Fly();
        }

        anim.SetBool("grounded", grounded);

        background.Translate(new Vector3(-0.012f, 0f, 0));
        obstacles.Translate(new Vector3(-0.012f, 0f, 0));
        diamonds.Translate(new Vector3(-0.012f, 0f, 0));

    }

    public void CollectCoin()

    {
        Debug.Log("Collected a Diamond");
    }
    private void Fly()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
        jumps++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumps = 0;
        }
       
        if (collision.gameObject.tag == "Obstacles")
        {
            grounded = true;
            jumps = 0;
        }
    }
}

