using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallBehaviuor : MonoBehaviour {

    public GameObject Paddle;

    private bool _ballIsLaunched;
    private const float BallStartYPos = 6.5f, BallStartSpeed = -4.5f, SpeedCoef = 1.05f, ZeroLoopOffset = 0.6f;


    public GameObject BlockKeeper;
    public List<GameObject> LevelBlocks;

    void OnCollisionExit2D(Collision2D collision)
    {
        if (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y) < 10 && Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x) < 10)
            gameObject.GetComponent<Rigidbody2D>().velocity *= SpeedCoef;
    }

    void Awake()
    {
        _ballIsLaunched = false;
        Paddle = GameObject.FindGameObjectWithTag("EnemyPaddle");
        gameObject.transform.position = new Vector2(Paddle.transform.position.x, BallStartYPos);
    }

    void Update()
    {
        if (_ballIsLaunched)
        {
            if (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x) < 0.4f) // Line to aviod "boring loops" at X
            {
                Debug.Log("Changed X!");
                gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(Random.Range(-ZeroLoopOffset, ZeroLoopOffset), 0);
            }
            if (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y) < 0.4f) // Line to aviod "boring loops" at Y
            {
                Debug.Log("Changed Y!");
                gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(0, Random.Range(-ZeroLoopOffset, ZeroLoopOffset));
            }

        }
        else
        {
            gameObject.transform.position = new Vector2(Paddle.transform.position.x, BallStartYPos);
            _ballIsLaunched = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-BallStartSpeed + 0.5f, BallStartSpeed - 0.5f), BallStartSpeed);
        }
    }
}
