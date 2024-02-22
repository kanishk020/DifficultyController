using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerSpawn;
    public GameObject character;
    public bool isDead;


    public GameObject escPanel;


    public static GameManager instance;
    void Start()
    {
        instance = this;
        isDead = false;
    }

    
    void Update()
    {
        if(isDead && TimeUI.instance.isGameOver == false)

        {
            Instantiate(character,playerSpawn.transform.position,Quaternion.identity,this.transform);


            isDead = false;
        }
        else if( isDead && TimeUI.instance.isGameOver == true)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
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
