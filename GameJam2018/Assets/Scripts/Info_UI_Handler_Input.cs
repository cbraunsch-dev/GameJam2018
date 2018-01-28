using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Info_UI_Handler_Input : MonoBehaviour {
	public void StartGame() 
	{
		SceneManager.LoadScene("Level1");
	}
}
