using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{

    public int difficulty;

    

    public GameObject enemyPrefab;
    public GameObject enemyContainer;
    public int noOfSpawns;


    private int spawnCount;

    private int index;

    [Header("Calculating Attributes")]
    public float damageGiven;
    public float damageTaken;
    
    public List<int> diffLimits;
    public float difficlutymean;
    public int TimerSeconds;

    public static int deathCount;
    public int DeathCount;
    public int deathLimit;
    public static DifficultyController instance;

    public List<Transform> spawnPoints;

    public List<Vector2> spawnPositions;

    int spawnIndex;
    float time;


    float SpawnpointDistanceX;
    float SpawnpointDistanceY;

    public bool spawnTrigger;

    void Start()
    {
        spawnTrigger = false;
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance );
        }

        spawnIndex = 0;

        difficulty = PlayerPrefs.GetInt("Difficulty", 1);



    }

    private void Update()
    {
        
        DeathCount = deathCount;
        difficlutymean = (damageGiven + damageTaken )/2;

       
        time += Time.deltaTime;


        if (enemyContainer.transform.childCount == 0  && spawnTrigger == true)
        {
            spawnCount = difficulty * noOfSpawns;
            
            StartCoroutine(SpawnEnemy());

            spawnTrigger = false;
        }

        if (time >= TimerSeconds)
        {
            DifficultySetter();
            damageGiven = 0;
            damageTaken = 0;
            spawnTrigger = true;
            time = 0;
        }

        
        
    }


    public void SpawnFilter()
    {

        spawnPositions.Clear();
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            
            SpawnpointDistanceX = Mathf.Abs(spawnPoints[i].position.x - this.transform.position.x); //11
            SpawnpointDistanceY = Mathf.Abs(spawnPoints[i].position.y - this.transform.position.y);

            if(SpawnpointDistanceX > 11f && SpawnpointDistanceY > 7f)
            {
                spawnPositions.Add(spawnPoints[i].position);
            }
        }


    }




    IEnumerator SpawnEnemy()
    {
        SpawnFilter();
        
        
        for(int i = 0;i<spawnCount;i++)
        {
            if (spawnIndex < spawnPositions.Count)
            {
                yield return new WaitForSeconds(5f);
                GameObject en = Instantiate(enemyPrefab, enemyContainer.transform);
                en.transform.position = spawnPositions[index];
                spawnIndex++;


            }
            else
            {
                spawnIndex = 0;
            }
            
        }

        
        
    }
   
    public void DifficultySetter()
    {
        index = difficulty - 1;

        

        if(difficlutymean > diffLimits[index] && difficulty <10 )
        {
            difficulty++;
            PlayerPrefs.SetInt("Difficulty", difficulty);
            index++;
        }
        

        if(deathCount > deathLimit && difficulty > 1)
        {
            difficulty--;
            PlayerPrefs.SetInt("Difficulty", difficulty);
            deathCount = 0;
        }
    }

    
}
