using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
	bool flag;
	public bool useFlag = true;
	[SerializeField] private GameObject RightButton;
	[SerializeField] private GameObject LeftButton;
	[SerializeField] private GameObject BtnController;
    [SerializeField] private GameObject SceneObj;
	//right get
	//右→flag=true,左→false
	//Enter -> bool ->
	//true -> right.OnClick

	AudioSource _audioSource;
	AudioClip _audioClipCursor;
	AudioClip _audioClipDecision;

	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource> ();
		_audioClipCursor = Resources.Load<AudioClip>("Audio/Cursor");
		_audioClipDecision = Resources.Load<AudioClip>("Audio/Decision");
	}
	
	// Update is called once per frame
	void Update () {
		if (useFlag == true) {
			if(Input.GetKey(KeyCode.RightArrow) ||(Input.GetAxis("Player1X") > 0)){
				RightButton.GetComponent<Button>().Select();
				_audioSource.PlayOneShot(_audioClipCursor);
                flag = true;
			}else if(Input.GetKey(KeyCode.LeftArrow) || (Input.GetAxis("Player1X") < 0))
            {
                LeftButton.GetComponent<Button>().Select();
				_audioSource.PlayOneShot(_audioClipCursor);
               flag = false;
			}
			if (Input.GetKey (KeyCode.Return) || Input.GetButtonDown("Joycon1AButton")) {
				_audioSource.PlayOneShot(_audioClipDecision);
				onClickButton ();

            }
		}
	}
	
	public void onClickButton(){
		if(flag == true){
			BtnController.GetComponent<RuleMove>().rFlag = true;
		}else if(flag == false){
			useFlag = false;
			SceneObj.GetComponent<SceneController>().LoadGameScene();

        }
	}
}
