using UnityEngine;
using System.Collections;

public class BackgroundAnimator : MonoBehaviour {

    public Scroller scroller;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float yPos = 0;
        float speed = -scroller.scrollSpeed * Time.deltaTime;

        foreach (Transform child in transform)
        {
            child.transform.Translate(Vector3.up * speed);

            //if (child.transform.position.y >= yPos)
            //{
            //    yPos = child.transform.position.y;
            //}
            
            if (child.transform.position.y <= -9)
            {
                child.transform.position = new Vector3(0, 9, 1);
            }            
        }
	}
}
