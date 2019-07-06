using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterMove : MonoBehaviour
{
	static int hashSpeed = Animator.StringToHash ("Speed");
	static int hashFallSpeed = Animator.StringToHash ("FallSpeed");
	static int hashGroundDistance = Animator.StringToHash ("GroundDistance");
	static int hashIsCrouch = Animator.StringToHash ("IsCrouch");

	static int hashDamage = Animator.StringToHash ("Damage");

	[SerializeField] private float characterHeightOffset = 0.2f;
	[SerializeField] LayerMask groundMask;

	[SerializeField, HideInInspector] Animator animator;
	[SerializeField, HideInInspector]SpriteRenderer spriteRenderer;
	[SerializeField, HideInInspector]Rigidbody2D rig2d;


	void Awake ()
	{
		animator = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		rig2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		float axisX = Input.GetAxisRaw ("Horizontal");
		float axisY = Input.GetAxisRaw ("Vertical");
		

        Vector2 velocity = rig2d.velocity;
		if (axisX != 0||axisY!=0){
			spriteRenderer.flipX = axisX < 0;
            velocity.x = axisX * 2;
			velocity.y=axisY*2;
        }
		else
		{
			velocity.x=velocity.y=0;
		}
		if(GameManger.Instance.userCanMove){
			rig2d.velocity = velocity;
		}
	
		animator.SetFloat (hashSpeed, Mathf.Abs (velocity.magnitude));

	}
    

    void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetTrigger(hashDamage);  
    }

	public void moveToByAnima(Vector3 target,float t){
		GameManger.Instance.userCanMove=false;
		transform.DOMove(target,t).OnComplete(()=>{GameManger.Instance.userCanMove=true;});
	}
}
