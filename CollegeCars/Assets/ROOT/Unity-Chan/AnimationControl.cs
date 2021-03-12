using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator myAnimator;
    void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            myAnimator.SetTrigger("Damaged");
        }

        myAnimator.SetBool("Walking", Input.GetKey(KeyCode.W));
    }
}
