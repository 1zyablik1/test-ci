using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public UnityEngine.UI.Text timerText;
    public float time = 0.0f;
    
    void Update()
    {
        time += Time.deltaTime;
        timerText.text = time.ToString("F2");
    }
}
