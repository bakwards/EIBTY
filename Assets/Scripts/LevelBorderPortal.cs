using UnityEngine;
using System.Collections;

public class LevelBorderPortal : MonoBehaviour {

	public GameObject siblingCollider;

	void OnTriggerEnter2D(Collider2D other){
		other.transform.position = new Vector3(siblingCollider.transform.position.x,other.transform.position.y,other.transform.position.z);
	}
}
