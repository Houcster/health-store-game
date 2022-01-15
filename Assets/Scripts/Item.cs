using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Main main;
    public Vector2 speed = new Vector2(0, 0);
    private Rigidbody2D body;

    private void Start()
    {
        main = FindObjectOfType<Main>();
        body = GetComponent<Rigidbody2D>();
    }

    private void VariableChangeHandler(float newVal)
    {
        //SetMovement();
    }

    private void SetMovement()
    {
        Vector3 movement = new Vector2(speed.x * Main.movementSpeed, speed.y * Main.movementSpeed);
        movement *= Time.deltaTime;

        transform.Translate(movement);
        //Debug.Log("Movement speed: " + _main.MovementSpeed);
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    private void Update()
    {
        if (body.bodyType == RigidbodyType2D.Kinematic && !Main.isGameOver)
        {
            SetMovement();
        }
    }

    private IEnumerator Blink()
    {
        SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();

        Color defaultColor = playerSprite.color;

        playerSprite.color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(0.05f);

        playerSprite.color = defaultColor;
    }

    public void Blinking()
    {
        StartCoroutine(Blink());
    }

}
