using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[UnityEngine.SerializeField]
public class DANKERYcontroller : MonoBehaviour {

	int DunkeryDinheirinhos = 0;
	bool satanismo = false;
	public Image lixo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(satanismo){
				lixo.enabled = satanismo;
				satanismo = false;
			} else {
				lixo.enabled = satanismo;
			}

		DunkeryDinheirinhos++;

		if(DunkeryDinheirinhos % 35 == 1 || DunkeryDinheirinhos % 75 == 1 ){
			if(!satanismo){
				satanismo = true;
			}
		}
	}
}
