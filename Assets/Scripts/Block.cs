using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	Transform scroller;
	public float fadeTime;
	public int playerNumber;	//for tracking which player it belongs to

	Color transColor;
	Color fullColor;

	// Use this for initialization
	void Start () {
		scroller = GameObject.Find ("Scroller").transform;
		transColor = new Color (1, 1, 1, 0.5f);
		fullColor = new Color (1, 1, 1, 1);
		renderer.material.color = transColor;
	}
	
	// Update is called once per frame
	void Update () {
		if (fadeTime > 0) {
			fadeTime -= Time.deltaTime;
		} else {
			renderer.material.color = fullColor;
			transform.parent = scroller;
		}
	}
}
