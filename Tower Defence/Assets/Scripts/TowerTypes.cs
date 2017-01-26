using UnityEngine;
using System.Collections;

public class TowerTypes : MonoBehaviour {

    //Data
    [Header("Towers")]
    //Data that we need to access
    public Towers[] towerChoice;
    public TowerDataTypes towerDataData;
    public SingleShot singleShotData;
    public MoneyMakerScript moneyData;
    public PlayerData playerData;
    public AoeShot aoeData;
    // Use this for initialization
    void Start () {
	
	}

    [System.Serializable]
    public struct Towers {
        //Basic structure of a Tower
        [Tooltip("Stores the name of the tower")]
        public string towerName;
        public int towerIndex;
        [Space]
        [Tooltip("Controls the attack range of the tower")]
        public float shootRange;
        [Tooltip("Controls the attack speed of the tower")]
        public float shootSpeed;
        [Space]
        [Tooltip("Controls how much damage is done by the tower")]
        public int damage;
        [Tooltip("Controls how much the tower cost to build")]
        public int cost;
        [Tooltip("Controls how many times the tower fires a second")]
        public int FireRate;
        [Tooltip("Controls how many bullets are shot from this tower")]
        public int bullShoot;
        [Space]
        //Single shot tower
        [Tooltip("Stores the chosen Bullet prefab")]
        public GameObject BulletPrefab;
        [Tooltip("If Tower has the Second Shot Upgrade")]
        public bool SecondShot; 
        [Tooltip("Sets the offset for the shot bullet")]
        public Vector3 SecondShotOffset;

        //AOE damage Tower
        [HideInInspector]
        public GameObject aoeShot;
        [Space]
        //Money Maker Tower
        [HideInInspector]
        private int moneyAdd;
        [HideInInspector]
        private int moneyMakeRate;
        [HideInInspector]
        private int maxMoneyRound;

        public void SetAllData(GameObject self) {
            self.GetComponent<TowerDataTypes>().shootRange = shootRange;
            self.GetComponent<TowerDataTypes>().shootSpeed = shootSpeed;
            self.GetComponent<TowerDataTypes>().damage = damage;
            self.GetComponent<TowerDataTypes>().cost = cost;
            self.GetComponent<TowerDataTypes>().FireRate = FireRate;
            self.GetComponent<TowerDataTypes>().towerName = towerName;
            self.GetComponent<TowerDataTypes>().bullShot = bullShoot;
        }
    };
	// Update is called once per frame
	void Update () {
	
	}
}
