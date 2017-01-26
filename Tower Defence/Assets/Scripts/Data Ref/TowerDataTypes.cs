using UnityEngine;
using System.Collections;

public class TowerDataTypes : MonoBehaviour {
    public string towerName;

    public float shootRange;
    public float shootSpeed;

    
    public int damage;
    public int cost;
    public int FireRate;
    public int bullShot;



    //Single shot tower
    public GameObject BulletPrefab;
    public bool SecondShot; // If second shot is true then you can shoot another bullet.
    public Vector3 SecondShotOffset;


    //AOE damage Tower
    public GameObject aoeShot;

    //Money Maker Tower
    public int moneyAdd;
    public int moneyMakeRate;
    public int maxMoneyRound;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
