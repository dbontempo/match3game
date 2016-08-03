using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour {
	public float speed = 0.1F;
	public BoardSpot mySpot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseDown () {
//		Debug.Log("Touched");
		mySpot = null;
		Destroy(this.gameObject);
	}
}
