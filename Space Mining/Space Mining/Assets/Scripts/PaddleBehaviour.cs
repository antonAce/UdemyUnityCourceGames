using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour
{
    private float _screenTransformToPoints;
    private const int ScreenUnits = 20, PaddleDefaultX = 0, PaddleDefaultY = -7;
    private const float UnitBorderL = -8.4f, UnitBorderR = 8.4f;

    public bool AutoPlay = false;
    public GameObject Ball;

    void Start()
    {
        gameObject.transform.position = new Vector2(PaddleDefaultX, PaddleDefaultY);
        Ball = GameObject.FindGameObjectWithTag("Puck");
    }
	
	void Update()
	{
	    if (!AutoPlay)
	    {
	        _screenTransformToPoints = (Input.mousePosition.x / Screen.width * ScreenUnits) - (ScreenUnits / 2);
	        gameObject.transform.position = new Vector2(Mathf.Clamp(_screenTransformToPoints, UnitBorderL, UnitBorderR),
	            gameObject.transform.position.y);
	    }
	    else
	    {
	        _screenTransformToPoints = Ball.gameObject.transform.position.x;
	        gameObject.transform.position = new Vector2(Mathf.Clamp(_screenTransformToPoints, UnitBorderL, UnitBorderR),
	            gameObject.transform.position.y);
        }
	}
}
