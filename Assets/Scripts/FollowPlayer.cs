using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject Enemy;
    private GameObject Player;
    private float Hor = 0.0f;
    private float Vert = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        Hor = transform.position.x;
        Vert = transform.position.y;

        if (Mathf.Abs(Hor) > Mathf.Abs(Vert))
        {
            animator.SetFloat("Horizontal", Hor);
            animator.SetFloat("Vertical", 0.0f);
        }
        else if (Mathf.Abs(Vert) > Mathf.Abs(Hor))
        {
            animator.SetFloat("Horizontal", 0.0f);
            animator.SetFloat("Vertical", Vert);
        }
        else
        {
            animator.SetFloat("Horizontal", 0.0f);
            animator.SetFloat("Vertical", 0.0f);
        }

        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 0.5f * Time.deltaTime);
    }
}
