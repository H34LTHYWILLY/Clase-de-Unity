using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DoorScript
{
	[RequireComponent(typeof(AudioSource))]


public class DoorAudio : MonoBehaviour {
	public bool open;
	public AudioSource asource;
	public AudioClip openDoor,closeDoor;
	// Use this for initialization
	void Start () {
		asource = GetComponent<AudioSource> ();
	}


	public void OpenDoor(){
		open =!open;
		asource.clip = open?openDoor:closeDoor;
		asource.Play ();
	}
}
}