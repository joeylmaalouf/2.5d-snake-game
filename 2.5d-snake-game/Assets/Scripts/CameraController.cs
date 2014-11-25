using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public GameObject player;
	private Vector3 offset;

	void Start()
	{
		this.offset = this.transform.position;
	}

	void LateUpdate()
	{
		this.transform.position = this.player.transform.position + this.offset;
	}
}
