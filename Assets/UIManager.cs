using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider musicVolume;
    public Slider sfxVolume;

    public AudioSource musicSource;

    public Slider Health;

    public int MaxHealth = 100;
    private void Update()
    {
        GameObject player =  GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            AudioSource sfx = player.GetComponent<AudioSource>();
            CharacterController2D character = player.GetComponent<CharacterController2D>();

            Health.value = Mathf.Clamp01(character.life / MaxHealth);
            sfx.volume = sfxVolume.value;
            
        }

        musicSource.volume = musicVolume.value;

    }




    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
