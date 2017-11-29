using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {
	
	[SerializeField] private GameObject _ballPrefab;

	void OnTriggerEnter(Collider other){
		if (this.gameObject.CompareTag("Goal_Player1")) {
			if (other.gameObject.CompareTag("Ball_none")){
				other.gameObject.tag = "Ball_Player2";
				StartCoroutine (InstantiateBall (other,1));
			}
			else if (other.gameObject.CompareTag("Ball_Player2")) {
				StartCoroutine (InstantiateBall (other,1));
			} 
			else if (other.gameObject.CompareTag("Ball_Player1")) {
				other.gameObject.tag = "Ball_Player2";
				StartCoroutine (InstantiateBall (other,1));
			}
		} 
		else if (this.gameObject.CompareTag("Goal_Player2")) {
			if (other.gameObject.CompareTag("Ball_none")) {
				other.gameObject.tag = "Ball_Player1";
				StartCoroutine (InstantiateBall (other,-1));
			}
			else if (other.gameObject.CompareTag("Ball_Player1")) {
				StartCoroutine (InstantiateBall (other,-1));
			} 
			else if (other.gameObject.CompareTag("Ball_Player2")) {
				other.gameObject.tag = "Ball_Player1";
				StartCoroutine (InstantiateBall (other,-1));
			}
		}
	}

	//player1がゴールを入れられる：playerDirectionが正
	//player2がゴールを入れられる：playerDirectionが負
	public IEnumerator InstantiateBall(Collider other, int playerDirection){
		float bomScale = Random.Range (3, 11);
		float bomTime = Random.Range (0.1f, 0.2f);
		yield return new WaitForSeconds (bomTime);
		other.transform.localScale = new Vector3 (bomScale, bomScale, bomScale);
		Destroy (other.gameObject, 0.03f);
		yield return new WaitForSeconds (2.0f);
		GameObject ballPrefab = Instantiate (_ballPrefab);
		ballPrefab.GetComponent<Rigidbody> ().AddForce ((transform.right * playerDirection) * 15.0f, ForceMode.Impulse);
	}

}
