using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int startTime = 403;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime > 0)
        {
            int second = (int)Mathf.Floor(Time.realtimeSinceStartup);
            int currentTime = startTime - second;
            timerText.text = $"Time: {currentTime}";
        }
    }
}
