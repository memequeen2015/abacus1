using UnityEngine;
using System.Collections;

public class Spawnpoint : MonoBehaviour
{
	public GameObject Player;

	void Awake ()
	{
		//Set Player
		Player = GameObject.FindGameObjectWithTag ("Player");
		//Spawn the player
		SpawnPlayer ();
	}

	void SpawnPlayer ()
	{
		//Move player to spawn position
		Player.transform.position = transform.position;
		//Turns script off
		this.enabled = false;
	}
}
