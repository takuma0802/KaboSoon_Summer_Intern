using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColorChange : MonoBehaviour {
	[SerializeField] private Material _player1Color;
	[SerializeField] private Material _player2Color;
	[SerializeField] private Material _noneColor;

	private MeshRenderer _meshComponent;

	// Use this for initialization
	void Start () {
		_meshComponent = GetComponent<MeshRenderer> ();
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player1") {
			_meshComponent.material = _player1Color;
		} 
		if (other.gameObject.tag == "Player2") {
			_meshComponent.material = _player2Color;
		} 
		if (other.gameObject.tag == "Goal_Player1" || other.gameObject.tag == "Goal_Player2") {
			_meshComponent.material = _noneColor;
		}
	}

}
