using UnityEngine;
using System.Collections;

public class LevelManage : MonoBehaviour {
    public void LoadLevel(string Levelname) {
        Debug.Log("Changing level to : " + Levelname);
        Application.LoadLevel(Levelname);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
