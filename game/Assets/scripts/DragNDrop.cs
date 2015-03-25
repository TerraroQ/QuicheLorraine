using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]

public class DragNDrop : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;
	public AudioClip[] audioClip;
	
	void OnMouseDown() { 
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		PlaySound(0);
	}
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}

	void PlaySound(int clip){
		audio.clip = audioClip[clip];
		audio.Play();
	}
}