using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public TowerManager towerManager;
    public PlayerData playerData;
    public EnemyControl enemyControl;

    public Canvas mainCanvas;
    public Canvas pauseCanvas;
    public Text playerInfo;

    private bool paused;
	// Use this for initialization
	void Start () {
        TogglePause(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePause(!paused);
        }
	}


    public void TogglePause(bool pause) {
        paused = pause;
        if (pause == true)
        {
            mainCanvas.enabled = false;
            pauseCanvas.enabled = true;
            playerInfo.text = "[PROGRESS]\n" + towerManager.towerdata.Display() + "\n Gold : " + playerData.gold + " \n Round :" + enemyControl.currentRound ;
            Time.timeScale = 0f;

        }
        else
        {
            mainCanvas.enabled = true;
            pauseCanvas.enabled = false;
            Time.timeScale = 1f;
        }
    }
    public void BtnQuit() {
     Application.Quit();
    }
    public void BtnResume() {
        TogglePause(false);
    }
}
