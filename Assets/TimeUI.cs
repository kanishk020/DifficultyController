using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
   public TextMeshProUGUI text;

    public bool timerstart;

    public float currentLevelTime;

    public GameObject ResultCanvas;

    

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


        
        timerstart = false;
        
        ResultCanvas.SetActive( false);
    }

    
    void Update()
    {
        
        int minutes = Mathf.FloorToInt((currentLevelTime % 3600f) / 60f);
        int seconds = Mathf.FloorToInt(currentLevelTime % 60f);

        
            text.text = $" ={minutes:D2}:{seconds:D2}";
       
        



        if (timerstart && currentLevelTime >0f)
        {
            currentLevelTime -= Time.deltaTime;
            
        }
        else if(timerstart && currentLevelTime < 0f)
        {
            timerstart = false;
            ResultCanvas.SetActive(true);
        }
 
    }
}
