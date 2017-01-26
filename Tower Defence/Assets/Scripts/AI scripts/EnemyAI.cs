using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    //Movement Variables
    public bool isMoving = true;
    //Sets the Parent Object for the wayPoints
    public Vector3 startPoint;
    public Vector3 nextPoint;
    public float moveMentSpeed;   
    private Transform nextWayPoint;

    [HideInInspector]
    public Transform[] wayPoints;
    private int currentWayPoint;

    private EnemyDataTypes data;

    public PlayerData playerData;

    // Use this for initialization
    void Start()
    {
        //GameObject.Find("GameObjectName").GetComponent<componentName>();
        data = GetComponent<EnemyDataTypes>();
        moveMentSpeed = GetComponent<EnemyDataTypes>().moveSpeed;

        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            if (nextWayPoint != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, nextWayPoint.position, moveMentSpeed * Time.deltaTime);

                if (Vector2.Distance(transform.position, nextWayPoint.position) <= 0.1f)
                {
                    currentWayPoint++;
                    if (currentWayPoint >= wayPoints.Length - 1)
                    {
                        //Add in damage to the player here !!!
                        KillYourself(true);                     
                    }
                    else
                    {
                        nextWayPoint = wayPoints[currentWayPoint];
                    }
                }
            }
        }
    }

    public void GenerateWayPoints( GameObject setPathway) {
        //Sets the size of WayPoints of the size of how many children there
        wayPoints = new Transform[setPathway.transform.childCount];

        // ChildCount returns all the children starting at index 1 and not 0 ( -1 fixes that )
        for (int i = 0; i < setPathway.transform.childCount - 1; i++)
        {
            wayPoints[i] = setPathway.transform.GetChild(i);
        }
        currentWayPoint = 0;
        nextWayPoint = wayPoints[0];
    }

    private void KillYourself(bool subtractMoney ) {
        if (subtractMoney == true)
        {
            Debug.Log("Enemy Takes money");
            playerData.gold -= data.damage;
            isMoving = false;
            Destroy(gameObject);
        }
        else {
            Debug.Log("Damage Done");
            playerData.gold += data.damage;
            isMoving = false;
            Destroy(gameObject);
        }
 
    }
    
    public void TakeDamge(int damage) {
        data.health -= damage;
        if (data.health <= 0 ) { data.health = 0; KillYourself(false); }    
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SingleShotBulletTag") {
            Debug.Log("Collision has been made");
            TakeDamge(1);
        }
    }


}
