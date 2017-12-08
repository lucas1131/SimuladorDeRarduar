using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[UnityEngine.SerializeField]
public class RegisterFileController : MonoBehaviour {

	public Text r0;
	public Text r1;
	public Text r2;
	public Text r3;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setValues(int[] newValues){
		r0.text = newValues[0].ToString();
		r1.text = newValues[1].ToString();
		r2.text = newValues[2].ToString();
		r3.text = newValues[3].ToString();
	}
}
