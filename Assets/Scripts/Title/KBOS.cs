using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KBOS : MonoBehaviour {
	[SerializeField] private GameObject Logo;
	[SerializeField] private GameObject Panel;
	[SerializeField] private GameObject StartButton;
	[SerializeField] private GameObject RuleButton;
    [SerializeField] private GameObject btnController;

    public float alfa = 0.01f;
	public float alfa2 = 0.01f;
	public float alfa3 = 0.01f;
	bool flag = true;
	public static bool kbsFlag = false;
	float rL, gL, bL, aL, rP, gP, bP, aP, rB, gB, bB, aB;

	// Use this for initialization
	void Start () {
        btnController.GetComponent<ButtonController>().useFlag = false;
        rL = Logo.GetComponent<Image> ().color.r;
		gL = Logo.GetComponent<Image> ().color.g;
		bL = Logo.GetComponent<Image> ().color.b;
		aL = Logo.GetComponent<Image> ().color.a;
		rP = Panel.GetComponent<Image> ().color.r;
		gP = Panel.GetComponent<Image> ().color.g;
		bP = Panel.GetComponent<Image> ().color.b;
		aP = Panel.GetComponent<Image> ().color.a;
		rB = StartButton.GetComponent<Image> ().color.r;
		gB = StartButton.GetComponent<Image> ().color.g;
		bB = StartButton.GetComponent<Image> ().color.b;
		aB = StartButton.GetComponent<Image> ().color.a;
	}
	
	// Update is called once per frame
	void Update () {

		if (flag == true) {
			aL += alfa;
			Logo.GetComponent<Image> ().color = new Vector4(rL,gL,bL,aL);
			
			if(aL > 1.5f){

				alfa *= -1;
			}
			if(aL < 0.0f){

				alfa = 0;
				flag = false;
			}
		} else if (flag == false) {
			aP -= alfa2;
			Panel.GetComponent<Image> ().color = new Vector4(rP,gP,bP,aP);
			
			if(aP < 0.0f){

				alfa2 = 0;
				aP = 0;
			}
		} 

		if(kbsFlag == true){


            aB += alfa3;
			StartButton.GetComponent<Image> ().color = new Vector4(rB,gB,bB,aB);
			RuleButton.GetComponent<Image> ().color = new Vector4(rB,gB,bB,aB);
			
			if(aB > 1.1f){

				alfa3 = 0;
				aB = 1.0f;
				ButtonColor.useFlag = true;
                btnController.GetComponent<ButtonController>().useFlag = true;
				kbsFlag = false;
				alfa3 = 0.01f;

            }

		}



	}
}
