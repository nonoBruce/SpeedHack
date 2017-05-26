﻿using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;

public class SpeedHackDetector1 : MonoBehaviour {
	
	private const int THRESHOLD = 20000;//50ms---50毫秒
    private long ticksOnStart = 0;
    private long ticksOnStartVulnerable = 0;
    private int errorsCount = 0;
    private const int maxFalsePositives = 1;
    //private bool SpeedHackFlag = true;
    private int frameCount=0;
    private bool Dflag = false;
    private long ticks;
    private long ticksVulnerable;
    private long Result;
	// Use this for initialization
	void Start () {
        errorsCount = 0;
        ticksOnStart = DateTime.UtcNow.Ticks;
        ticksOnStartVulnerable = Environment.TickCount * TimeSpan.TicksPerMillisecond;
        frameCount = 0;
        Dflag = false;
        Result = 0;
        //SpeedHackFlag = true;

	}
	
	// Update is called once per frame
	void Update () {
        frameCount += 1;
        if (frameCount >=60)
        {
            OnTimer();
            frameCount = 0;
        }
	}

    private void OnTimer()
    {
        ticks = DateTime.UtcNow.Ticks;
        ticksVulnerable = Environment.TickCount * TimeSpan.TicksPerMillisecond;
        Result=Math.Abs((ticksVulnerable - ticksOnStartVulnerable) - (ticks - ticksOnStart));
//		Debug.Log(ticksVulnerable - ticksOnStartVulnerable);
//		Debug.Log(ticks - ticksOnStart);
//		Debug.Log(Result);
//		Debug.Log("--------------------------------------------------------\n\n");
        if (Result > THRESHOLD)
        {
            errorsCount++;
            if (errorsCount > maxFalsePositives)
            {
                Detected();
            }
            //errorsCount = 0;
        }
        ticksOnStart = DateTime.UtcNow.Ticks;
        ticksOnStartVulnerable = Environment.TickCount * TimeSpan.TicksPerMillisecond;
    }

    private void Detected()
    {
//        Debug.Log("Sry Baby,bad things happened!");
        Dflag = true;
    }

    void OnGUI()
    {
        
		Debug.Log ("sdfasdfasdf");
        GUI.TextField(new Rect(Screen.width / 2 , Screen.height / 2 - 50, 200, 30), ticksOnStart.ToString());
        GUI.TextField(new Rect(Screen.width / 2, Screen.height / 2, 200, 30), ticksOnStartVulnerable.ToString());
        GUI.TextField(new Rect(Screen.width / 2 , Screen.height / 2 + 50, 200, 30), Result.ToString());
        if(Dflag==true)
        {
            GUI.TextField(new Rect(Screen.width / 2 , Screen.height /  +100, 200, 30), "Hacked");
			Dflag = false;//测试使用，正式的使用直接quit就好了

			Application.Quit ();
		}else{
			GUI.TextField(new Rect(Screen.width / 2 , Screen.height /  +100, 200, 30), "0");
		}
    }
}
