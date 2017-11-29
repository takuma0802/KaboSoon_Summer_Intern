using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	[SerializeField] private Text _NP_P1Text;
	[SerializeField] private Text _SP_P1Text;
	[SerializeField] private Text _NP_P2Text;
	[SerializeField] private Text _SP_P2Text;

	public void CulcPanelNum(){
		GameObject[] SP_P1 = GameObject.FindGameObjectsWithTag ("SpecialPanel_Player1");
		PlayerPrefs.SetInt ("SP_P1", SP_P1.Length);

		GameObject[] SP_P2 = GameObject.FindGameObjectsWithTag ("SpecialPanel_Player2");
		PlayerPrefs.SetInt ("SP_P2", SP_P2.Length);

		GameObject[] NP_P1 = GameObject.FindGameObjectsWithTag ("Panel_Player1");
		PlayerPrefs.SetInt ("NP_P1", NP_P1.Length);

		GameObject[] NP_P2 = GameObject.FindGameObjectsWithTag ("Panel_Player2");
		PlayerPrefs.SetInt ("NP_P2", NP_P2.Length);

		_NP_P1Text.text = "Normal\r\n" + PlayerPrefs.GetInt ("NP_P1");
		_SP_P1Text.text = "Special\r\n" + PlayerPrefs.GetInt ("SP_P1");
		_NP_P2Text.text = "Normal\r\n" + PlayerPrefs.GetInt ("NP_P2");
		_SP_P2Text.text = "Special\r\n" + PlayerPrefs.GetInt ("SP_P2");
	}
}
