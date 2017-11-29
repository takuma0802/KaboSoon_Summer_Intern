using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

	[SerializeField] private GameObject _normalPanelPrefab;
	[SerializeField] private GameObject _specialPanelPrefab;

	// Use this for initialization
	void Start () {
		for (int i = 0; i <= 10; i++) {
			for (int r = 0; r <= 39; r++) {
				GameObject specialPanel2 = Instantiate (_specialPanelPrefab, new Vector3 (-49.5f + i, -9.85f, 19.5f - r), Quaternion.identity);
				specialPanel2.tag = "SpecialPanel_Player2";
			}
		}
		for (int i = 0; i <= 79; i++) {
			for (int r = 0; r <= 39; r++) {
				Instantiate (_normalPanelPrefab, new Vector3 (-39.5f + i, 0.15f, 19.5f - r), Quaternion.identity);
			}
		}

		for (int i = 0; i <= 10; i++) {
			for (int r = 0; r <= 39; r++) {
				GameObject specialPanel1 = Instantiate (_specialPanelPrefab, new Vector3 (39.5f + i, -9.85f, 19.5f - r), Quaternion.identity);
				specialPanel1.tag = "SpecialPanel_Player1";
			}
		}
	}
}
