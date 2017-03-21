using UnityEngine;
using System.Collections;

public class AnimatedFlower : MonoBehaviour {

    enum State { ALIVE, DEAD};

    private State myState;

    private TextHintsUi textHints;

    bool havePotion;

    float dist;

    Animator animator;

    public bool alive = false;

    // Use this for initialization
    void Start () {

        myState = State.DEAD;

        textHints = GameObject.Find("TextHints").GetComponent<TextHintsUi>();

        animator = transform.GetComponentInParent<Animator>();

    }

    void OnMouseDown()
    {
        if (dist < 5f * 5f)
        {
            //to open the chest again, connect key insert animation to key remove animation (not required)
            if (myState == State.DEAD)
            {
                havePotion = GameManager.HavePotion;
                if (havePotion == true)
                {
                    //vial.SetActive(true);
                    animator.SetBool("NotDead", true);
                    myState = State.ALIVE;
                    alive = true;
                }
                else
                {
                    textHints.hintText.enabled = true;
                    textHints.hintText.text = "Find a potion to revive this flower.";
                }
            }
            else if (myState == State.ALIVE)
            {
                //Do nothing
            }
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
