using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContents : GameManager<ItemContents> {

	public void BigBallItem(){
		print ("BigBallItemを使ったよ！");
		GameObject Ball = GameObject.Find ("Ball");
		if (Ball) {
			Ball.transform.localScale = new Vector3 (3.0f, 3.0f, 3.0f);
			StartCoroutine ("NotBigBall");
		} else {
			GameObject cloneBall = GameObject.Find ("Ball(Clone)");
			cloneBall.transform.localScale = new Vector3 (3.0f, 3.0f, 3.0f);
			StartCoroutine ("NotBigBall");
		}
	}

	IEnumerator NotBigBall(){
		yield return new WaitForSeconds (2.0f);
		GameObject Ball = GameObject.Find ("Ball");
		if (Ball) {
			Ball.transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
		} else {
			GameObject cloneBall = GameObject.Find ("Ball(Clone)");
			cloneBall.transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
		}
	}


	public void SpeedUpBallItem(){
		print ("SpeedUpBallItemを使ったよ！");
		GameObject Ball = GameObject.Find ("Ball");
		if (Ball) {
			BallMove blm = Ball.GetComponent<BallMove> ();
			blm._ballSpeed *= 1.5f; 
			StartCoroutine ("NotSpeedUpBallItem");
		} else {
			GameObject cloneBall = GameObject.Find ("Ball(Clone)");
			BallMove blm = cloneBall.GetComponent<BallMove> ();
			blm._ballSpeed *= 1.5f; 
			StartCoroutine ("NotSpeedUpBallItem");
		}
	}

	IEnumerator NotSpeedUpBallItem(){
		yield return new WaitForSeconds (0.5f);
		GameObject Ball = GameObject.Find ("Ball");
		if (Ball) {
			BallMove blm = Ball.GetComponent<BallMove> ();
			blm._ballSpeed = 30.0f;
		} else {
			GameObject cloneBall = GameObject.Find ("Ball(Clone)");
			BallMove blm = cloneBall.GetComponent<BallMove> ();
			blm._ballSpeed = 30.0f;
		}
	}
		

	public void SpeedUpRacket(int playerNum){
		print ("SpeedUpRacketItemを使ったよ！");
		if (playerNum == 1) {
			Player1Controller.Instance.SPEED = 50f;
			//--何秒か後に元に戻す処理--
			StartCoroutine("NotSpeedUpRacket",3);
			//----------------------

		}else if(playerNum == 2){
			Player2Controller.Instance.SPEED = 50f;
			//--何秒か後に元に戻す処理--
			StartCoroutine("NotSpeedUpRacket",2);
			//----------------------
		}
	}

	IEnumerator NotSpeedUpRacket(int playerNum){
		yield return new WaitForSeconds (2.0f);
		if (playerNum == 1) {
			Player1Controller.Instance.SPEED = 30f;

		}else if(playerNum == 2){
			Player2Controller.Instance.SPEED = 30f;
		}
	}


	public void SmallEnemyRacket(int playerNum){
		print ("SmallEnemyRacketItemを使ったよ！");
		if (playerNum == 1) {
			GameObject Player = GameObject.FindGameObjectWithTag ("Player2");
			Player.transform.localScale = new Vector3 (0.5f,1.0f,1.0f);;
			//--何秒か後に元に戻す処理--
			StartCoroutine("NotSmallEnemyRacket",1);
			//----------------------
		}else if(playerNum == 2){
			GameObject Player = GameObject.FindGameObjectWithTag ("Player1");
			Player.transform.localScale = new Vector3 (0.5f,1.0f,1.0f);;
			//--何秒か後に元に戻す処理--
			StartCoroutine("NotSmallEnemyRacket",2);
			//----------------------
		}
	}

	IEnumerator NotSmallEnemyRacket(int playerNum){
		yield return new WaitForSeconds (2.0f);
		if (playerNum == 1) {
			GameObject Player = GameObject.FindGameObjectWithTag ("Player2");
			Player.transform.localScale = new Vector3 (1.0f,1.0f,1.0f);;

		}else if(playerNum == 2){
			GameObject Player = GameObject.FindGameObjectWithTag ("Player1");
			Player.transform.localScale = new Vector3 (1.0f,1.0f,1.0f);;

		}
	}


	//playerNumberはヒールアイテムを使ったプレイヤーの番号
	//アイテムを使った方のパネル全てを配列に入れ、ランダムに色を変える
	//残りPanel数がhealPointよりも少ない場合は、全て色を変える
	public void Recovery(int playerNumber){
		print ("RecoveryItemを使ったよ！");
		int _healPoint = 44;

		if (playerNumber == 1) {
			for (int i = 0; i < _healPoint; i++) {
				GameObject[] SPs_P2 = GameObject.FindGameObjectsWithTag ("SpecialPanel_Player2");
				if (SPs_P2.Length > 0) {
					GameObject SP_P2 = SPs_P2 [Random.Range (0, SPs_P2.Length)];
					SP_P2.GetComponent<SpecialPanelChange> ().ChangePanelColor (1);
				} else {
					return;
				}
			}
		} else if (playerNumber == 2) {
			for (int i = 0; i < _healPoint; i++) {
				GameObject[] SPs_P1 = GameObject.FindGameObjectsWithTag ("SpecialPanel_Player1");
				if (SPs_P1.Length > 0) {
					GameObject SP_P1 = SPs_P1 [Random.Range (0, SPs_P1.Length)];				
					SP_P1.GetComponent<SpecialPanelChange> ().ChangePanelColor (2);
				} else {
					return;
				}
			}
		}
	}


	public void randomItem(int playerNum){
		print ("RandomItemを使ったよ！");
		int randNum = Random.Range (0,5);

		if (randNum == 0) {
			//BigBallItem
			BigBallItem ();
		} else if (randNum == 1) {
			//SpeedUpBallItem
			SpeedUpBallItem ();			
		} else if (randNum == 2) {
			//SpeedUpRacket
			SpeedUpRacket (playerNum);
		} else if (randNum == 3) {
		//SmallEnemyRacket
			SmallEnemyRacket(playerNum);
		} else if (randNum == 4) {
		//Recovery
			Recovery(playerNum);
		}
	}
}
