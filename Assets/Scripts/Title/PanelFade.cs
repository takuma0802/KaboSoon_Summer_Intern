using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelFade : MonoBehaviour {
	[SerializeField] private GameObject Panel;

	public float alfa = 0.01f;
	float r, g, b, a;

	// Use this for initialization
	void Start () {
		r = Panel.GetComponent<Image>().color.r;
		g = Panel.GetComponent<Image> ().color.g;
		b = Panel.GetComponent<Image> ().color.b;
		a = Panel.GetComponent<Image> ().color.a;
	}

	// Update is called once per frame
	void Update () {
		a -= alfa;
		Panel.GetComponent<Image> ().color = new Vector4(r,g,b,a);
		print (Panel.GetComponent<Image> ().color.a);

		if(a < 0.0f){

			alfa = 0;
		}
	}
}
