using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

	[SerializeField] private float vel=8;
	[SerializeField] private float spe=80;
	[SerializeField] private GameModeManager _gmManager;
	[SerializeField] private RawImage UI;
	[SerializeField] private Gun _gun;
	private BaseManager[] _base;
	float transX;
	float transZ;
	float rotX;
	float rotY;
	private int cont;
	RaycastHit info;

	void Start(){
		cont = 0;
	}
    void Awake()
    {
        _base = FindObjectsOfType<BaseManager>();
    }

    void OnEnable()
	{
		GameManager.GetInstance ().AddListener (OnWaveEndEvent, GameManager.GameEvent.WaveEnd);
	}

	void OnDisable()
	{
		if (GameManager.GetInstance ()) {
			GameManager.GetInstance ().RemoveListener (OnWaveEndEvent, GameManager.GameEvent.WaveEnd);
		}
	}


	void OnWaveEndEvent(GameManager.GameEvent evt)
	{
		Debug.Log ("OnWave End");
	}

	void Update () {
		switch (_gmManager.GameMode) {
		case GameModeManager.GAMEMODE.WALLBUILDER:
			transZ = InputManager.Instance.GetVerticalKeyAxis() * vel * Time.deltaTime;
			transX = InputManager.Instance.GetHorizontalKeyAxis() * vel * Time.deltaTime;
			rotX += InputManager.Instance.GetVerticalAxis() * spe * Time.deltaTime;
			rotY += InputManager.Instance.GetHorizontalAxis() * spe * Time.deltaTime;
			rotX = Mathf.Clamp(rotX, -70f, 70f);
			transform.GetChild (0).transform.localRotation =  Quaternion.Euler (-rotX, 0, 0);
			transform.Translate (transX, 0, transZ);
			transform.rotation = Quaternion.Euler(0, rotY, 0);
			break;
		case GameModeManager.GAMEMODE.DESTROYER:
			rotX += InputManager.Instance.GetVerticalAxis() * spe * Time.deltaTime;
			rotY = InputManager.Instance.GetHorizontalAxis() * spe * Time.deltaTime;
			rotX = Mathf.Clamp(rotX, -70f, 70f);
			transform.GetChild (0).transform.localRotation =  Quaternion.Euler (-rotX - _gun.recoil, 0, 0);
			transform.Rotate (0, rotY, 0);
			transform.position = (_base [cont].transform.position) + (new Vector3 (0.0f, 3.0f, 0.0f));
			if (InputManager.Instance.GetFire3Button()) {
				if (cont != (_base.Length - 1)) {
					cont++;
				} else {
					cont = 0;
				}
			}
			break;
		}
		if (InputManager.Instance.GetMapButton()) {
			UI.GetComponent<RawImage> ().enabled= (!UI.GetComponent<RawImage> ().IsActive());
		}
	}

	public Gun gun{
		set{ _gun = value;}
	}
}
