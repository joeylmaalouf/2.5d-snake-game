using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public GameObject enemy;
	public GUIText scoreText;
	public GUIText statusText;
	private bool alive;
	private int score;

	void Start()
	{
		this.alive = true;
		this.score = 0;
		this.UpdateText();
		this.statusText.text = "";
	}

	void FixedUpdate()
	{
		if (this.alive)
		{
			Vector3 movement = new Vector3
			(
				Input.GetAxis("Horizontal"),
				0.0f,
				Input.GetAxis("Vertical")
			);
			this.rigidbody.AddForce(movement * this.speed * Time.deltaTime);
		}
		else
		{
			this.rigidbody.velocity = Vector3.zero;
			this.rigidbody.angularVelocity = Vector3.zero;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp")
		{
			other.gameObject.transform.position = new Vector3
			(
				Random.Range(-11.1f, 11.1f),
				0.5f,
				Random.Range(-11.1f, 11.1f)
			);
			++this.score;
			this.UpdateText();
			this.audio.Play();
			this.speed += 20;
			if (this.score % 2 == 0)
				Instantiate
				(
					enemy,
					new Vector3
					(
						Random.Range(-11.1f, 11.1f),
						0.5f,
						Random.Range(-11.1f, 11.1f)
					),
					Quaternion.identity
				);
		}
		else if (other.gameObject.tag == "Enemy")
		{
			this.alive = false;
			this.statusText.text = "You Lose!\nBetter luck next time!";
		}
	}

	void UpdateText()
	{
		this.scoreText.text = "Score: " + this.score.ToString();
		if (this.score >= 100) this.statusText.text = "You Win!\nCongratulations!";
	}
}
