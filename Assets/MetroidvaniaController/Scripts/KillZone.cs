using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && TimeUI.instance.timerstart == true)
        {
            GameManager.instance.isDead = true;
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "Player" && TimeUI.instance.timerstart == false)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        
        else
        {
            Destroy(col.gameObject);
        }
    }
}
