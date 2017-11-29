using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPanelChange : MonoBehaviour {

	[SerializeField] private Material _player1Color;
	[SerializeField] private Material _player2Color;

	private MeshRenderer _meshComponent;

	void Start(){
		_meshComponent = GetComponent<MeshRenderer> ();
	}

	public void ChangePanelColor(int playerNumber){
		if (playerNumber == 1) {
			_meshComponent.material = _player1Color;
			this.tag = "Panel_Player1";
		} else if (playerNumber == 2){
			_meshComponent.material = _player2Color;
			this.tag = "Panel_Player2";
		}
	}
}
