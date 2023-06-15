using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NewPlayerMover : MonoBehaviour
{
   
    public Transform player;
    public Transform background;
    public TMP_Text coinText;
    public int coins;
    public bool died;

    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;


    // Update is called once per frame

   void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        //Tu peut aussi utiliser Input.GetKeyDown ou Input.GetKeyUp
        bool onGround = true;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(player.position.x - 0.432f, player.transform.position.y -  1), Vector2.down, 0.01f);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(player.position.x + 0.432f, player.transform.position.y - 1), Vector2.down, 0.01f);
        if (hit.collider == null && hit2.collider == null)
        {
            onGround = false;
        }

        if (Input.GetKey("a"))
        {
            player.Translate(new Vector3(-8f * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey("d"))
        {
            player.Translate(new Vector3(8f* Time.deltaTime, 0, 0));
        }
        if (Input.GetKeyDown("space") && onGround == true)
        {
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 9, ForceMode2D.Impulse);
        }

        background.Translate(new Vector3(-2.5f * Time.deltaTime, 0f, 0));

        if(player.transform.localPosition.x < -500)
        {
            Debug.Log("You Died!");
            died = true;
            player.GetComponent<SpriteRenderer>().sprite = null;
            StartCoroutine(SceneTransition());
        }

        if(Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        anim.SetBool("grounded", grounded);

    }

    IEnumerator SceneTransition()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void GetCoin()
    {
        if(died == false)
        {
            coins++;
            coinText.text = ("Coins: " + coins);
            Debug.Log("Got a coin");
           //do whatever here
        
        }

        
        
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
