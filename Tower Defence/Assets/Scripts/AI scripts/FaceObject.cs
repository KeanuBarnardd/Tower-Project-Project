using UnityEngine;
using System.Collections;

public class FaceObject : MonoBehaviour {
    //Rotation and Facing Variables 
    public Transform enemyPositions;
    public float rotSpeed = 90f;
    public EnemyDataTypes data;
    public GameObject findEnemy;
    //Need to figure out how to create a range for the Tower , so that it locks onto to the 
    //Closest target and Shoots and that

	// Use this for initialization
	void Start () {
        data = GetComponent<EnemyDataTypes>();

	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindWithTag("EnemyTypeTag") != null)
        {
            if (enemyPositions == null)
            {
                GameObject enemyFind = GameObject.FindWithTag("EnemyTypeTag");
                if (enemyFind != null)
                {
                    enemyPositions = enemyFind.transform;
                }
            }
        }
        //If the enemy dont exsits
        if (enemyPositions == null) return;

        //Make it face the enemy
        Vector3 dir = enemyPositions.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRotation = Quaternion.Euler(0,0,zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotSpeed * Time.deltaTime);
	}
}
