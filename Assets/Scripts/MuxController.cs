	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UI.Text;

public class MuxController : MonoBehaviour {

	public Text pc;
	public Text jmpAddr;
	public Text brAddr;
	public Text output;

	// Use this for initialization
	void Start () {
		// Rip find object :((((
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	public void SetInput(int pc, int jmpAddr, int brAddr) {
		this.pc.text = pc.ToString();
		this.jmpAddr.text = jmpAddr.ToString();
		this.brAddr.text = brAddr.ToString();
	}

	public void SetOutput(int output) {
		this.output.text = output.ToString();
	}
}
