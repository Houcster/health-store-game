using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private Main main;
    private Score score;
    private AudioClip loseSound;
    private AudioSource audioSrc;

    private void Start()
    {
        main = GameObject.FindObjectOfType<Main>();
        score = GameObject.FindObjectOfType<Score>();
        audioSrc = GetComponent<AudioSource>();
        loseSound = Resources.Load<AudioClip>("LoseSound");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Got collision");
        //Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == 3)
        {
            /*Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();
            body.bodyType = RigidbodyType2D.Static;*/
            //audioSrc.PlayOneShot(loseSound, 0.25f);
            AudioManager.Instance.Play(loseSound);
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Main.isGameOver = true;
            score.scoreText.text = "GAME OVER";
            StartCoroutine(main.BlinkGameObject(collision.gameObject, 3, 0.4f, true));
        }
    }
}
