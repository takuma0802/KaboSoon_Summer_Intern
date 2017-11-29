using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	[SerializeField] private float _limitTime;
	[SerializeField] private ScoreManager _scoreManager;
	[SerializeField] private Text _limitTimeText;
	[SerializeField] private Text _timeUpText;
	[SerializeField] private Text _countDownText;
	float _countDown;
	bool _startBall = true;
	[SerializeField] BallMove _ball;

	AudioSource _audioSource;
	AudioClip _audioClipCount;
	AudioClip _audioClipCountDown;
	bool bStartCntSE;

	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName == "GameScene") {
			_limitTime = 30f;
			_countDown = 4;
			_countDownText.enabled = true;
			_timeUpText.enabled = false;
			_startBall = true;
			_audioSource = GetComponent<AudioSource> ();
			_audioClipCount = Resources.Load<AudioClip> ("Audio/TimeCnt");
			_audioClipCountDown = Resources.Load<AudioClip> ("Audio/TimeCnt2");
			bStartCntSE = false;
		}
    }
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "GameScene") {
			if (bStartCntSE != true) {
				bStartCntSE = true;
				Invoke ("Count", 0.2f);
				Invoke ("Count", 1.2f);
				Invoke ("Count", 2.2f);
				Invoke ("CountDown", 3.2f);
			}
			_countDown -= Time.deltaTime;
			int countDown = (int)_countDown;
			_countDownText.text = countDown.ToString ();

			if (_limitTime >= 0f && _countDown < 0f) {
				if (_startBall) {
					_ball.BollMoveMethod ();
					_startBall = false;
				}
				_countDownText.enabled = false;
				_limitTime -= Time.deltaTime;
				int limitTime = (int)_limitTime;
				_limitTimeText.text = "Time\r\n" + limitTime;
				_timeUpText.enabled = false;
			} else if (_limitTime < 0f) {
				_scoreManager.CulcPanelNum ();
				_timeUpText.enabled = true;

				Invoke ("LoadResultScene", 2f);
			}
		}
	}

	private void LoadResultScene(){
		SceneManager.LoadScene ("Result");
	}

	public void LoadGameScene(){
		SceneManager.LoadScene ("GameScene");
	}

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

	void Count(){
		_audioSource.PlayOneShot (_audioClipCount);
	}

	void CountDown(){
		_audioSource.PlayOneShot (_audioClipCountDown);
	}
}
