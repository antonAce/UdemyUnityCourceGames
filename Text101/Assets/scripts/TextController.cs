using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text MainText;

    private enum States
    {
        splash_screen,
        cell,
        mirror,
        sheets_0,
        lock_0,
        sheets_1,
        lock_1,
        freedom,
        corridor_0
    };
    private States _currentState;

    void Start ()
    {
        _currentState = States.splash_screen;
    }
	
	void Update ()
	{
	    switch (_currentState)
	    {
	        case States.splash_screen:
	        {
	            SplashScreen();
                break;
	        }
	        case States.cell:
	        {
	            InCell();
                break;
	        }
	        case States.mirror:
	        {
	            ViewMirror();
	            break;
	        }
	        case States.sheets_0:
	        {
	            ViewSheets0();
                break;
	        }
	        case States.lock_0:
	        {
	            ViewLock0();
                break;
	        }
	        case States.sheets_1:
	        {
	            ViewSheets1();
                break;
	        }
	        case States.lock_1:
	        {
	            ViewLock1();
                break;
	        }
	        case States.freedom:
	        {
	            Freedom();
	            break;
	        }
	        case States.corridor_0:
	        {
	            ToCorridor0();
	            break;
	        }
	    }
        //Debug.Log(_currentState);
    }

    void SplashScreen()
    {
        MainText.text = "You got in a prison for robbing a bank. Next 50 years you'll spend i prison cell, unless you decide to escape! \n\n" +
                        "Press SPACE to begin escape!";
        if (Input.GetKeyDown(KeyCode.Space))
            _currentState = States.cell;
    }

    void InCell()
    {
        MainText.text = "You're in a prison cell, and you want to escape. There are some dirty sheets on the bed, " +
                        "a mirror on the wall, and the door is locked outside... \n\n" +
                        "Press S to view sheets, press M to view mirror, press L to view lock";
        if (Input.GetKeyDown(KeyCode.S))
            _currentState = States.sheets_0;
        else if (Input.GetKeyDown(KeyCode.M))
            _currentState = States.mirror;
        else if (Input.GetKeyDown(KeyCode.L))
            _currentState = States.lock_0;
    }

    void ViewSheets0()
    {
        MainText.text = "You can't believe you slept on it all time. Atleast you tried to do it, " +
                        "cuz it's hard to dream in this closed dirty box. You definitely yearn for leaving this place \n\n" +
                        "Press R to return";
        if (Input.GetKeyDown(KeyCode.R))
            _currentState = States.cell;
    }

    void ViewMirror()
    {
        MainText.text = "Your unshaved face seemed to you a bit disgusting, it's been like eternity, since you shaved last time. " +
                        "Thoughts, that one day you'll escape this prison is filling you with determination. \n\n" +
                        "Press R to return";
        if (Input.GetKeyDown(KeyCode.R))
            _currentState = States.cell;
    }

    void ViewLock0()
    {
        MainText.text = "You remembered, that your pal sent you a friendly package with tool, that will help you to escape:" +
                        "her wife's hairpin. This is your last chance to escape. After you considered that all guard has gone, " + 
                        "you tried to unlock door with hairpin, and you did it. Now you're comming to control room \n\n" +
                        "Press ENTER to enter control room";
        if (Input.GetKeyDown(KeyCode.Return))
            _currentState = States.sheets_1;
    }

    void ViewSheets1()
    {
        MainText.text = "Jeez, there's lots of buttons! " +
                        "Suddenly you see red button 'ALARM!' \n\n" +
                        "Press O to press red button";
        if (Input.GetKeyDown(KeyCode.O))
            _currentState = States.lock_1;
    }

    void ViewLock1()
    {
        MainText.text = "All guard now seeking. It's your chance to get keys from main guardian room and escape. " +
                        "When you get to it you see keys - your freedom ticket \n\n" +
                        "Press T to take";
        if (Input.GetKeyDown(KeyCode.T))
            _currentState = States.freedom;
    }

    void Freedom()
    {
        MainText.text = "After all nightmares you went through, you're finally free! \n\n" +
                        "Press S to start from the beginning.";
        if (Input.GetKeyDown(KeyCode.S))
            _currentState = States.splash_screen;
    }

    void ToCorridor0()
    {
    }
}
