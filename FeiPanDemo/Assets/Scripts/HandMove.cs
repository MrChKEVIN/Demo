using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour {

	private Ray myRay;
	private RaycastHit myHit;
	private Transform m_Transform;
	private Transform m_PointTransform;//枪口位置

	private GameManager m_gameManager;


	private LineRenderer m_LineRenderer;
	private AudioSource m_AudioSource;

	private bool canMove = false;
	// Use this for initialization
	void Start () 
	{
		m_Transform = this.gameObject.transform;
		m_PointTransform = m_Transform.Find("Point");

		m_LineRenderer = m_PointTransform.gameObject.GetComponent<LineRenderer> ();

		m_AudioSource = this.gameObject.GetComponent<AudioSource> ();

		m_gameManager = GameObject.Find ("UI").GetComponent<GameManager> ();

	}
	public void ChangeCanMove(bool tempBool)
	{
		canMove = tempBool;
	}
	// Update is called once per frame
	void Update () 
	{
		if (canMove) 
		{
			myRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (myRay, out myHit)) 
			{
				m_gameManager.AddScore ();
				m_Transform.LookAt (myHit.point);

				Debug.DrawLine (m_PointTransform.position, myHit.point,Color.yellow);

				m_LineRenderer.SetPosition (0, m_PointTransform.position);
				m_LineRenderer.SetPosition (1, myHit.point);
				if (myHit.collider.tag == "FeiPan" && Input.GetMouseButton (0))
				{
					m_AudioSource.Play ();
					Transform parent = myHit.transform.parent;
					Transform[] feiPans = parent.GetComponentsInChildren<Transform> ();
					for (int i = 0; i < feiPans.Length; i++) 
					{
						feiPans [i].gameObject.AddComponent<Rigidbody> ();
					}
					Destroy (parent.gameObject,2.0f);
				}
			}	
		}

	}
}
