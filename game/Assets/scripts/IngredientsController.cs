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
	public bool toggleGUI;
	public int sortingOrderTop = 3;
	public float timeRemaining = 120;
	private SpriteRenderer spriteScreen;
	private SpriteRenderer spriteGood;
	private SpriteRenderer spriteMiddle;
	private SpriteRenderer spriteBad;
	private GameObject endScreen;
	private GameObject quicheGood;
	private GameObject quicheMiddle;
	private GameObject quicheBad;
	private Animator animator;
	private GameObject franswa;
	public AudioClip[] audioClip;

	// Use this for initialization
	void Start () {
		franswa = GameObject.Find("scn_franswa");
		animator = franswa.GetComponent<Animator>();

		order = new string[8] {"ie_milk", "ie_flour", "ie_salt", "ie_eggs", "ie_bacon", "ie_water", "ie_cheese", "ie_butter"};
		orderHints = new string[8] {"hud_hints_milk", "hud_hints_flour", "hud_hints_salt", "hud_hints_eggs", "hud_hints_bacon", "hud_hints_water", "hud_hints_cheese", "hud_hints_butter"};
		count = 0;
		errors = 0;
		hints = new GameObject();

		toggleGUI = true;
		endScreen = GameObject.Find("Eindscherm");
		quicheGood = GameObject.Find("scn_quiche_good");
		quicheMiddle = GameObject.Find("scn_quiche_middle");
		quicheBad = GameObject.Find("scn_quiche_bad");
		//GameObject Timer = GameObject.Find("hud_timer");
		timeRemaining -= Time.deltaTime;
		spriteScreen = endScreen.GetComponent<SpriteRenderer>();
		spriteGood = quicheGood.GetComponent<SpriteRenderer>();
		spriteMiddle = quicheMiddle.GetComponent<SpriteRenderer>();
		spriteBad = quicheBad.GetComponent<SpriteRenderer>();
	}
	
	void Update(){
		timeRemaining -= Time.deltaTime;
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

	void PlaySound(int clip){
		audio.clip = audioClip[clip];
		audio.Play();
	}
	
	void OnGUI () {
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
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log("Something has entered this zone." + other.gameObject.name);
		if (other.gameObject.name == order [count]) { 
			Destroy (other.gameObject);
			//franswa.animation.Play("franswa_fout");
			animator.SetTrigger("goedAntwoord");
			hints = GameObject.Find(orderHints [count]);
			PlaySound(0);
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
			animator.SetTrigger("foutAntwoord");
			PlaySound(1);
			//Debug.Log("Fout");
			errors++;
		}
	}
}