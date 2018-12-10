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
	public void Level1(){
		if (!_isAndroid) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		SceneManager.LoadScene ("Level 1");
	}
	public void Level2(){
		if (!_isAndroid) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		SceneManager.LoadScene ("Level 2");
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
