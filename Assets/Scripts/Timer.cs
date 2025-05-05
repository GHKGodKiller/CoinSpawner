using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    float countdown = 60;
    public TMP_Text tex;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown > 0)
        {
            countdown-=Time.deltaTime;
        }
        double b = System.Math.Round(countdown, 2);
        tex.text=b.ToString();
    }
}
