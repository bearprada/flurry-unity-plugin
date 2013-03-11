using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {
#if UNITY_ANDROID
	private string FLURRY_API = "PPJNXV3ZZ3XV6NP4ZJBB";
#elif UNITY_IPHONE
	private string FLURRY_API = "MYSB2HCSHBXBXX3H9FN7";
#else
	private string FLURRY_API = "x";
#endif
	// Use this for initialization
	void Start () {
		FlurryAgent.Instance.onStartSession(FLURRY_API);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.frameCount%300==0)
			FlurryAgent.Instance.logEvent("test update");
	}
	
	void OnDestroy(){
		FlurryAgent.Instance.onEndSession();
	}
}
