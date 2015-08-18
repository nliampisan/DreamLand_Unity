using UnityEngine;
using System.Collections;
using UnityEngine.UI; 


public class PickUp : MonoBehaviour {

	public Text countText; 
	public Text centerText; 
	public float mytime;



	void Start() 
	{
		mytime = 15.0f; 
		centerText.text = ""; 
		countText.text = "Time: " + mytime.ToString ("0.00") + " secs" ; 
	}

	void Update() 
	{
		if (mytime < 0.0f) {
			centerText.text = "Game Over"; 
		} else {
			countText.text = "Time: " + mytime.ToString ("0.00") + " secs"; 
		}

		mytime -= Time.deltaTime; 

		if (mytime < -0.5f) {
			Application.LoadLevel(0); 
		}
		
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Time"))
		{
			other.gameObject.SetActive (false);
			mytime = mytime+10.0f; 
		}
	}
}
