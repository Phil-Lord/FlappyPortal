using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool gameActive = true;

    void Update()
    {
        // Jump when space is pressed
        if (gameActive && Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 6.5f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameActive = false;
        //Debug.Log("Game over!");
    }
}
