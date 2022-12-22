using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coba : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("Run");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
