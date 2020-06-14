using UnityEngine;
using UnityEngine.UI;
using System;

public class TopBar : MonoBehaviour
{
    public Text Timer;
    public Text Wave;

    private float timeInSecondsP = 0;
    private bool stop = false;

    private int wave = 1;

    private void Start()
    {
        Timer.text = "Time: 00.00";
        Wave.text = "Wave: 1";
    }

    private void Update()
    {
        if (!stop)
        {
            string time = "Time: ";

            timeInSecondsP += Time.deltaTime;

            int seconds = (int)(timeInSecondsP % 60);
            int minutes = (int)(timeInSecondsP / 60);

            if (minutes < 10)
                time += "0" + minutes;
            else time += minutes;

            time += '.';

            if (seconds < 10)
                time += "0" + seconds;
            else time += seconds;

            Timer.text = time;
        }
    }

    public void stopTime()
    {
        stop = true;
    }

    public void nextWave()
    {
        Wave.text = "Wave: " + ++wave;
    }
}


