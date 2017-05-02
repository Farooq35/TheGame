using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAt : MonoBehaviour {
	//public Transform[] eatable;
	public Transform[] hunts;
	//public int i=1;
	ChrecterScript tps;
	// Use this for initialization
	void Start () {
		tps = FindObjectOfType (typeof(ChrecterScript))as ChrecterScript;
//		for (int i = 0; i < eatable.Length; i++) {
//			eatable [i].gameObject.SetActive (false);
//		}
//		for (int i = 0; i < hunts.Length; i++) {
//			hunts[i].gameObject.SetActive (false);
//		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (hunts [0].transform);
		if (tps.count==1) {
			transform.LookAt (hunts [1].transform.position);
		}
		if (tps.count==2) {
			transform.LookAt (hunts [2].transform.position);
		}
		if (tps.count==3) {
			transform.LookAt (hunts [3].transform.position);
		}
		if (tps.count==4) {
			transform.LookAt (hunts [4].transform.position);
		}
	}
}
