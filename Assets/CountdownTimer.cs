using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] float seconds;
    float secondsLeft;

    bool timerRunning = false;

    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        secondsLeft = seconds;
        DisplayTimeFormatted(secondsLeft);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            if (secondsLeft > 0)
            {
                secondsLeft -= Time.deltaTime;
                DisplayTimeFormatted(secondsLeft);
            }
            else
            {
                timerRunning = false;
                FinishAction();
            }
        }
    }

    void DisplayTimeFormatted(float seconds)
    {
        seconds += .99f; // Looks better with whole seconds
        float min = Mathf.FloorToInt(seconds / 60);
        float sec = Mathf.FloorToInt(seconds % 60);
        countdownText.text = string.Format("{0:0}:{1:00}", min, sec);
    }

    void FinishAction()
    {
        Debug.Log("Time is over!");
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public void PauseTimer()
    {
        timerRunning = false;
    }

    public void ResetTimer()
    {
        timerRunning = false;
        secondsLeft = seconds;
        DisplayTimeFormatted(secondsLeft);
    }
}
