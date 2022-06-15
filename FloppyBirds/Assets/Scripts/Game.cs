using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public void RestartGame()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("GAME OVER");
    }
}
