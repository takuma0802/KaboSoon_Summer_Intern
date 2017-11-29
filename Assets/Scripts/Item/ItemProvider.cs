using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProvider : MonoBehaviour {

	[SerializeField] GameObject[] _itemPrefabs;
	[SerializeField] private GameObject _itemField;
	float _itemFieldX;
	float _itemFieldZ;
	float _itemTime;

	// Use this for initialization
	void Start () {
		_itemFieldX = _itemField.GetComponent<Renderer> ().bounds.size.x;
		_itemFieldZ = _itemField.GetComponent<Renderer> ().bounds.size.z;
	}

	// Update is called once per frame
	void Update () {		
		_itemTime += Time.deltaTime;
		if ( _itemTime > 10) {
			Instantiate (_itemPrefabs[Random.Range(0,_itemPrefabs.Length)],_itemField.transform.position + new Vector3 (Random.Range (-_itemFieldX/2,_itemFieldX/2),2f,Random.Range (-_itemFieldZ/2, _itemFieldZ/2)),Quaternion.identity);
			_itemTime = 0f;
		}
	}
}
