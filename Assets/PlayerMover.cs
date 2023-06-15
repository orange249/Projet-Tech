using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMover : MonoBehaviour
{
    public Transform player;
    public Transform background;
    public TMP_Text coinText;
    public int coins;

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
        if (Input.GetKeyDown("space")) 
        {
              player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        }

        background.Translate(new Vector3(-0.001f, 0f, 0));
    }

    public void GetCoin()
    {
        coins++;
        coinText.text = ("Coins: " + coins);
        Debug.Log("Got a coin");
           //do whatever here
    }
}


