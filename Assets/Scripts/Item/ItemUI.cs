using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : GameManager<ItemUI> {

	//アイテムImage
	[SerializeField] private Image item1_P1,item2_P1,item1_P2,item2_P2;
	[SerializeField] private Sprite _noneImage;

	// Use this for initialization
	void Start () {
		item1_P1 = GameObject.Find ("Canvas/Item_P1/item1_P1").GetComponent<Image>();
		item2_P1 = GameObject.Find ("Canvas/Item_P1/item2_P1").GetComponent<Image>();
		item1_P2 = GameObject.Find ("Canvas/Item_P2/item1_P2").GetComponent<Image>();
		item2_P2 = GameObject.Find ("Canvas/Item_P2/item2_P2").GetComponent<Image>();

		item1_P1.sprite = _noneImage;
		item2_P1.sprite = _noneImage;
		item1_P2.sprite = _noneImage;
		item2_P2.sprite = _noneImage;
	}

	public void AddItemUI(int playerNumber){
		if (playerNumber == 1) {
			if (Inventory.Instance.itemlist1.Count >= 2) {
				item1_P1.sprite = Resources.Load<Sprite> ("Items/" + Inventory.Instance.itemlist1 [0]);
				item2_P1.sprite = Resources.Load<Sprite> ("Items/" + Inventory.Instance.itemlist1 [1]);
			} else if (Inventory.Instance.itemlist1.Count == 1) {
				item1_P1.sprite = Resources.Load<Sprite> ("Items/" + Inventory.Instance.itemlist1 [0]);
			}
		} else if (playerNumber == 2) {
			if (Inventory.Instance.itemlist2.Count >= 1) {
				item1_P2.sprite = Resources.Load<Sprite> ("Items/" + Inventory.Instance.itemlist2 [0]);
				item2_P2.sprite = Resources.Load<Sprite> ("Items/" + Inventory.Instance.itemlist2 [1]);
			} else if (Inventory.Instance.itemlist2.Count == 0) {
				item1_P2.sprite = Resources.Load<Sprite> ("Items/" + Inventory.Instance.itemlist2 [0]);
			}
		}
	}

	public void UseItemUI(int playerNumber){
		if (playerNumber == 1) {
			if (Inventory.Instance.itemlist1.Count == 0) {
				item1_P1.sprite = _noneImage;
				item2_P1.sprite = _noneImage;
			} else if (Inventory.Instance.itemlist1.Count == 1){
				item1_P1.sprite = Resources.Load<Sprite> ("Items/" + Inventory.Instance.itemlist1 [0]);
				item2_P1.sprite = _noneImage;
			}
		} else if (playerNumber == 2) {
			if (Inventory.Instance.itemlist2.Count == 0) {
				item1_P2.sprite = _noneImage;
				item2_P2.sprite = _noneImage;
			} else if (Inventory.Instance.itemlist2.Count == 1){
				item1_P2.sprite = Resources.Load<Sprite> ("Items/" + Inventory.Instance.itemlist2 [0]);
				item2_P2.sprite = _noneImage;
			}
		}
	}

}
