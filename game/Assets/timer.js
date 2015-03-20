#pragma strict
var timeRemaining : float = 5;
var style : GUIStyle;

function Start(){
	style.normal.textColor = Color.black;
}

function Update () {
    timeRemaining -= Time.deltaTime;
}

function OnGUI(){
	
    if(timeRemaining > 0){
    	GUI.Label(new Rect(320, 70, 200, 100), "" + Mathf.Round(timeRemaining), style);
    }
    else{
        Application.LoadLevel (Application.loadedLevel);
    }
}