using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public GameObject enemy;
	public GUIText scoreText;
	public GUIText statusText;
	private int score;

	void Start()
	{
		this.score = 0;
		this.UpdateText();
		this.statusText.text = "";
	}

	void FixedUpdate()
	{
		Vector3 movement = new Vector3
		(
			Input.GetAxis("Horizontal"),
			0.0f,
			Input.GetAxis("Vertical")
		);
		this.rigidbody.AddForce(movement * this.speed * Time.deltaTime);
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
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Time.timeScale = 0.0f;
			this.statusText.text = "You Lose!\nBetter luck next time!";
		}
	}

	void UpdateText()
	{
		this.scoreText.text = "Score: " + this.score.ToString();
		if (this.score >= 100) this.statusText.text = "You Win!\nCongratulations!";
	}
}
