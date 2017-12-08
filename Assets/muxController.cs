using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UI.Text;

public class muxController : MonoBehaviour {
	public Text muxName;
	public Text inputA;
	public Text inputB;
	public Text output;

	// Use this for initialization
	void Start () {
		GameObject.Find("Mux");
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	void SetInput(int inputA, int inputB) {
		this.inputA.text = inputA.ToString();
		this.inputB.text = inputB.ToString();
	}

	void SetMuxName(string name) {
		this.muxName.text = name;
	}

	void setOutput(int output) {
		this.output.text = output.ToString();
	}
}
