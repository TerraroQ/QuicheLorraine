using UnityEngine;
using System.Collections;

public class IngredientsController : MonoBehaviour {
	public string[] order;
	private int count;
	
	// Use this for initialization
	void Start () {
		order = new string[8] {"ie_eggs", "ie_milk", "ie_salt", "ie_flour", "ie_bacon", "ie_water", "ie_cheese", "ie_butter"};
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("Something has entered this zone." + other.gameObject.name);
		if (other.gameObject.name == order [count]) { 
			Destroy (other.gameObject);
			count++;
		}
	}
}
