using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {
	public Piece[] pieces;
	public BoardSpot[,] boardSpots;
	public BoardSpot spotPrefab;

	int rows = 8;
	int cols = 8;

	// Use this for initialization
	void Start () {
		BuildBoard();
		PopulateBoard ();
	}


	private void BuildBoard () {
		boardSpots = new BoardSpot[cols, rows];
		for (int row = 0; row < rows; ++row) {
			for (int col = 0; col < cols; ++col) {
//				boardSpots [col, row] = new BoardSpot ();
				boardSpots [col, row] =  Instantiate(spotPrefab);
				boardSpots [col, row].SetLocation (col, row);
//				boardSpots [col, row].SetSpotArt (spot);
			}
		}
	}

	private void PopulateBoard() {
		for (int row = 0; row < rows; ++row) {
			for (int col = 0; col < cols; ++col) {
				Piece piece = GetPiece();
				boardSpots [col, row].SetPiece (piece);
			}
		}
	}

	private Piece GetPiece() {
		int random = Random.Range (0, pieces.Length);
		Piece piece = Instantiate(pieces[random]);
		return piece;
	}
}
