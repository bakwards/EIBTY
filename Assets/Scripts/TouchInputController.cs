using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class TouchInputController : MonoBehaviour {

	public PlayerController playerController;

	void Start()
	{ 
		if (GetComponent<TapGesture>() != null) GetComponent<TapGesture>().StateChanged += onTap;
		if (GetComponent<FlickGesture>() != null) GetComponent<FlickGesture>().StateChanged += onFlick;
	}
	
	private void onTap(object sender, TouchScript.Events.GestureStateChangeEventArgs e)
	{
		if (e.State == Gesture.GestureState.Recognized)
		{
			playerController.Jump();
		}
		
	}
	private void onFlick(object sender, TouchScript.Events.GestureStateChangeEventArgs e)
	{
		if (e.State == Gesture.GestureState.Recognized)
		{
			FlickGesture gesture = sender as FlickGesture;
			playerController.SwitchDirection((int)Mathf.Sign(gesture.ScreenFlickVector.x));
			playerController.Boost();
		} 
		
	}
}
