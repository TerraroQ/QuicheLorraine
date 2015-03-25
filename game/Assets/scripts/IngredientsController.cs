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
<<<<<<< Updated upstream
	public Font PatrickFont;
=======
	public bool toggleGUI;
	public int sortingOrderTop = 3;
	public float timeRemaining = 10;
	private SpriteRenderer spriteScreen;
	private SpriteRenderer spriteGood;
	private SpriteRenderer spriteMiddle;
	private SpriteRenderer spriteBad;
>>>>>>> Stashed changes

	// Use this for initialization
	void Start () {
		order = new string[8] {"ie_milk", "ie_flour", "ie_salt", "ie_eggs", "ie_bacon", "ie_water", "ie_cheese", "ie_butter"};
		orderHints = new string[8] {"hud_hints_milk", "hud_hints_flour", "hud_hints_salt", "hud_hints_eggs", "hud_hints_bacon", "hud_hints_water", "hud_hints_cheese", "hud_hints_butter"};
		count = 0;
		errors = 0;
		hints = new GameObject();
<<<<<<< Updated upstream
		franswa = GameObject.Find("scn_franswa_2");
=======
		toggleGUI = true;
>>>>>>> Stashed changes
	}
	
	void Update(){
		GameObject endScreen = GameObject.Find("Eindscherm");
		GameObject quicheGood = GameObject.Find("scn_quiche_good");
		GameObject quicheMiddle = GameObject.Find("scn_quiche_middle");
		GameObject quicheBad = GameObject.Find("scn_quiche_bad");
		GameObject Timer = GameObject.Find("hud_timer");
		timeRemaining -= Time.deltaTime;
		spriteScreen = endScreen.GetComponent<SpriteRenderer>();
		spriteGood = quicheGood.GetComponent<SpriteRenderer>();
		spriteMiddle = quicheMiddle.GetComponent<SpriteRenderer>();
		spriteBad = quicheBad.GetComponent<SpriteRenderer>();
		if (count == 8) {
			spriteScreen.sortingOrder = sortingOrderTop;
			toggleGUI = false;
			if (errors < 3){
				spriteGood.sortingOrder = 5;
			}else if(errors < 5 && errors > 3){
				spriteMiddle.sortingOrder = 5;
			}else{
				spriteBad.sortingOrder = 5;
			}
		}
	}

	void OnGUI () {
<<<<<<< Updated upstream
		style.font = PatrickFont;
    	GUI.Label(new Rect(Screen.width * 0.05f , Screen.height * 0.08f , Screen.width * 0.4f , Screen.height * 0.2f), "Fouten: " + errors, style);
=======
		if(toggleGUI == true){
    		GUI.Label(new Rect(Screen.width * 0.15f , Screen.height * 0.02f , Screen.width * 0.4f , Screen.height * 0.25f), "Fouten: " + errors, style);
		}
		if(toggleGUI == true){
			if(timeRemaining > 0){
		    	GUI.Label(new Rect(Screen.width * 0.05f , Screen.height * 0.02f , Screen.width * 0.4f , Screen.height * 0.25f), "" + Mathf.Round(timeRemaining), style);
		    }
		    else{
		        Application.LoadLevel (Application.loadedLevel);
		    }
		}
>>>>>>> Stashed changes
	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("Something has entered this zone." + other.gameObject.name);
		if (other.gameObject.name == order [count]) { 
			Destroy (other.gameObject);
			franswa.animation.Play("franswa_1");
			hints = GameObject.Find(orderHints [count]);
			if (count == 7) {
				//Application.LoadLevel("result");
				count++;
			} else {
				count++;
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
