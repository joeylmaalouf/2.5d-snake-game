using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public float speed;
	public GameObject player;

	void FixedUpdate()
	{
		float horiz  = 1.0f * (this.player.transform.position.x > this.transform.position.x ? 1 : -1);
		float vert = 1.0f * (this.player.transform.position.z > this.transform.position.z ? 1 : -1);
		Vector3 movement = new Vector3
		(
			horiz,
			0.0f,
			vert
		);
		this.rigidbody.AddForce(movement * this.speed * Time.deltaTime);
	}
}
