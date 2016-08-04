using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Board : MonoBehaviour
{
	public Piece[] pieces;
	public BoardSpot[,] boardSpots;

	public BoardSpot spotPrefab;

	//    int rows = 8;
	//    int cols = 8;

	public static int maxRows = 8;
	public static int maxCols = 8;
	public static int matchSize = 3;

	//    public GameBoard g = new GameBoard(maxRows, maxCols);
	public List<BoardSpot> rows = new List<BoardSpot> ();
	public List<BoardSpot> cols = new List<BoardSpot> ();

	public static System.Random r = new System.Random (Guid.NewGuid ().GetHashCode ());


	// Use this for initialization
	void Start ()
	{
		BuildBoard ();
		PopulateBoard ();
	}

	public void CheckMatches (BoardSpot spot)
	{
		rows = new List<BoardSpot> ();
		cols = new List<BoardSpot> ();
		CheckNeighbors (spot.col, spot.row, spot.myPiece.Color);
	}


	private void BuildBoard ()
	{
		boardSpots = new BoardSpot[maxCols, maxRows];
		for (int row = 0; row < maxRows; ++row) {
			for (int col = 0; col < maxCols; ++col) {
				//                boardSpots [col, row] = new BoardSpot ();
				boardSpots [col, row] = Instantiate (spotPrefab);
				boardSpots [col, row].SetLocation (col, row);
				//                boardSpots [col, row].SetSpotArt (spot);
			}
		}
	}

	private void PopulateBoard ()
	{
		for (int row = 0; row < maxRows; ++row) {
			for (int col = 0; col < maxCols; ++col) {
				Piece piece = GetPiece ();
				boardSpots [col, row].SetPiece (piece);
			}
		}
	}

	private Piece GetPiece ()
	{
		int random = r.Next (0, pieces.Length);
		Piece piece = Instantiate (pieces [random]);
		piece.Color = random;
		piece.board = this;
		return piece;
	}

	public void CheckNeighbors (int col, int row, int color)
	{
		BoardSpot p = boardSpots [col, row];// recusively check the neighbors

		CheckWestNeighbor (p.col - 1, p.row, p.myPiece.Color);
		CheckEastNeighbor (p.col + 1, p.row, p.myPiece.Color);
		CheckNorthNeighbor (p.col, p.row + 1, p.myPiece.Color);
		CheckSouthNeighbor (p.col, p.row - 1, p.myPiece.Color);
		// if the row count > matchSize
		if (rows.Count >= matchSize - 1) {
			rows.Add (p);
			Debug.Log ("Found a Match" + rows.ToString ());
			foreach (BoardSpot spot in rows) {
				spot.DestroyPiece ();
			}
		}
		if (cols.Count >= matchSize - 1) {
			if (rows.Count < matchSize) {
				cols.Add (p);
			}
			Debug.Log ("Found a Match" + cols.ToString ());
			foreach (BoardSpot spot in cols) {
				spot.DestroyPiece ();
			}
		}
	}

	public void CheckWestNeighbor (int col, int row, int color)
	{
		// check boundary
		if (col < 0)
			return;
		BoardSpot p = boardSpots [col, row]; // recusively check the neighbors

		if (p.myPiece != null && p.myPiece.Color != color)
			return; // mark as checked

		rows.Add (p); // continue checking
		CheckWestNeighbor (col - 1, p.row, color);
	}

	public void CheckEastNeighbor (int col, int row, int color)
	{
		if (col >= maxCols)
			return;
		BoardSpot p = boardSpots [col, row]; // recusively check the neighbors
		if (p.myPiece != null && p.myPiece.Color != color)
			return;
		rows.Add (p);
		CheckEastNeighbor (col + 1, p.row, color);
	}

	public void CheckSouthNeighbor (int col, int row, int color)
	{
		if (row < 0)
			return;
		BoardSpot p = boardSpots [col, row]; // recusively check the neighbors
		if (p.myPiece != null && p.myPiece.Color != color)
			return;
		cols.Add (p);
		CheckSouthNeighbor (p.col, row - 1, color);
	}

	public void CheckNorthNeighbor (int col, int row, int color)
	{
		if (row >= maxRows)
			return;
		BoardSpot p = boardSpots [col, row];// recusively check the neighbors
		if (p.myPiece != null && p.myPiece.Color != color)
			return;
		cols.Add (p);
		CheckNorthNeighbor (p.col, row + 1, color);
	}
}