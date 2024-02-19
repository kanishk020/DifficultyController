using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Timeline;

public class TimeUI : MonoBehaviour
{
   public TextMeshProUGUI text;

    public bool isGameOver;

    public float currentLevelTime;

    

    public static TimeUI instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance );
        }


        
        isGameOver = true;
        text = text.GetComponent<TextMeshProUGUI>();

       


    }

    
    void Update()
    {
        
        int minutes = Mathf.FloorToInt((currentLevelTime % 3600f) / 60f);
        int seconds = Mathf.FloorToInt(currentLevelTime % 60f);
        text.text = $" ={minutes:D2}:{seconds:D2}";



        if (!isGameOver)
        {
            currentLevelTime -= Time.deltaTime;
            
            

        }
    }
}
