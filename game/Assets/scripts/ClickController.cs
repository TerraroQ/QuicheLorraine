using UnityEngine;
using System.Collections;

public class ClickController : MonoBehaviour {
	private GameObject wolkje1;
	private GameObject wolkje2;
	private int state;

	void Start(){
		state = 0; //0 is start
		wolkje1 = GameObject.Find("ie_wolkje_1");
		wolkje2 = GameObject.Find("ie_wolkje_2");
	}

	void OnMouseDown(){
		//Debug.Log("swag");
		if (state == 0) {
			wolkje1.transform.Translate(0,0,10); //naar achter
			wolkje2.transform.Translate(0,0,-10); //naar voren
		} else if (state == 1) {
			Application.LoadLevel("kitchen");
		}
		state++;
	}   
}
