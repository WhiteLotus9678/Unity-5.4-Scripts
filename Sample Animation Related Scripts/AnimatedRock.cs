using UnityEngine;
using System.Collections;

public class AnimatedRock : MonoBehaviour {

    Animator animator;
    float dist;

	// Use this for initialization
	void Start () {

        animator = transform.GetComponentInParent<Animator>(); //Or use transform.parent....
	
	}
	
    void OnMouseDown() //left mouse button set by default
    {
        if (dist < 5f * 5f)
        {
            animator.SetBool("MoveRock", true);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

	// Update is called once per frame
	void Update () {

        dist = GetComponent<Interactor>().DistanceFromCamera();

    }
}
