using UnityEngine;
using System.Collections;

public class MoneyMakerScript : MonoBehaviour
{

    //public TowerTypes towerTypeData;
    public PlayerData playerData;


    public int moneyMake = 10;

    private float moneyCooldownTimer = 0f;
    public float moneyMakeTimer = 10f;


    // Use this for initialization
    void Start()
    {
        moneyMake = 10;
    }

    // Update is called once per frame
    void Update()
    {

        moneyCooldownTimer -= Time.deltaTime;
        //This is not working
        if (playerData != null)
        {
            Debug.Log("Player Data Found");
            if (moneyCooldownTimer <= 0)
            {
                Debug.Log("Money Given");       
                moneyCooldownTimer = moneyMakeTimer;
                playerData.gold += moneyMake;
             
            }
        }
        
    }
}
