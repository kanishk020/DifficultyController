using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{

    public int difficulty;

    public int maxdifficulty;

    public GameObject enemyPrefab;
    public GameObject spawnPos;
    public int spawnCount;

    private int index;

    [Header("Calculating Attributes")]
    public float damageGiven;
    public float damageTaken;
    
    public List<int> diffLimits;
    public float difficlutymean;
    public int TimerSeconds;
    public static DifficultyController instance;

    float time;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance );
        }


        difficulty = PlayerPrefs.GetInt("Difficulty", 1);

    }

    private void Update()
    {
        difficlutymean = (damageGiven + damageTaken )/2;

       
        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.U))
        {
            SpawnEnemy();
        }

        if (time >= TimerSeconds)
        {
            DifficultySetter();
            damageGiven = 0;
            damageTaken = 0;

            time = 0;
        }
        
    }

    public void SpawnEnemy()
    {
        for(int i = 0;i< spawnCount; i++)
        {
            GameObject en = Instantiate(enemyPrefab,spawnPos.transform);
            en.transform.position = spawnPos.transform.position;
        }
    }
   
    public void DifficultySetter()
    {
        index = difficulty - 1;

        if(difficlutymean > diffLimits[index] && difficulty <10 )
        {
            difficulty = difficulty + 1;
            PlayerPrefs.SetInt("Difficulty", difficulty);

            index++;
        }
        else
        {
            difficulty = 10;
        }
    }

    
}
