using UnityEngine;
using System.Collections;

public class Falloff : MonoBehaviour
{
	public GameObject Player;
	public GameObject Spawn;

	void Awake ()
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
		Spawn = GameObject.FindGameObjectWithTag ("Spawn");
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "Player")
		{
			Player.transform.position = Spawn.transform.position;
		}
	}

	void Update ()
	{
		transform.Rotate (Vector3.up);
		transform.Rotate (Vector3.down);
	}
}
