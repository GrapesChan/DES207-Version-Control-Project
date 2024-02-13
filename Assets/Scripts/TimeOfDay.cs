using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDay : MonoBehaviour
{
	/// The current time, in hours.
	[Range(0.0f, 24.0f)]
	public float currentTime;

	///	The transform for our light source.
	public Transform lightSourceTransform;
	
	/// Update our time.
	void Update()
	{
		currentTime += Time.deltaTime;
		if(currentTime >= 24.0f)
			currentTime -= 24.0f;

		//Set middleware time-of-day variable here.

		lightSourceTransform.localEulerAngles = new Vector3(((currentTime - 6.0f)/24.0f) * 360.0f, -30.0f, 0.0f);
	}
}
