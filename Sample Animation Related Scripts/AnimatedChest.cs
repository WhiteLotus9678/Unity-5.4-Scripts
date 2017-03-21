using UnityEngine;
using System.Collections;

public class AnimatedChest : MonoBehaviour {

    enum State { LOCKED, OPEN }; //0, 1

    private State myState;

    bool haveKey;

    private TextHintsUi textHints;

    float dist;

    float timer = 0f;

    Animator animator;

    GameObject vial; //creating a reference to the variable

    // Use this for initialization
    void Start () {

        myState = State.LOCKED; //contains 0

        textHints = GameObject.Find("TextHints").GetComponent<TextHintsUi>();

        animator = transform.GetComponentInParent<Animator>();

        vial = GameObject.Find("AnimatedVial");

        vial.SetActive(false);

    }

    void OnMouseDown()
    {
        if (dist < 5f * 5f)
        {
            //to open the chest again, connect key insert animation to key remove animation (not required)
            if (myState == State.LOCKED)
            {
                haveKey = GameManager.HaveKey;
                if (haveKey == true)
                {
                    //vial.SetActive(true);
                    transform.parent.FindChild("KeyAtLock").gameObject.SetActive(true);
                    animator.SetBool("OpenChest", true);
                    //GameManager.HaveKey = false;
                    myState = State.OPEN;
                }
                else
                {
                    textHints.hintText.enabled = true;
                    textHints.hintText.text = "Find a key to open the chest.";
                }
            }
            else if (myState == State.OPEN)
            {
                //GameManager.HaveKey = true;
                animator.SetBool("OpenChest", false);
                myState = State.LOCKED;
            }
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
	
	// Update is called once per frame
	void Update () {

        dist = GetComponent<Interactor>().DistanceFromCamera();

        //Delays the vial until the chest is opened
        //Could also use Invoke or a Coroutine
        if(myState == State.OPEN)
        {
            timer = timer + Time.deltaTime;
            if(timer > 1.7f)
            {
                vial.SetActive(true);
            }
        }

    }
}
