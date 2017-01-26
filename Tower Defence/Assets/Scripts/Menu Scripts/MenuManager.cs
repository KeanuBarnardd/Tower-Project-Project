using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Text buttonText;
    public bool disable;
    public Color normal = Color.white, hover = Color.white, clicked = Color.white, disabled = Color.white;
    public float rate = 3f;
    private bool finishLoading;

	// Use this for initialization
	void Start () {
        finishLoading = false;
        if (disable) {
            buttonText.color = disabled;
        }
        Color col = buttonText.color;
        col.a = 0f;
        buttonText.color = col;
        InvokeRepeating("FadeIn", 0.1f, 0.1f);
        
	}
    public void BtnHover() {
        if (finishLoading && !disable) {
            buttonText.color = hover;
        }  
    }

    public void BtnClicked()
    {
        if (finishLoading && !disable)
        {
            buttonText.color = clicked;
        }
    }
    public void BtnNormal()
    {
        if (finishLoading && !disable)
        {
            buttonText.color = normal;
        }
    }

    void Update()
    {
        if (finishLoading && disable)
        {
            buttonText.color = disabled;
            GetComponent<Button>().interactable = false;
        }
    }


    public void FadeIn() {
        Color col = buttonText.color;
        col.a += rate * Time.deltaTime;
        buttonText.color = col;
        if (col.a >= 1f) {
            finishLoading = true;
        }
    }
}
