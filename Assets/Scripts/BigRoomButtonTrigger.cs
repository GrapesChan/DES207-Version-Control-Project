using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRoomButtonTrigger : MonoBehaviour
{
	/// The column we're going to lower once we've been triggered.
	public Transform column;
	/// The button we'll depress and turn green once we've been triggered.
	public GameObject button;
	/// The button light we'll turn green once we've been triggered.
	public Light buttonLight;

	/// How long it takes for the column to lower/raise.
	[Range(0.0f, 10.0f)]
	public float columnTime = 1.0f;

	///	Sound to play when the button is pressed.
	public AudioSource buttonSound;

	///	AudioSource to trigger when the column is lowered/raised.
	public AudioSource columnSound;
	///	AudioClip for when the column is lowered.
	public AudioClip columnLoweredSound;
	///	AudioClip for when the column is raised.
	public AudioClip columnRaisedSound;

	/// True if the button's been pressed.
	private bool pressed = false;
	
	// Update is called once per frame
	void Update ()
	{
		if(pressed)
		{
			if(button.transform.position.y > 0.12f)
			{
				button.transform.position -= Vector3.up * Time.deltaTime;
			}

			if(column.position.y > -11.6f)
			{
				column.position -= Vector3.up * 11.6f * (1.0f/columnTime) * Time.deltaTime;
			}
		}
		else
	{
			if(button.transform.position.y < 0.15f)
			{
				button.transform.position += Vector3.up * Time.deltaTime;
			}

			if(column.position.y < 0.0f)
			{
				column.position += Vector3.up * 11.6f * (1.0f / columnTime) * Time.deltaTime;
			}
		}
	}

	/// Called when the player triggers us.
	void OnTriggerEnter(Collider other)
	{
		if((other.gameObject.name == "Player") || (other.gameObject.name == "Key Cube"))
		{
			if(!pressed)
			{
				pressed = true;

				Color col = new Color(0.0f, 0.33f, 0.0f);
				button.GetComponent<Renderer>().material.SetColor("_Color", col);
				button.GetComponent<Renderer>().material.SetColor("_EmissionColor", col);

				buttonLight.color = col;

				buttonSound.Play();
				columnSound.PlayOneShot(columnLoweredSound);
			}
		}
	}

	/// Called when the player un-triggers us.
	void OnTriggerExit(Collider other)
	{
		if(other.name != "Harpoon Prefab(Clone)")
		{
			if(pressed)
			{
				pressed = false;

				Color col = new Color(1.0f, 0.0f, 0.0f);
				button.GetComponent<Renderer>().material.SetColor("_Color", col);
				button.GetComponent<Renderer>().material.SetColor("_EmissionColor", col);

				buttonLight.color = col;

				columnSound.PlayOneShot(columnRaisedSound);
			}
		}
	}
}
