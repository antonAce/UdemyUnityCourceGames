using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public InputField MinValue;
    public InputField MaxValue;
    public InputField TriesValue;

    public static int DefaultMinimumValue = 1, DefaultMaximumValue = 1000, DefaultTriesAllowed = 5;

    void Awake()
    {
        DefaultMinimumValue = 1;
        DefaultMaximumValue = 1000;
        DefaultTriesAllowed = 5;
    }

    public void SetMinimumValue()
    {
        DefaultMinimumValue = Convert.ToInt32(MinValue.text);
        Debug.Log(DefaultMinimumValue);
    }

    public void SetMaximumValue()
    {
        DefaultMaximumValue = Convert.ToInt32(MaxValue.text);
        Debug.Log(DefaultMaximumValue);
    }

    public void SetTriesValue()
    {
        DefaultTriesAllowed = Convert.ToInt32(TriesValue.text);
        Debug.Log(DefaultTriesAllowed);
    }
}
