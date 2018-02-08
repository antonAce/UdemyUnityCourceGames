using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandlerTest : MonoBehaviour {
    // Class with test functions of key-handler in Unity.
    // Warning! Doesn't included in unit-testing.

	void Start () {}

    void Update()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                Debug.Log(kcode + " is pressed!");
            }

        }
    }
}
