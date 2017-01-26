using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{

    //Display on UI variables
    public Text displayRound;

    //Spawning Vars
    public float currentEnemyCount = 0f;
    public float spawnRate = 3f;
    private float spawnTimePassed;
    public float decreaseRate = 0.0001f;

    public int currentRound = 0;
    public int roundIncrease = 15;
    public int roundIncrement = 5;


    public GameObject setPath;

    //Locations
    [Tooltip("Sets the starting point for the enemies when spawned")]

    public Transform wayPoints;

    //Other 
    public PlayerData playerData;

    //For Struct
    [Header("Enemies")]
    public EnemyClass[] chosenEnemy;

    // Use this for initialization
    void Start()
    {

    }

    [System.Serializable]
    public struct EnemyClass
    {
        //Basic Enemy Stucture
        public string EnemyName;
        public GameObject EnemyObject;
        public int health;
        public int maxHealth;
        public int damage;
        public int waveSpace;

        public float moveSpeed;

        //Spawner
        [HideInInspector]
        [Tooltip("Amount of enemies spawned from spawner enemy")]
        public int babySpawnAmount;
        public void applyData(GameObject self)
        {
            self.GetComponent<EnemyDataTypes>().EnemyName = EnemyName;
            self.GetComponent<EnemyDataTypes>().health = health;
            self.GetComponent<EnemyDataTypes>().maxHealth = maxHealth;
            self.GetComponent<EnemyDataTypes>().damage = damage;
            self.GetComponent<EnemyDataTypes>().waveSpace = waveSpace;
            self.GetComponent<EnemyDataTypes>().moveSpeed = moveSpeed;
            self.GetComponent<EnemyDataTypes>().babySpawnAmount = babySpawnAmount;
        }
    };

    // Update is called once per frame
    void Update()
    {
        displayRound.text = "Round : " + currentRound;
        {
            spawnTimePassed += Time.deltaTime;
            if (spawnTimePassed >= spawnRate)
            {
                Debug.Log("Has been reset");
                int rand = Random.Range(0, 3);
                GameObject buildEnemy = (GameObject)Instantiate(chosenEnemy[rand].EnemyObject, transform.position, transform.rotation);
                buildEnemy.GetComponent<EnemyAI>().playerData = playerData;
                buildEnemy.GetComponent<EnemyAI>().GenerateWayPoints(setPath);
                chosenEnemy[rand].applyData(buildEnemy);
                currentEnemyCount++;
                spawnTimePassed = 0;
            }
            if (currentEnemyCount > roundIncrease)
            {
                currentRound++;
                currentEnemyCount = 0;
                if (currentRound % roundIncrement == 0)
                {
                    if (spawnRate - decreaseRate > 0.5f)
                    {
                        spawnRate -= decreaseRate;
                    }
                }
            }

        }
    }
}

