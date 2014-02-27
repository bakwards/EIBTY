using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float runSpeed = 10;
	public float jumpPower = 250;
	public float swipeBoostPower = 100;
	public float minBoostSpeed = 1;
	public float boostCoolDown = 2;
	private float boostCoolDownCounter = 0;
	private int direction = 1;
	private bool isBoosting = false;

	void Start (){
		transform.localScale = new Vector3(direction, 1, 1);
	}

	void FixedUpdate () {
		if(!isBoosting){
			rigidbody2D.velocity = new Vector2(direction*runSpeed, rigidbody2D.velocity.y);
		} else if (Mathf.Abs(rigidbody2D.velocity.x) < minBoostSpeed ){
			isBoosting = false;
			rigidbody2D.gravityScale = 1;
		}
	}

	void Update () {
		if(boostCoolDownCounter > 0){
			boostCoolDownCounter -= Time.deltaTime;
		} else if (boostCoolDownCounter < 0){
			boostCoolDownCounter = 0;
		}
	}

	public void Jump () {
		rigidbody2D.AddForce(transform.up * jumpPower);
	}

	public void Boost () {
		if(!isBoosting && boostCoolDownCounter == 0){
			rigidbody2D.AddForce(transform.right * swipeBoostPower * direction);
			rigidbody2D.gravityScale = 0;
			boostCoolDownCounter = boostCoolDown;
			isBoosting = true;
		}
	}
	
	public void SwitchDirection (int dir) {
		if(dir == direction){
			return;
		} else {
			direction *= -1;
			transform.localScale = new Vector3(direction, 1, 1);
		}
	}

}
