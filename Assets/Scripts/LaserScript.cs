using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class LaserScript : MonoBehaviour {

	private int count; 
	public Text countText; 


	LineRenderer line; 
	// Use this for initialization
	void Start () {
		count = 0; 
		countText.text = "Score: " + count.ToString ();  
		line = gameObject.GetComponent<LineRenderer>(); 
		line.enabled = false; 

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false; 



	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			StopCoroutine ("FireLaser"); 
			StartCoroutine ("FireLaser"); 
		}
	
	}

	IEnumerator FireLaser() 
	{
		line.enabled = true; 
		while (Input.GetButton("Fire1")) {


			Ray ray = new Ray(transform.position, transform.forward); 
			RaycastHit hit; 

			line.SetPosition(0, ray.origin); 
			if(Physics.Raycast(ray, out hit, 100))
			{
				line.SetPosition (1, hit.point); 
				if(hit.rigidbody)
				{
					if(hit.rigidbody.gameObject.CompareTag("Target")) {
						hit.rigidbody.gameObject.SetActive(false); 
						count = count+10; 
						countText.text = "Score: " + count.ToString ();  
					}
					else if(hit.rigidbody.gameObject.CompareTag("Neg"))
					{
						hit.rigidbody.gameObject.SetActive(false); 
						count = count-5; 
						countText.text = "Score: " + count.ToString ();
					}
					else
							hit.rigidbody.AddForceAtPosition(transform.forward*20, hit.point); 
				}
			}
			else
				line.SetPosition (1, ray.GetPoint (100)); 

			yield return null; 
		}

		line.enabled = false; 
	}



}
