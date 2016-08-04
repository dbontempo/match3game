using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour
{
	public float speed = 0.1F;
	public BoardSpot mySpot;
	public Board board;

	public int Color;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void OnMouseDown ()
	{
		board.CheckMatches (mySpot);
//		Debug.Log("Touched");
	}

	public void DestroyPiece ()
	{
		mySpot = null;
		board = null;
		Destroy (this.gameObject);
	}
}
