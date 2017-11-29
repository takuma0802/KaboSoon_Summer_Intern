using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager<T> : MonoBehaviour where T : MonoBehaviour {

	static T _instance;

	public static T Instance
	{
		get {
			if(applicationIsQuitting){
				return null;
			}

			if(_instance == null){
				_instance = (T)FindObjectOfType(typeof(T));

				if(_instance == null){
					GameObject go = new GameObject(typeof(T).ToString());
					_instance = go.AddComponent<T>();
					DontDestroyOnLoad(go);
				}
			}
			return _instance;
		}
	}

	static bool applicationIsQuitting = false;
	public void OnDestroy () {
		applicationIsQuitting = true;
	}

//	protected void Awake(){
//		CheckInstance ();
//	}
//
//	protected bool CheckInstance(){
//		if (_instance == null) {
//			_instance = GameManager<T>.Instance;
//			return true;
//		} else if (_instance == this) {
//			return true;
//		}
//		Destroy (this);
//		return false;
//	}
}