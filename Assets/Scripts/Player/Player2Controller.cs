using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : GameManager<Player2Controller>
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
	void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		_audioClip = Resources.Load<AudioClip>("Audio/ItemUse");
	}

	// Update is called once per frame
	void Update()
	{
		if (this.CompareTag("Player2"))
		{
			if (Input.GetButtonDown(this.itemButtonL))
			{
				if (Inventory.Instance.itemlist2.Count >= 1)
				{
					ItemUse.Instance.useItem2(Inventory.Instance.itemlist2[0], 0);
					ItemUI.Instance.UseItemUI(2);
					_audioSource.PlayOneShot(_audioClip);
				}
				else
				{
					//押しても何もない。
					print("Player2はアイテムを持ってないよ！！");
					return;
				}
			}
			else if (Input.GetButtonDown(this.itemButtonR))
			{
				if (Inventory.Instance.itemlist2.Count == 2)
				{
					ItemUse.Instance.useItem2(Inventory.Instance.itemlist2[1], 1);
					ItemUI.Instance.UseItemUI(2);
					_audioSource.PlayOneShot(_audioClip);
				}
				else if (Inventory.Instance.itemlist2.Count == 1)
				{
					print("逆側のボタンを押してね！");
				}
				else
				{
					//押しても何もない。
					print("Player2はアイテムを持ってないよ！！");
					return;
				}
			}
		}
	}

	void LateUpdate()
	{
		float fXMove = Input.GetAxis(this.moveAxisX);
		transform.Translate(Vector3.right * fXMove * SPEED * Time.deltaTime);

		float fZMove = Input.GetAxis(this.moveAxisZ);
		transform.Translate(Vector3.back * fZMove * SPEED * Time.deltaTime);
	}
}
