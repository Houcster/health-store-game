using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public static float movementSpeed = 4.0f;
    public static bool isGameOver = false;
    public static int highScore;
    public static int itemsSpawnRange = 3;
    public static int scoreValue = 0;
    public GameObject trashBasket;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        print("HighScore: " +highScore);
    }

    public void activateTrashBasket(bool withBlink)
    {
        if (!trashBasket.activeSelf)
        {
            trashBasket.SetActive(true);
            if (withBlink)
            {
                GameObject ChildGameObject1 = trashBasket.transform.GetChild(0).gameObject;
                GameObject ChildGameObject2 = trashBasket.transform.GetChild(1).gameObject;
                StartCoroutine(BlinkGameObject(ChildGameObject1, 4, 0.4f, false));
                StartCoroutine(BlinkGameObject(ChildGameObject2, 4, 0.4f, false));
            }          
        }
    }

    public IEnumerator BlinkGameObject(GameObject gameObject, int numBlinks, float seconds, bool isGameOver)
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();

        for (int i = 0; i < numBlinks * 2; i++)
        {
            renderer.enabled = !renderer.enabled;
            yield return new WaitForSeconds(seconds);
        }
        renderer.enabled = true;

        if (isGameOver)
        {
            FindObjectOfType<SceneLoader>().GameOver();
        }
    }
}