using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public GameObject homeWindow;
	public GameObject wWindow;
	public GameObject lWindow;
	public GameObject gameWindow;

	public bool play = false;
	public bool rst = false;

	public GameObject hplay;
	public GameObject hleave;

	public GameObject wplay;
	public GameObject wleave;

	public GameObject lplay;
	public GameObject lleave;

	public Button homePlay;
	public Button homeLeave;
	public Button winPlay;
	public Button winLeave;
	public Button losePlay;
	public Button loseLeave;
	public Button reset;


	void Start () {
		homePlay.onClick.AddListener (PlayOnClick);
		homeLeave.onClick.AddListener (LeaveOnClick);
		winPlay.onClick.AddListener (wPlayOnClick);
		winLeave.onClick.AddListener (LeaveOnClick);
		losePlay.onClick.AddListener (lPlayOnClick);
		loseLeave.onClick.AddListener (LeaveOnClick);
		reset.onClick.AddListener (rPlayOnClick);
		play = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void PlayOnClick(){
		homeWindow.SetActive (false);
		gameWindow.SetActive (true);
		play = true;
	}

	void wPlayOnClick(){
		wWindow.SetActive (false);
		gameWindow.SetActive (true);
		play = true;
		rst = true;
	}

	void lPlayOnClick(){
		lWindow.SetActive (false);
		gameWindow.SetActive (true);
		play = true;
		rst = true;
	}

	void rPlayOnClick(){
		SceneManager.LoadScene ("Main");
		homeWindow.SetActive (true);
		gameWindow.SetActive (false);
		rst = true;
	}

	void LeaveOnClick(){
		play = false;
		Application.Quit ();
	}
}
