using UnityEngine;
using System.Collections;

public class TowerUpgrade : MonoBehaviour
{

    //Variables

    //Scripts need to access
    public TowerPlacement towerPlacementData;
    public PlayerData playerData;
    public TowerTypes towerTypesData;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BtnSellTower()
    {
        if (towerPlacementData.towerOver != null)
        {
            playerData.gold += towerPlacementData.towerOver.GetComponent<SetColour>().sellPrice;
            Debug.Log("Sold Tower : " + towerPlacementData.towerOver.name);
            Destroy(towerPlacementData.towerOver);
            towerPlacementData.HideCursor();
            BtnBack();
        }
    }

    public void BtnBack()
    {
        GetComponent<Canvas>().enabled = false;
    }

    public void BtnDamageUpgrade()
    {
        if (towerPlacementData.towerOver != null)
        {
            if (playerData.gold >= towerPlacementData.towerOver.GetComponent<SetColour>().damageUpgradePrice)
            {
                //towerPlacementData.towerOver.GetComponent<TowerTypes>().towerChoice[0].damage += towerPlacementData.towerOver.GetComponent<SetColour>().damageUpgrade;
                playerData.gold -= towerPlacementData.towerOver.GetComponent<SetColour>().damageUpgradePrice;
                Debug.Log("Damage Upgrade Purchased " + towerPlacementData.towerOver.name);
                towerPlacementData.HideCursor();
                BtnBack();
            }
            else
            {
                print("You dont have enough");
            }

        }
    }

    public void BtnFireRate()
    {
        if (towerPlacementData.towerOver != null)
        {
            if (playerData.gold >= towerPlacementData.towerOver.GetComponent<SetColour>().fireRatePrice)
            {
                playerData.gold -= towerPlacementData.towerOver.GetComponent<SetColour>().fireRatePrice;
                Debug.Log("Fire Rate Upgrade has been purchased");
                towerPlacementData.HideCursor();
                BtnBack();
            }

        }
    }
}
