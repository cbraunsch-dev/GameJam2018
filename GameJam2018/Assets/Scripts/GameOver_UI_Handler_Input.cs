using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_UI_Handler_Input : MonoBehaviour {

	public void Retry() 
	{
		SceneManager.LoadScene("Level1");
	}

	public void MainMenu() 
	{
		SceneManager.LoadScene("TitleScreen");
	}
}
