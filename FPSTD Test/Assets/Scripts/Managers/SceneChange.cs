using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	private bool _isAndroid;
	void Awake(){
		#if UNITY_ANDROID
		_isAndroid=true;
		#else
		_isAndroid=false;
		#endif
	}
	public void MainMenu(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		SceneManager.LoadScene ("MainMenu");
	}
	public void Game(){
		if (!_isAndroid) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		SceneManager.LoadScene ("Game");
	}
	public void Lose(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		SceneManager.LoadScene ("GameLose");
	}
	public void Win(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		SceneManager.LoadScene ("GameWin");
	}
	public void Quit(){
		Application.Quit();
	}
}
