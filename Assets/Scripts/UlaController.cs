using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[UnityEngine.SerializeField]
public class UlaController : MonoBehaviour {

    public Text nameText;
    public Text inputAValue;
    public Text inputBValue;
    public Text outputValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setName(string newName)
    {
        nameText.text = newName;
    }

    public void setInputA(int newValue)
    {
        this.inputAValue.text = newValue.ToString();
    }

    public void setInputB(int newValue)
    {
        this.inputBValue.text = newValue.ToString();
    }

    public void setOutput(int newValue)
    {
        this.outputValue.text = newValue.ToString();
    }

}
