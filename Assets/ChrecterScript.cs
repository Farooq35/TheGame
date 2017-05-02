using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChrecterScript : MonoBehaviour {
	public float distence;
	public GameObject[] hunts;
	public bool _distroyd=false;
	public GameObject arrow;
	public Image hbar;

	public AudioClip clip;

	public GameObject climate;

	public int i=0;
	LookingAt look;
	public	int count=0;
	public GameObject successCan;
	// Use this for initialization
	void Start () {
		//eatable = GameObject.FindGameObjectWithTag ("eatable");
		look=FindObjectOfType(typeof(LookingAt))as LookingAt;
		hbar.fillAmount = 0.2f;
		climate.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (hbar.fillAmount >= 0.99f) {
			successCan.SetActive (true);
			Time.timeScale = 0.0001f;
		}
		StartCoroutine (waitForClimateChange (60.0f));
//		arrow.transform.LookAt (hunts [i].transform.position);
//		print( hunts[0]);
//		distence= Vector3.Distance (gameObject.transform.position, look.hunts[look.i].transform.position);
//			if (distence <= 1.0f) {
//			Destroy (look.hunts[look.i]);
//		}
//		if (Destroy(look.hunts[look.i])) {
//			print ("distryd" + look.i);
//		}

		//print (distence);
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "eat") {
			GameObject.FindGameObjectWithTag("eat").gameObject.SetActive(false);
			count++;
			hbar.fillAmount += 0.2f;

		}
		if (col.gameObject.tag == "eat1") {
			GameObject.FindGameObjectWithTag("eat1").gameObject.SetActive(false);
			_distroyd = true;
			count++;
			hbar.fillAmount += 0.2f;

		}
		if (col.gameObject.tag == "eat2") {
			GameObject.FindGameObjectWithTag("eat2").gameObject.SetActive(false);
			_distroyd = true;
			count++;
			hbar.fillAmount += 0.2f;

		}
		if (col.gameObject.tag == "eat3") {
		   	GameObject.FindGameObjectWithTag("eat3").gameObject.SetActive(false);
			_distroyd = true;
			count++;
			hbar.fillAmount += 0.2f;

		}
		if (col.gameObject.tag == "eat4") {
			GameObject.FindGameObjectWithTag("eat4").gameObject.SetActive(false);
			_distroyd = true;
			count++;
			hbar.fillAmount += 0.2f;

		}
	}
	IEnumerator waitForClimateChange(float time)
	{
		yield return new WaitForSeconds (time);
		climate.SetActive (true);
		AudioSource audio = GetComponent<AudioSource>();

		audio.Stop();
		yield return new WaitForSeconds(audio.clip.length);
		audio.clip = clip;
		audio.Stop();
		yield return new WaitForSeconds (60.0f);
		climate.SetActive (false);
		audio.Play();
	}
}
