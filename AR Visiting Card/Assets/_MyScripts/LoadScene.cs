using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {



	public void LoadMainScene()
	{
		SceneManager.LoadScene ("MainScene");
	}
    public void LoadPreview()
    {
        SceneManager.LoadScene("Preview");
    }

    public void Quit() {
        Application.Quit();
    }
    
}
