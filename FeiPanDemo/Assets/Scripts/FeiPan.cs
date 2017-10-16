using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeiPan : MonoBehaviour {

	public GameObject feipan;
	private Transform feiPanParent;
	// Use this for initialization
	void Start ()
	{
		feiPanParent = gameObject.GetComponent<Transform> ();

	}
	void CreatPeiPans()
	{
		for (int i = 0; i < 3; i++) 
		{
			Vector3 v = new Vector3 (Random.Range (-8, 8), Random.Range (1, 2.5f), Random.Range (0, -5));
			GameObject obj = GameObject.Instantiate(feipan,v,Quaternion.identity) as GameObject;
			obj.GetComponent<Transform> ().SetParent (feiPanParent);
		}
	}
	public void StartCreatFeiPan()
	{
		InvokeRepeating ("CreatPeiPans", 2, 1);
	}
	public void StopCreatFeiPan()
	{
		CancelInvoke ("CreatPeiPans");
	}
	// Update is called once per frame
	void Update () {
		
	}
}
