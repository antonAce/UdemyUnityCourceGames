//#define BINARYSEARCH
#define RANDOMSEARCH

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizardBehaviour : MonoBehaviour
{
    public int MinimumValue, MaximumValue, GuessValue, TriesAllowed, RandomNumber;
    public Text CurrentNumberText;
    public Text GreetingText;

    void Awake () {
        StartGame();
    }

    public void HigherGuess()
    {
        MinimumValue = GuessValue;
        NextGuess();
    }

    public void LowerGuess()
    {
        MaximumValue = GuessValue;
        NextGuess();
    }

    void StartGame()
    {
        MaximumValue = MainMenuManager.DefaultMaximumValue;
        MinimumValue = MainMenuManager.DefaultMinimumValue;
        GuessValue = (MaximumValue + MinimumValue) / 2;
        TriesAllowed = MainMenuManager.DefaultTriesAllowed;
        Debug.Log(MinimumValue + " " + MaximumValue + " "+ TriesAllowed);
        GreetingText.text = "So, let's start!";
        CurrentNumberText.text = GuessValue.ToString();
    }

    void NextGuess()
    {
#if BINARYSEARCH
        GuessValue = (MaximumValue + MinimumValue) / 2;
#endif
#if RANDOMSEARCH
        RandomNumber = GuessValue;
        while (RandomNumber == GuessValue) // Number repeating protection
        {
            if (MinimumValue != MaximumValue) // If player reached limits
                RandomNumber = Random.Range(MinimumValue, MaximumValue + 1);
            else
            {
                GreetingText.text = "Hey, stop cheating!";
                return;
            }
        }
        GuessValue = RandomNumber;
#endif
        CurrentNumberText.text = GuessValue.ToString();
        TriesAllowed--;
        GreetingText.text = "Ok, now I have only " + TriesAllowed + " tries";
        if (TriesAllowed <= 0)
            LevelManager.Instance.LoadLevel("Win");
    }
}
