using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public Rigidbody rb;
	public float speed = 500f;
	public int health = 5;
	private int score = 0;

	void Update()
	{
		if (health == 0)
		{
			Debug.Log("Game Over!");
			health = 5;
			score = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
	void FixedUpdate()
	{
		if (Input.GetKey("w"))
		{
			rb.AddForce(0, 0, speed * Time.deltaTime);
		}
		if (Input.GetKey("a"))
		{
			rb.AddForce((-1 * speed) * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey("s"))
		{
			rb.AddForce(0, 0, (-1 * speed) * Time.deltaTime);
		}
		if (Input.GetKey("d"))
		{
			rb.AddForce(speed * Time.deltaTime, 0, 0);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Pickup")
		{
			score += 1;
			Debug.Log("Score: " + score);
			Destroy(other.gameObject);
		}
		if (other.tag == "Trap")
		{
			health -= 1;
			Debug.Log("Health: " + health);
		}
		if (other.tag == "Goal")
		{
			Debug.Log("You win!");
		}
	}
}
