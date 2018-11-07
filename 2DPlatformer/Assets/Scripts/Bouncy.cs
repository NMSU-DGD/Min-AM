using UnityEngine;
using System.Collections;

public class Bouncy : MonoBehaviour {

	public float bouncy;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D (Collision2D other)  {
		other.rigidbody.AddForce (Vector2.up * bouncy, ForceMode2D.Impulse);

		//if (other.gameObject.tag == "JumpPad") {
		//	this.rb.AddForce(new Vector2(0f, jumpForce));
		//}
	}
}
