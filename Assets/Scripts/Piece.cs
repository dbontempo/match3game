using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour
{
	public float speed = 0.1F;
	public BoardSpot mySpot;
	public Board board;

	private Animator animator;

	public int Color;
	// Use this for initialization
	void Start ()
	{
		animator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void OnMouseDown ()
	{
		board.CheckMatches (mySpot);
//		Debug.Log("Touched");
	}

	public void RemovePiece() {
		if (animator != null) {
			animator.Play ("Remove");
		} else {
			DestroyPiece ();
		}
	}

	public void DestroyPiece ()
	{
		mySpot = null;
		board = null;
		Destroy (this.gameObject);
	}
}
