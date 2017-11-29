using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPanelChange : MonoBehaviour {

	[SerializeField] private Material _player1Color;
	[SerializeField] private Material _player2Color;

	private MeshRenderer _meshComponent;

	void Start(){
		_meshComponent = GetComponent<MeshRenderer> ();

		if (this.CompareTag("SpecialPanel_Player1")) {
			ChangePanelColor (1);
		}
		if (this.CompareTag("SpecialPanel_Player2")) {
			ChangePanelColor (2);
		}
	}
		
	public void ChangePanelColor(int playerNumber){
		if (playerNumber == 1) {
			this.tag = "SpecialPanel_Player1";
			_meshComponent.material = _player1Color;
		} else if (playerNumber == 2) {
			this.tag = "SpecialPanel_Player2";
			_meshComponent.material = _player2Color;
		}
	}
}