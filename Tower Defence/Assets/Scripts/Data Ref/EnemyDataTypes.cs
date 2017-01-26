using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyDataTypes : MonoBehaviour {

    //Basic Enemy Stucture
    public string EnemyName;
    public GameObject EnemyObject;
    public int health;
    public int damage;
    public int waveSpace;
    public int maxHealth;
    public float moveSpeed;
    //UI
    public bool useUi;
    public Image bar;
    public Text text;
    

    //Spawner
    public int babySpawnAmount;

    // Use this for initialization
    void Start () {
        print(gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
        if (useUi) {
            //FillAmount is a float between 0 and 1 , health divided by max health is a percentage of 100
            //So it will return a value between 0 and 1 ( Example : 50 / 100 = 0.5 = half fillAmount )  
            bar.fillAmount = (float)health / (float)maxHealth;

            text.text = health.ToString("000");
            if (Input.GetKeyDown(KeyCode.G))
            {
                health -= Random.Range(1, 15);
            }
        }
    }
}
