using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : GameManager<Inventory> {
	
	//Listの宣言
	public List<int> itemlist1= new List<int>();
	public List<int> itemlist2= new List<int>();

	public void AddItem(Item.ItemType type, int playerNum){
		//Player1かPlayer2かの場合分け
		if (playerNum == 1) {
			if (itemlist1.Count <= 1) {
				itemlist1.Add ((int)type);
			} else if (itemlist1.Count >= 2) {
				itemlist1.RemoveAt (0);
				itemlist1.Add ((int)type);
			}
		} else if (playerNum == 2) {
			if (itemlist2.Count <= 1) {
				itemlist2.Add ((int)type);
			} else if (itemlist2.Count >= 2) {
				itemlist2.RemoveAt (0);
				itemlist2.Add ((int)type);
			}
		}
	}
}
