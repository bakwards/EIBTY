using UnityEngine;
using System.Collections;

public class GoalReached : MonoBehaviour {

	public Vector3 endingSize;
	public float endSpeed = 1;
	private bool gameEnding = false;

	void Update (){
		if(gameEnding){
			transform.localScale = Vector3.Lerp(transform.localScale, endingSize, endSpeed);
			if(transform.localScale.x > endingSize.x - (endingSize.x/10)){
				if(Application.levelCount-1 > Application.loadedLevel){
					Application.LoadLevel(Application.loadedLevel+1);
				} else {
					Application.LoadLevel(0);
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		Destroy(other.gameObject);
		gameEnding = true;

	}
}
