using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRoomBars : MonoBehaviour
{
	/// Used to move the bars.
	public Transform barsTransform;

	/// How long the bars take to open/close.
	[Range(0.0f, 10.0f)]
	public float barsTime = 1.5f;

	///	Sound to play when the bars lower.
	public AudioSource barsSound;

	/// True if the bars should be open.
	private bool open = false;
	
	/// Update is called once per frame.
	void Update()
	{
		if(open && (barsTransform.position.y > -15.1f))
		{
			barsTransform.position -= Vector3.up * 15.1f * (1.0f/barsTime) * Time.deltaTime;
		}
		else if(!open && (barsTransform.position.y < 0.0f))
		{
			barsTransform.position += Vector3.up * 15.1f * (1.0f/barsTime) * Time.deltaTime;
		}
	}

	/// Tells the bars to open.
	public void OpenBars()
	{
		open = true;

		barsSound.Play();
	}

	/// Tells the bars to close.
	public void CloseBars()
	{
		open = false;

		//Should maybe play different close sound instead?
		barsSound.Play();
	}
}
