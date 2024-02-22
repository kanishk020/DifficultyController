using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryGate : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    private void Start()
    {
         spriteRenderer= GetComponent<SpriteRenderer>();
        spriteRenderer.enabled= false;
        audioSource = GameManager.instance.bgMusic;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spriteRenderer.enabled = true;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            TimeUI.instance.timerstart = true;
            DifficultyController.instance.spawnTrigger = true;

            if(audioSource!= null)
            {
                audioSource.Play();
            }
            

        }
    }
    
}
