using UnityEngine;
using System.Collections;

public class Scroller : MonoBehaviour {

	public float scrollSpeed;
	public float increment;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * -scrollSpeed * Time.deltaTime);
		scrollSpeed += increment * Time.deltaTime;
	}
}
