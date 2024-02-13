using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSoundTrigger : MonoBehaviour
{
	///	The Audio Source we'll play our sounds from.
	public AudioSource boxSounds;

	///	The Audio Clip to play when the box is picked up.
	public AudioClip pickupSound;
	///	The Audio Clip to play when the box is dropped.
	public AudioClip dropSound;
	///	The Audio Clip to play when the box collides with the ground.
	public AudioClip collideSound;

	/// Used to trigger a sound when the box collides with something after falling.
	private bool falling = false;

	///	Called when the box is picked up.
	public void PickupBox()
	{
		boxSounds.PlayOneShot(pickupSound);
	}

	///	Called when the box is picked up.
	public void DropBox()
	{
		boxSounds.PlayOneShot(dropSound);
	}

	///	We use this to trigger a sound when the box collides with the ground.
	public void OnCollisionEnter(Collision collision)
	{
		if(falling)
		{
			boxSounds.PlayOneShot(collideSound);
		}
	}

	/// Used to set our falling variable.
	void OnCollisionStay(Collision collision)
	{
		falling = false;
	}

	/// Used to set our falling variable.
	void OnCollisionExit(Collision collision)
	{
		falling = true;
	}
}
