using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreenText : MonoBehaviour
{
    void OnGUI()
	{
		GUIStyle style = new GUIStyle();

		style.normal.textColor = Color.black;

		GUI.Label(new Rect(10, 10, 512, 64),
				  "",
				  style);
	}
}
