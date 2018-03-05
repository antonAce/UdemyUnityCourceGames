using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag != "Diamond")
        {
            LevelManager.Instance.LoadLevel("Lose");
            Debug.Log("You hit me!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        LevelManager.Instance.LoadLevel("Lose");
        Debug.Log("You collide me!");
    }
}
