using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{   
    [HideInInspector]
    public float time = 100f;
    [HideInInspector]
    public bool timerRunning;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI failText;
    public TextMeshProUGUI successText;
    // Start is called before the first frame update
    void Start()
    {
        timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerRunning){
            if(time >= 0){
                timerText.text = $"Time: {Mathf.Floor(time)}";
                time -= Time.deltaTime;
            } else {
                if(successText.enabled == false){
                    failText.enabled = true;
                    timerRunning = false;
                }
            }
            
        }
    }
}
