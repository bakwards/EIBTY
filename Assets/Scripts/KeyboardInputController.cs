using UnityEngine;
using System.Collections;

public class KeyboardInputController : MonoBehaviour {

	private PlayerController playerController;

	// Use this for initialization
	void Awake () {
		playerController = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			playerController.Jump();
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			playerController.SwitchDirection(-1);
			playerController.Boost();
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			playerController.SwitchDirection(1);
			playerController.Boost();
		}
	}
}
