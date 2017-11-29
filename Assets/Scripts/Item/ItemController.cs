using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {
	public Item.ItemType itemType;
	AudioSource _audioSource;
	AudioClip _audioClip;

	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource> ();
		_audioClip = Resources.Load<AudioClip>("Audio/ItemGet");
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Ball_Player1") {
			Inventory.Instance.AddItem (itemType,1);
			ItemUI.Instance.AddItemUI(1);
			_audioSource.PlayOneShot (_audioClip);
			Destroy (gameObject);
		}else if(other.tag == "Ball_Player2"){
			Inventory.Instance.AddItem (itemType,2);
			ItemUI.Instance.AddItemUI (2);
			_audioSource.PlayOneShot (_audioClip);
			Destroy (gameObject);
		}

	}
}
