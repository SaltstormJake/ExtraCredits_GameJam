﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingToolsScript : MonoBehaviour
{
    [SerializeField] KeyCode increaseHealthbar = KeyCode.None;
    [SerializeField] KeyCode decreaseHealthbar = KeyCode.None;
    [SerializeField] KeyCode speedUpTime = KeyCode.None;
    [SerializeField] KeyCode showAlert = KeyCode.None;
    [SerializeField] KeyCode strike1 = KeyCode.None;
    [SerializeField] KeyCode strike2 = KeyCode.None;
    [SerializeField] KeyCode strike3 = KeyCode.None;
    [SerializeField] KeyCode strike4 = KeyCode.None;
    [SerializeField] KeyCode strike5 = KeyCode.None;
    [SerializeField] KeyCode showText = KeyCode.None;
    [SerializeField] string textToUse = null;
    [SerializeField] float timeMultiplier = 1;
    [SerializeField] uiMasterScript ui = null;
    [SerializeField] textBoxScript textBox = null;
    [SerializeField] toDoListScript listScript = null;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(increaseHealthbar))
            ui.DamageKing(-0.1f);
        if(Input.GetKeyDown(decreaseHealthbar))
            ui.DamageKing(0.1f);
        if(Input.GetKeyDown(speedUpTime))
            if(Time.timeScale == 1)
                Time.timeScale = timeMultiplier;
            else
                Time.timeScale = 1;
        if(Input.GetKeyDown(showAlert))
            StartCoroutine(ui.ShowAlertText());
        if(Input.GetKeyDown(showText))
            StartCoroutine(textBox.SetText(textToUse, 2.0f));
        if(Input.GetKeyDown(strike1))
            listScript.CrossOut(toDoListScript.ToDoTasks.SUPERMARKET);
        if(Input.GetKeyDown(strike2))
            listScript.CrossOut(toDoListScript.ToDoTasks.BLACKSMITH);
        if(Input.GetKeyDown(strike3))
            listScript.CrossOut(toDoListScript.ToDoTasks.CHURCH);
        if(Input.GetKeyDown(strike4))
            listScript.CrossOut(toDoListScript.ToDoTasks.TAXCOLLECTION);
        if(Input.GetKeyDown(strike5))
            listScript.CrossOut(toDoListScript.ToDoTasks.ATTENDEXECUTION);
    }
}
