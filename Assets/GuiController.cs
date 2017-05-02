using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiController : MonoBehaviour {
	public GameObject pause_Win;
	public GameObject hint;
	public GameObject CF2;
	public GameObject pause_btn;
	// Use this for initialization
	void Start () {
		StartCoroutine (wait (3.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Pause()
	{
		pause_Win.SetActive (true);
		Time.timeScale = 0.0001f;
		CF2.SetActive(false);
		pause_btn.SetActive (false);


	}
	public void Play()
	{
		pause_Win.SetActive (false);
		CF2.SetActive(true);
		pause_btn.SetActive (true);
		Time.timeScale = 1.0f;
	
	}
	public void Restart()
	{
		Application.LoadLevel ("MainScene");

	}
	IEnumerator wait(float time)
	{
		yield return new WaitForSeconds (time);
		hint.SetActive (false);
	}

}
