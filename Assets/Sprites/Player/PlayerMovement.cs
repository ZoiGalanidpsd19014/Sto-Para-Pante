using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

    
{
    
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    float inputHorizontal;
    float inputVertical;
    public Animator animator;
    private float jump;
    public float speed = 20f;
    
 // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
            transform.Translate(Input.GetAxis("Horizontal") * 20f * Time.deltaTime, 0, 0);
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (inputHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(2, 2, 1);
        }

        if (inputHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-2, 2, 1);
        }

            
    }

}
