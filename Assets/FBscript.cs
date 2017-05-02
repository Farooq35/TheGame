using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine.UI;

public class FBscript : MonoBehaviour {
	public GameObject DialogLoggedIn;
	public GameObject DialogLoggedOut;
	public GameObject DailogUsername;
//	public GameObject DailogUserPicturer;

	void Awake(){
		FB.Init (SetInit, onHideUnity);
	}
	void SetInit()
	{
		if (FB.IsLoggedIn) {
			Debug.Log ("FB is logged in");
		} else
			print ("log in please");
		DealWithFBMenu(FB.IsLoggedIn);
	}
	void onHideUnity(bool isGameShowing)
	{
		if (!isGameShowing) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void FBlogin(){
		List<string> permissions = new List<string>();
		permissions.Add ("public_profile");

		FB.LogInWithReadPermissions (permissions, AuthCallBack);
	}

	void AuthCallBack(IResult result){
		if (result.Error != null) {
				print (result.Error);
			}
		else {
				if(FB.IsLoggedIn){
					print("FB is logged in");
				}
				else
					print("FB is not logged in");
			DealWithFBMenu(FB.IsLoggedIn);
		}

	}
	void DealWithFBMenu(bool isLoggedIn)
	{
		if (isLoggedIn) {
			DialogLoggedIn.SetActive(true);
			DialogLoggedOut.SetActive(false);
			FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
			//FB.API("/me/picture?type=square&width=125&height=125", HttpMethod.GET, Displayprofilepic);
		} else {
			DialogLoggedIn.SetActive(false);
			DialogLoggedOut.SetActive(true);
			//DailogUserPicturer.SetActive(false);
		}
	}
	void DisplayUsername(IResult result)
	{
		Text user_name = DailogUsername.GetComponent<Text> ();
		if (result.Error == null) {
			user_name.text = result.ResultDictionary["first_name"].ToString();

			//print(result.Error+" Error");
		} else {
			print(result.Error);
		//	user_name.text = result.ResultDictionary["first_name"].ToString();
		}
	}
//	void Displayprofilepic(IGraphResult result){
//	if (result.Texture != null) {
//			Image Profilepic = DailogUserPicturer.GetComponent<Image>();
//			Profilepic.sprite = Sprite.Create(result.Texture,new Rect(8,8,128,128), new Vector2());
//		}
//	}
}
