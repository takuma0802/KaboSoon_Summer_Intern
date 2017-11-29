using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : GameManager<ItemUse> {

	public void useItem1(int itemNum, int itemUseNum){
		if (itemNum == 0) {
			Inventory.Instance.itemlist1.RemoveAt (itemUseNum);
			ItemContents.Instance.BigBallItem ();

		} else if (itemNum == 1) {
			Inventory.Instance.itemlist1.RemoveAt (itemUseNum);
			ItemContents.Instance.SpeedUpBallItem ();

		} else if (itemNum == 2) {
			Inventory.Instance.itemlist1.RemoveAt (itemUseNum);
			ItemContents.Instance.SpeedUpRacket(1);

		} else if (itemNum == 3) {
			Inventory.Instance.itemlist1.RemoveAt (itemUseNum);
			ItemContents.Instance.SmallEnemyRacket(1);

		} else if (itemNum == 4) {
			Inventory.Instance.itemlist1.RemoveAt (itemUseNum);
			ItemContents.Instance.Recovery(1);

		} else if (itemNum == 5) {
			Inventory.Instance.itemlist1.RemoveAt (itemUseNum);
			ItemContents.Instance.randomItem(1);

		} else {
			return;
		}
	}

	public void useItem2(int itemNum, int itemUseNum){
		if (itemNum == 0) {
			Inventory.Instance.itemlist2.RemoveAt (itemUseNum);
			ItemContents.Instance.BigBallItem ();

		} else if (itemNum == 1) {
			Inventory.Instance.itemlist2.RemoveAt (itemUseNum);
			ItemContents.Instance.SpeedUpBallItem ();

		} else if (itemNum == 2) {
			Inventory.Instance.itemlist2.RemoveAt (itemUseNum);
			ItemContents.Instance.SpeedUpRacket(2);

		} else if (itemNum == 3) {
			Inventory.Instance.itemlist2.RemoveAt (itemUseNum);
			ItemContents.Instance.SmallEnemyRacket(2);

		} else if (itemNum == 4) {
			Inventory.Instance.itemlist2.RemoveAt (itemUseNum);
			ItemContents.Instance.Recovery(2);

		} else if (itemNum == 5) {
			Inventory.Instance.itemlist2.RemoveAt (itemUseNum);
			ItemContents.Instance.randomItem(2);

		} else {
			return;
		}
	}
}
