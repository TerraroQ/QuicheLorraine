using UnityEngine;
using System.Collections;

public class IngredientsController : MonoBehaviour {
	public string[] order;
	public string[] orderHints;
	private int count;
	public int errors;
	private GameObject hints;
	private GameObject nextHints;
	private GameObject franswa;
	public GUIStyle style;
	public Font PatrickFont;

	// Use this for initialization
	void Start () {
		order = new string[8] {"ie_milk", "ie_flour", "ie_salt", "ie_eggs", "ie_bacon", "ie_water", "ie_cheese", "ie_butter"};
		orderHints = new string[8] {"hud_hints_milk", "hud_hints_flour", "hud_hints_salt", "hud_hints_eggs", "hud_hints_bacon", "hud_hints_water", "hud_hints_cheese", "hud_hints_butter"};
		count = 0;
		errors = 0;
		hints = new GameObject();
		franswa = GameObject.Find("scn_franswa_2");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {
		style.font = PatrickFont;
    	GUI.Label(new Rect(Screen.width * 0.05f , Screen.height * 0.08f , Screen.width * 0.4f , Screen.height * 0.2f), "Fouten: " + errors, style);
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("Something has entered this zone." + other.gameObject.name);
		if (other.gameObject.name == order [count]) { 
			Destroy (other.gameObject);
			franswa.animation.Play("franswa_1");
			hints = GameObject.Find(orderHints [count]);
			count++;
			if (count == 7) {
				Application.LoadLevel("outro");
			} else {
				if (hints != null) {
					hints.transform.Translate(0,0,10); //naar achteren
				}
				nextHints = GameObject.Find(orderHints [count]);
				if (nextHints != null) {
				    nextHints.transform.Translate(0,0,-10); //naar voren
				}
			}
		} else {
			Debug.Log("Fout");
			errors++;
		}
	}
}
