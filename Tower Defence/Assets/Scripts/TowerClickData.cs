using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerClickData : MonoBehaviour  {

    public TowerTypes towerTypesData;
    public Canvas displayCanvas;
    public Text displayText;
    public int index;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        //displayCanvas.enabled = true;
        //string displayData = towerTypesData.towerChoice[index]
        //displayText.text = displayData;
    }
}
