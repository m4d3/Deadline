﻿using UnityEngine;
using System.Collections;

public class PowerUp2 : PowerUp {
	
	void OnTriggerEnter2D(Collider2D col)
	{
		//example code
		Destroy (gameObject);
		print ("PowerUp2");
	}
}
