using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDestroyer : MonoBehaviour
{
    public AudioClip doneSound;
    private AudioClip loseSound;
    private Score score;
    private Main main;
    public string Type;

    private void Start()
    {
        main = GameObject.FindObjectOfType<Main>();
        score = GameObject.FindObjectOfType<Score>();
        loseSound = Resources.Load<AudioClip>("LoseSound");
        if (Main.scoreValue >= 40)
        {
            main.activateTrashBasket(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Type)
        {
            //audioSrc.PlayOneShot(doneSound);
            AudioManager.Instance.Play(doneSound);
            GameObject.Destroy(collision.gameObject);
            Main.scoreValue += 1;
            score.scoreText.text = "" + Main.scoreValue;
            if (Main.movementSpeed < 8)
            {
                Main.movementSpeed += 0.02f;
            }

            if (Main.scoreValue == 40)
            {
                main.activateTrashBasket(true);
            }

            switch (Main.scoreValue)
            {
                case int n when (n >= 10 && n < 20):
                    Main.itemsSpawnRange = 5;
                    break;

                case int n when (n >= 20 && n < 30):
                    Main.itemsSpawnRange = 7;
                    break;

                case int n when (n >= 30 && n < 40):
                    Main.itemsSpawnRange = 9;
                    break;

                case int n when (n >= 40 && n < 50):
                    Main.itemsSpawnRange = 11;
                    break;

                case int n when (n >= 50 && n < 60):
                    Main.itemsSpawnRange = 13;
                    break;

                case int n when (n >= 60 && n < 70):
                    Main.itemsSpawnRange = 15;
                    break;

                case int n when (n >= 70 && n < 80):
                    Main.itemsSpawnRange = 15;
                    break;

                case int n when (n >= 80):
                    Main.itemsSpawnRange = 19;
                    break;

                default:
                    Main.itemsSpawnRange = 3;
                    break;

            }

            
        }
        else
        {
            //Destroy(collision);
            //DestroyImmediate(collision);

            //GameObject.Destroy(collision.gameObject);

            //Time.timeScale = 0;
            //Application.LoadLevel(Application.loadedLevel);
            //SceneManager.LoadScene("SampleScene");
            //_main.BlinkGameObject(collision.gameObject, 5, 0.4f);

            //audioSrc.PlayOneShot(loseSound, 0.25f);
            AudioManager.Instance.Play(loseSound);
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Main.isGameOver = true;
            score.scoreText.text = "GAME OVER";
            StartCoroutine(main.BlinkGameObject(collision.gameObject, 3, 0.4f, true));
           
        }

    }
}