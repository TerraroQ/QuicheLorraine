<<<<<<< Updated upstream
﻿#pragma strict
var timeRemaining : float = 120;
var style : GUIStyle;
var patrickFont : Font;

function Start(){
	style.normal.textColor = Color.black;
}

function Update () {
    timeRemaining -= Time.deltaTime;
}

function OnGUI(){
	
    if(timeRemaining > 0){
   		style.font = patrickFont;
    	GUI.Label(new Rect(Screen.width * 0.05f , Screen.height * 0.02f , Screen.width * 0.4f , Screen.height * 0.25f), "Tijd: " + Mathf.Round(timeRemaining), style);
    }
    else{
        Application.LoadLevel (Application.loadedLevel);
    }
}
=======
﻿
>>>>>>> Stashed changes
