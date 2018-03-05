using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollision : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Puck" || collider.tag == "EnemyPuck")
        {
            LevelManager.Instance.LoadLevel("Win");
        }
    }
}
