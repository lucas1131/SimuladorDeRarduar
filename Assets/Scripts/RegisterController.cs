using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[UnityEngine.SerializeField]
public class RegisterController : MonoBehaviour {

    public Text nameText;
    public Text valueText;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setName(string newName) {
        nameText.text = newName;
    }

    public void setValue(int newValue) {
        this.valueText.text = newValue.ToString();
    }
}
