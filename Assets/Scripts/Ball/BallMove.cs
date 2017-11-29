using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

	public float _ballSpeed = 30.0f;

	[SerializeField] private Material _player1Color;
	[SerializeField] private Material _player2Color;
	[SerializeField] private Material _noneColor;
	private MeshRenderer _meshComponent;

	AudioSource _audioSource;
	AudioClip _audioClip;

	void Start () {
		_meshComponent = GetComponent<MeshRenderer> ();
		_audioSource = GetComponent<AudioSource> ();
		_audioClip = Resources.Load<AudioClip>("Audio/Ball");
	}

	public void BollMoveMethod(){
		GetComponent<Rigidbody> ().AddForce ((transform.forward + transform.right) * _ballSpeed, ForceMode.Impulse);
	}

	void OnCollisionEnter(Collision other){
		Rigidbody rigidbody = GetComponent<Rigidbody> ();
		rigidbody.velocity = rigidbody.velocity.normalized * _ballSpeed;

		if (other.gameObject.CompareTag("Player1")) {
			this.gameObject.tag = "Ball_Player1";
			_meshComponent.material = _player1Color;
			_audioSource.PlayOneShot (_audioClip);
		} 
		else if (other.gameObject.CompareTag("Player2")) {
			this.gameObject.tag = "Ball_Player2";
			_meshComponent.material = _player2Color;
			_audioSource.PlayOneShot (_audioClip);
		}
	}
	
	void OnTriggerEnter(Collider other){
		if (this.gameObject.CompareTag("Ball_none")) {
			return;
		}

		if (this.gameObject.CompareTag("Ball_Player1")) {
			NormalPanelChange panel = other.gameObject.GetComponent<NormalPanelChange> ();
			SpecialPanelChange specialPanel = other.gameObject.GetComponent<SpecialPanelChange> ();
			if (panel) {
				panel.ChangePanelColor (1);
			} else if (specialPanel) {
				specialPanel.ChangePanelColor (1);
			} else{
				return;
			}
		}

		if (this.gameObject.CompareTag("Ball_Player2")) {
			NormalPanelChange panel = other.gameObject.GetComponent<NormalPanelChange> ();
			SpecialPanelChange specialPanel = other.gameObject.GetComponent<SpecialPanelChange> ();
			if (panel) {
				panel.ChangePanelColor (2);
			} else if (specialPanel) {
				specialPanel.ChangePanelColor (2);
			} else{
				return;
			}
		}
	}
}