using UnityEngine;
using System.Collections;

public class MoveFoward : MonoBehaviour {

    public float maxSpeed = 5;
    public float timeAlive;

    // Update is called once per frame
    void Start()
    {

    }

	
	// Update is called once per frame
	void Update () {
        
        Vector3 pos = transform.position;
        Vector3 veclocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        pos += transform.rotation * veclocity;
        transform.position = pos;

        timeAlive -= Time.deltaTime;
        if (timeAlive <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyTypeTag") {
            Destroy(gameObject);
        }
    }
}
