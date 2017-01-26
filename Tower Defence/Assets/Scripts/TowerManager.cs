using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TowerManager : MonoBehaviour
{
    public TowerPlacement TowerPlacementdata;

    public GameObject TowerSelect;

    public Text instructions;

    public KeyCode displayKey;

    private bool showMenu;

    public TowerTypes towerTypesData;

    public PlayerData playerData;

    


    // Use this for initialization
    void Start()
    {
        TowerPlacementdata.HideCursor();
        HandleTowerMenu(false);
        
    }
    public TowerData towerdata;
    [System.Serializable]
    public struct TowerData {
        public int totalCount, singleShotCount, AoeShotCount, MoneyMakerCount;
        public List<GameObject> singleShot, AoeShot, MoneyMaker;

        public void AddTower(GameObject theTower) {
            totalCount++;
            if (theTower.name.StartsWith("SingleShotTower")) {
                singleShotCount++;
                singleShot.Add(theTower);
            }
            if (theTower.name.StartsWith("MoneyMakerTower")) {
                MoneyMakerCount++;
                MoneyMaker.Add(theTower);
            }
            if (theTower.name.StartsWith("AOEShootTower")) {
                AoeShotCount++;
                AoeShot.Add(theTower);
            }
            
        }
        public string Display() {
            return "Total : " + totalCount + "\n Singleshot : " + singleShotCount + "\n AOE Shot : " + AoeShotCount + "\nMoneyMaker : " + MoneyMakerCount;
        }
    };


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(displayKey))
        {
            showMenu = !showMenu;
            HandleTowerMenu(showMenu);
        }
      
    }
    public void BtnSelectTower(GameObject tower) {
        if (playerData.gold >= tower.GetComponent<SetColour>().buyPrice)
        {
            TowerPlacementdata.ShowCursor(tower, tower.GetComponent<SetColour>().towerColour);
            showMenu = false;
            HandleTowerMenu(showMenu);
        }
        else
        {
            print("Not enough money");
        }
    }

    private void HandleTowerMenu(bool show) {
        TowerSelect.SetActive(show);
        if (show == true)
        {
            instructions.text = "Press <b>" + displayKey + "</b> to close Tower Menu";
            instructions.color = Color.white;
            TowerPlacementdata.HideCursor();
            Time.timeScale = 0f;
        }
        else
        {
            instructions.text = "Press <b>" + displayKey + "</b> to open Tower Menu";
            instructions.color = Color.black;

            Time.timeScale = 1f;
        }
    }
    public void BtnViewTowers()
    {
        TowerPlacementdata.ShowCursor();
        showMenu = false;
        HandleTowerMenu(showMenu);
    }
}
