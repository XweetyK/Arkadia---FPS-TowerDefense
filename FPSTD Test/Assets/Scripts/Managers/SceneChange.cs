using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	public void MainMenu(){
		Cursor.lockState = CursorLockMode.None;
		SceneManager.LoadScene ("MainMenu");
	}
	public void Game(){
		SceneManager.LoadScene ("Game");
	}
	public void Lose(){
		Cursor.lockState = CursorLockMode.None;
		SceneManager.LoadScene ("GameLose");
	}
	public void Win(){
		Cursor.lockState = CursorLockMode.None;
		SceneManager.LoadScene ("GameWin");
	}
	public void Quit(){
		Application.Quit();
	}
}
