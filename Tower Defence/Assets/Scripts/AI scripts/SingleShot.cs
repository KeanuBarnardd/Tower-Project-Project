using UnityEngine;
using System.Collections;

public class SingleShot : MonoBehaviour
{
    //Shooting Variables
    public GameObject bulletPrefab;

    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    private float coolDownTimer = 0;
    public float fireDelay;
    //public TowerTypes[] singleShot;

    //Data we need to access
    
    public TowerTypes data;


    // Use this for initialization
    void Start()
    {
        if (data != null)
        {
            bulletPrefab = data.towerChoice[0].BulletPrefab;
            fireDelay = data.towerChoice[0].FireRate;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletPrefab != null)
        {
            coolDownTimer -= Time.deltaTime;
            if (coolDownTimer <= 0)
            {
                Debug.Log("Tower fires Shot");
                coolDownTimer = fireDelay;
                Vector3 offset = transform.rotation * new Vector3(0, 0.5f, 0);
                GameObject bulletShoot = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            }
        }
    }
}
