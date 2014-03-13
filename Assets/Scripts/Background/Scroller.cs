using UnityEngine;
using System.Collections;

public class Scroller : MonoBehaviour {

	public float scrollSpeed;
	public float increment;

    public GameObject background;
    public Vector2 uvAnimationRate = new Vector2(0.0f, 1.0f);

    Vector2 uvOffset = Vector2.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.up * -scrollSpeed * Time.deltaTime);
		scrollSpeed += increment * Time.deltaTime;
	}

    void LateUpdate()
    {
        uvOffset += (uvAnimationRate * Time.deltaTime * scrollSpeed);
        background.renderer.material.SetTextureOffset("_MainTex", uvOffset);
    }
}
