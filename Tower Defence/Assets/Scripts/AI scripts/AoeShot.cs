using UnityEngine;
using System.Collections;

public class AoeShot : MonoBehaviour
{
    //Scripts that need to be accesed
    public TowerTypes towerTypeData;



    //Shooting Variables
    private float fireRate = 3f;
    private float cooldownTimer = 0;

    public GameObject aoeBulletPrefab;
    public Transform[] aoeBulletSpawnSpots;

    // Use this for initialization
    void Start()
    {
        cooldownTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Aoe tower shooting      
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            Debug.Log("Aoe tower shoots");
            cooldownTimer = fireRate;
            for (int x = 0; x < aoeBulletSpawnSpots.Length; x++)
            {
                int randomPos = Random.Range(0, aoeBulletSpawnSpots.Length);
                GameObject bulletGo1 = (GameObject)Instantiate(aoeBulletPrefab, aoeBulletSpawnSpots[x].position, aoeBulletSpawnSpots[x].rotation);
            }
        }
    }
}
