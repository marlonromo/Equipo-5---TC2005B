using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

  public Animator animator;
  private Rigidbody2D rigBod;
  //private Rigidbody2D _rigidbody;
  public float movementSpeed;
  public float jumpForce = 5;
  public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale = 1;
      rigBod = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      animator.SetFloat("Run", Input.GetAxis("Horizontal"));
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        if(Input.GetButtonDown("Jump") && Mathf.Abs(rigBod.velocity.y) < 0.001){
          rigBod.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        //animator.SetBool("Grounded", grounded);

        if(!Mathf.Approximately(0,movement)){
          transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
    }
}
