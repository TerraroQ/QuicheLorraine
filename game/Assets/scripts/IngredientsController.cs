using UnityEngine;
using System.Collections;

public class IngredientsController : MonoBehaviour {
	public string[] order;
	public string[] orderHints;
	private int count;
	public int errors;
	private GameObject hints;
	private GameObject nextHints;
	public GUIStyle style;

	// Use this for initialization
	void Start () {
		order = new string[8] {"ie_milk", "ie_salt", "ie_eggs", "ie_flour", "ie_bacon", "ie_water", "ie_cheese", "ie_butter"};
		orderHints = new string[8] {"hud_hints_milk", "hud_hints_salt", "hud_hints_eggs", "hud_hints_flour", "hud_hints_bacon", "hud_hints_water", "hud_hints_cheese", "hud_hints_butter"};
		count = 0;
		errors = 0;
		hints = new GameObject();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {
    	GUI.Label(new Rect(350, 70, 200, 100), "Fouten: " + errors, style);
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		hints = GameObject.Find(orderHints [count]);
		nextHints = GameObject.Find(orderHints [count + 1]);
		//Debug.Log("Something has entered this zone." + other.gameObject.name);
		if (other.gameObject.name == order [count]) { 
			Destroy (other.gameObject);
			count++;
			if (hints != null) {
				hints.transform.Translate(0,0,10); //naar achteren
			}
			if (nextHints != null) {
			    nextHints.transform.Translate(0,0,-10); //naar voren achteren
			}
		} else {
			Debug.Log("Fout");
			errors++;
		}
	}
}
