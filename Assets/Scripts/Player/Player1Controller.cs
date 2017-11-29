using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : GameManager<Player1Controller>
{
	[SerializeField] private string moveAxisX;
	[SerializeField] private string moveAxisZ;
	[SerializeField] private string itemButtonL;
	[SerializeField] private string itemButtonR;

	public float SPEED { get; set; } = 20f;
	// Use this for initialization
	AudioSource _audioSource;
	AudioClip _audioClip;

	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource> ();
		_audioClip = Resources.Load<AudioClip>("Audio/ItemUse");
	}

	// Update is called once per frame
	void Update () {
		if (this.CompareTag("Player1")) {
			if (Input.GetButtonDown(this.itemButtonL)) {
				if (Inventory.Instance.itemlist1.Count >= 1) {
					ItemUse.Instance.useItem1 (Inventory.Instance.itemlist1 [0], 0);
					ItemUI.Instance.UseItemUI (1);
					_audioSource.PlayOneShot (_audioClip);
				} else {
					//押しても何もない。
					print ("Player1はアイテムを持ってないよ！！");
					return;
				}
			} else if (Input.GetButtonDown(this.itemButtonR)) {
				if (Inventory.Instance.itemlist1.Count == 2) {
					ItemUse.Instance.useItem1 (Inventory.Instance.itemlist1 [1], 1);
					ItemUI.Instance.UseItemUI (1);
					_audioSource.PlayOneShot (_audioClip);
				}else if (Inventory.Instance.itemlist1.Count == 1)
				{
					print("逆側のボタンを押してね！");
				} else {
					//押しても何もない。
					print("Player1はアイテムを持ってないよ！！");
					return;
				}
			}
		}
	}

	void LateUpdate(){
		float fXMove = Input.GetAxis(this.moveAxisX);
		transform.Translate(Vector3.right * fXMove * SPEED * Time.deltaTime);

		float fZMove = Input.GetAxis(this.moveAxisZ);
		transform.Translate(Vector3.back * fZMove * SPEED * Time.deltaTime);
	}
}
