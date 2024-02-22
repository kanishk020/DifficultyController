using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerSpawn;
    public GameObject character;
    public bool isDead;

    public AudioSource bgMusic;


    public GameObject escPanel;


    public static GameManager instance;
    void Start()
    {
        instance = this;
        isDead = false;
    }

    
    void Update()
    {
        if(isDead && TimeUI.instance.timerstart == true)

        {
            Instantiate(character,playerSpawn.transform.position,Quaternion.identity,this.transform);


            isDead = false;
        }
        
        
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (escPanel.activeSelf)
            {
                OnPressResume();
            }
            else
            {
                OnPressEsc();
            }
        }
    }



    public void OnPressEsc()
    {
        Time.timeScale = 0f;

        escPanel.SetActive(true);
    }


    public void OnPressResume()
    {
        Time.timeScale = 1f;

        escPanel.SetActive(false);
    }
}
