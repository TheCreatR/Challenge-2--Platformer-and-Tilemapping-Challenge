﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{

    private Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;

    private int count;
    public Text countText;
    public Text winText;
    
    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
    }

    void Update(){
        if (Input.GetKey("escape"))
     Application.Quit();

    }

    void FixedUpdate(){
        
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
	}

    void OnCollisionStay2D(Collision2D collision){
        if(collision.collider.tag == "Ground"){
            if(Input.GetKey(KeyCode.UpArrow)){
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 4)
		{
			winText.text = "You win!";
		}
	}
}
