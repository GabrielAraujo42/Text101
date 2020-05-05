using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Note:
 * To rename everything with the same name at once use Ctrl + R + R
 */
public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text storyText;
    [SerializeField] State startingState;

    // Current State
    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        storyText.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageStates();
        QuitGame();
    }

    private void ManageStates()
    {
        // Get next possible states
        State[] nextStates = state.GetNextStates();

        // Iterates through next possible states
        for (int index = 0; index < nextStates.Length; index++)
        {
            // If that allows Input only for possible states
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                state = nextStates[index];
            }
        }
        // Updates text to current state
        storyText.text = state.GetStateStory();
    }

    void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}
