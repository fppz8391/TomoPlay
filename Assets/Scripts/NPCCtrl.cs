using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCtrl : MonoBehaviour
{
    public Transform Player;
    public float flowDistance;
    public float moveSpeed;

    [SerializeField, HideInInspector] Animator animator;
	[SerializeField, HideInInspector]SpriteRenderer spriteRenderer;
	[SerializeField, HideInInspector]Rigidbody2D rig2d;
    static int hashSpeed = Animator.StringToHash ("Speed");
    void Awake ()
	{
		animator = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		rig2d = GetComponent<Rigidbody2D> ();
	}
    // Start is called before the first frame update
    void Start()
    {
        if(Player==null){
            Player=GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.flipX = (Player.position.x-transform.position.x) < 0;
        if(Vector3.Distance(transform.position,Player.position)>flowDistance){
            rig2d.drag=2;
            rig2d.velocity=(Player.position-transform.position)/10*moveSpeed;
        }else
        {
            rig2d.velocity=Vector3.zero;
        }
        animator.SetFloat (hashSpeed, Mathf.Abs (rig2d.velocity.magnitude));
    }
}
