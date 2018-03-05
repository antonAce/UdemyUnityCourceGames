using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public GameObject Paddle;
    public GameObject MenuCanvas;

    private bool _ballIsLaunched;
    private const float BallStartYPos = -6.5f, BallStartSpeed = 4.5f, SpeedCoef = 1.05f, ZeroLoopOffset = 0.6f;
    private int _rotationCoef = 2;
    private float XStartSpeed;

    public GameObject BlockKeeper, FireArrow;
    public List<GameObject> LevelBlocks;

    void OnCollisionExit2D(Collision2D collision)
    {
        if (LevelManager.Instance.CurrentLevel() != "VsStage")
            CheckBlockAmmount();
        if (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.y) < 10 && Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.x) < 10)
            gameObject.GetComponent<Rigidbody2D>().velocity *= SpeedCoef;
    }

    void Awake ()
    {
        if (LevelManager.Instance.CurrentLevel() != "VsStage")
            CheckBlockAmmount();
        _ballIsLaunched = false;
        MenuCanvas = GameObject.FindGameObjectWithTag("ControlMenu");
        MenuCanvas.SetActive(false);
        Paddle = GameObject.FindGameObjectWithTag("Paddle");
	    gameObject.transform.position = new Vector2(Paddle.transform.position.x, BallStartYPos);
        FireArrow = GameObject.FindGameObjectWithTag("FireArrow");
        FireArrow.transform.eulerAngles = new Vector3(0, 0, 270);
    }
	
	void Update ()
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

	        if (FireArrow.transform.eulerAngles.z < 90 || FireArrow.transform.eulerAngles.z > 270)
	            _rotationCoef = -_rotationCoef;
            FireArrow.transform.eulerAngles += new Vector3(0, 0, _rotationCoef);
	        XStartSpeed = BallStartSpeed * FireArrow.transform.rotation.w;

            Debug.Log(XStartSpeed);

            if (Input.GetMouseButtonDown(0))
	        {
	            _ballIsLaunched = true;
	            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XStartSpeed, BallStartSpeed);
	            Destroy(FireArrow);
            }
        }
    }

    void CheckBlockAmmount()
    {
        LevelBlocks.Clear();

        BlockKeeper = GameObject.FindGameObjectWithTag("BlockKeeper");

        if (BlockKeeper.transform.childCount <= 0)
        {
            gameObject.SetActive(false);
            MenuCanvas.SetActive(true);
        }
    }
}
