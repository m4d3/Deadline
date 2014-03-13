using UnityEngine;
using System.Collections;

public class BackgroundAnimator : MonoBehaviour {

    public Scroller scroller;
    public Texture[] backgroundTextures;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float speed = -scroller.scrollSpeed * Time.deltaTime;

        transform.Translate(Vector3.up * speed);

        foreach (Transform child in transform)
        {            
            if (child.transform.position.y <= -9)
            {
                child.renderer.material.mainTexture = backgroundTextures[(int)Random.Range(0, backgroundTextures.Length-1)];
                child.transform.position = new Vector3(0, 9 + (child.transform.position.y + 9), 1);
            }            
        }
	}
}
