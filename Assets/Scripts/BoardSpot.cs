using UnityEngine;
using System.Collections;

public class BoardSpot : MonoBehaviour {
	public Piece myPiece;
	private int row;
	private int col;

	// Use this for initialization
	void Start () {
	
	}

	public void SetLocation(int col, int row) {
		this.col = col;
		this.row = row;
		this.gameObject.transform.position = new Vector3 (col - 3.5f, row - 3.5f, 4f);
	}

//	public void SetSpotArt(GameObject spotArt) {
//		spotArt.gameObject.transform.SetParent(this.transform);
//	}

	public void SetPiece(Piece piece) {
		myPiece = piece;
		myPiece.transform.position = new Vector2 (col - 3.5f, row - 3.5f);
	}
}
