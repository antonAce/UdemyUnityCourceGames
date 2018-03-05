using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddleBehaviour : MonoBehaviour {
    
    private float _screenTransformToPoints;
    private const int PaddleDefaultX = 0, PaddleDefaultY = 7;
    private const float UnitBorderL = -8.4f, UnitBorderR = 8.4f;
    
    [Range(100f, 1000f)]
    public static float SpeedCoef = 10f; // 5f - easy, 10f - medium, 20f - hard
    public bool AutoPlay = false;
    public GameObject Ball, PlayerBall;

    void Start()
    {
        gameObject.transform.position = new Vector2(PaddleDefaultX, PaddleDefaultY);
        Ball = GameObject.FindGameObjectWithTag("EnemyPuck");
        PlayerBall = GameObject.FindGameObjectWithTag("Puck");
    }

    void Update()
    {
        if (PlayerBall.transform.position.y > Ball.transform.position.y)
            _screenTransformToPoints = Mathf.Lerp(gameObject.transform.position.x, PlayerBall.gameObject.transform.position.x, Time.deltaTime * SpeedCoef);
        else
            _screenTransformToPoints = Mathf.Lerp(gameObject.transform.position.x, Ball.gameObject.transform.position.x, Time.deltaTime * SpeedCoef);
        
        Debug.Log(Time.deltaTime);

        gameObject.transform.position = new Vector2(Mathf.Clamp(_screenTransformToPoints, UnitBorderL, UnitBorderR), gameObject.transform.position.y);
    }
}
