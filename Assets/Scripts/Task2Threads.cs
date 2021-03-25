using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Task2Threads : MonoBehaviour
{
    
    public List<string> stringList = new List<string>();
    private int currentThreadNum;
    private List<Thread> Threadlist = new List<Thread>();

    void Start()
    {
        currentThreadNum = 0;
        for (int i = 0; i < 10; i++)
        {
            Thread t = new Thread(new ThreadStart(ThreadFunc));
            
            
            t.Start();
            Threadlist.Add(t);
        }
    }

    private void ThreadFunc()
    {

        int index = currentThreadNum++;
        int tick = 0;
        int iteration = 0;
        stringList.Add("Thread#" + currentThreadNum.ToString());
        while (true)
        {
            if (++tick == 1000)
            {
                iteration++; tick = 0;
            }
            stringList[index] = "Thread#" + index + " Tick #(" + iteration + ")";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        List<string> guiStringList = stringList;
        GUIStyle style = new GUIStyle();
        style.fontSize = 20;
        style.normal.textColor = Color.black;
        GUILayout.Label("Threads:",style);
        for (int i = 0; i < stringList.Count; i++)
        {
            GUILayout.Label(stringList[i], style);
        }
        if (GUILayout.Button("StopThreads"))
            foreach (Thread t in Threadlist)
                t.Abort();

    }
}
