using UnityEngine;
using System.Collections;

public class TowerPlacement : MonoBehaviour
{
    //Scripts that i need to access
    public PlayerData playerData;
    public TowerUpgrade towerUpgradeData;

    //This script is placed on the cursor object
    //Variables
    public float unit = 50;
    //Distance  maintained from the camera
    public float disMaintain = 10;
    public Color towerColour = Color.blue;
    private Color CursorColour;
    private bool inUse = false;
    public TowerManager towerMangager;


    private Collider2D[] overlap;
    public TowerTypes towersTypes;

    //Selling & Buying Variables
    [HideInInspector]
    public GameObject towerOver;

     

    //Functionality Variables
    [HideInInspector]
    public bool canPlace , canView ;
    // [HideInInspector]
    //public Vector2 cursorPos;
    [HideInInspector]
    public GameObject towerToPlace;

    public int towerIndex;


    // Use this for initialization
    void Start()
    {
        CursorColour = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().color = CursorColour;
        //Gets the mouses position
        // Vector3 mousePos = Input.mousePosition;
        //Set the movement of the mouse to follow our grid system
        // Vector3 pos = new Vector3 (Mathf.Round(mousePos.x/unit) * unit, Mathf.Round(mousePos.y / unit) * unit,Mathf.Round(disMaintain));
        //Apply the Grid system to the cursor 
        // transform.position = Camera.main.WorldToScreenPoint(pos);

        if (inUse)
        {
            Vector3 mousePos = Input.mousePosition; //get the mouse position
            Vector3 pos = new Vector3(Mathf.Round(mousePos.x / unit) * unit, //gridlock on X
            Mathf.Round(mousePos.y / unit) * unit, //gridlock on Y
            Mathf.Round(disMaintain)); //maintain distance size from camera

            transform.position = Camera.main.ScreenToWorldPoint(pos); //apply the position
            //Reference the position of the cursor
            //cursorPos = pos;
            BoxCollider2D box = GetComponent<BoxCollider2D>();
            overlap = Physics2D.OverlapAreaAll(box.bounds.min, box.bounds.max);

            if (canPlace)
            {
                if (Input.GetMouseButtonUp(0) && towerToPlace != null)
                {
                    playerData.gold -= towerToPlace.GetComponent<SetColour>().buyPrice;
                    GameObject TowerSpawnOnPos = (GameObject)Instantiate(towerToPlace, Camera.main.ScreenToWorldPoint(pos), towerToPlace.transform.rotation);
                    Vector3 newPos = TowerSpawnOnPos.transform.position;
                    newPos.z = 0;
                    TowerSpawnOnPos.transform.position = newPos;
                    towerMangager.towerdata.AddTower(TowerSpawnOnPos);
                    //Single Shot
                    if (TowerSpawnOnPos.transform.childCount > 0 && TowerSpawnOnPos.transform.GetChild(0).GetComponent<SingleShot>() == true)
                    {
                        print(1);
                        TowerSpawnOnPos.transform.GetChild(0).GetComponent<SingleShot>().data = towersTypes;
                        //TowerSpawnOnPos.transform.GetComponent<TowerClickData>().index = towerIndex;
                    }
                    else if (TowerSpawnOnPos.transform.GetComponent<MoneyMakerScript>() == true)
                    {
                        print(2);
                        TowerSpawnOnPos.transform.GetComponent<MoneyMakerScript>().playerData = playerData;
                    }
                    else if (TowerSpawnOnPos.transform.GetComponent<AoeShot>() == true)
                    {
                        print(3);
                        TowerSpawnOnPos.transform.GetComponent<AoeShot>().towerTypeData = towersTypes;
                    }
                    else
                    {
                        print(4);
                    }
                    HideCursor();
                }
            }
            if (canView) {
                if (Input.GetMouseButtonUp(0) && towerOver != null) {
                    towerUpgradeData.GetComponent<Canvas>().enabled = true;
                    canView = false;
                }
            }
        }
    }
    public void ShowCursor(GameObject tower, Color colour)
    {
        towerToPlace = tower;
        towerColour = colour;
     
        canPlace = false;
        inUse = true;
    }

    public void ShowCursor() {
        canView = true;
        inUse = true;
    }

    public void HideCursor()
    {
        towerToPlace = null;
        towerColour = new Color(0, 0, 0, 0);
        canPlace = false;
        inUse = false;
        canView = false;
        CursorColour = new Color(0, 0, 0, 0);
        towerOver = null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (inUse)
        {
            if (collision.tag == "TowerSpace" && overlap.Length == 2)
            {
                CursorColour = towerColour;
                canPlace = true;

            }
            else
            {
                CursorColour = Color.red;
                canPlace = false;


                //Trying to do a check for specific componenet on object , so how would you use getComponent - to find out 
                //if the componenet has SetColour script.
                if (collision.GetComponent<SetColour>() == true)
                {
                    CursorColour = Color.green;  //collision.GetComponent<SetColour>().towerColour;
                    towerOver = collision.gameObject;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (inUse)
        {
            if (collision.tag == "TowerSpace")
            {
                CursorColour = Color.red;
                canPlace = false;
                //towerOver = null;
            }
        }
    }
}
