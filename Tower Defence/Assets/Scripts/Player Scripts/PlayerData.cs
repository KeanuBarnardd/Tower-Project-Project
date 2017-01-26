using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {
    public MoneyMakerScript moneyMakerData;
    //Player Variables
    //This var is health and gold 
    public int gold;
    private bool isDead;
    //UI 
    public Text goldDisplay;
    //Tower Variables

	// Use this for initialization
	void Start () {
        //To be changed for balance later
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
        goldDisplay.text = "Gold : " + gold;
        if (gold <= 0) {
            isDead = true;
        }
	}
}
