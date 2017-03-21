using UnityEngine;
using System.Collections;

public class Interactor : MonoBehaviour {

    //public Texture2D defaultTexture;
    public Texture2D newTexture;

    private GameObject myCamera;

    //turns mouse on/off
    public float DistanceFromCamera() //returns the square of the magnitude of the vector between the player and action object
    {
        Vector3 offset = myCamera.transform.position - this.transform.position;
        float sqrLen = offset.sqrMagnitude;
        return sqrLen;
    }

    void OnMouseEnter()
    {
        if( DistanceFromCamera() < 5f*5f) //if the distance is greater than a specified trigger distance
        {
            Cursor.SetCursor(newTexture, Vector2.zero, CursorMode.Auto);
        }
    }
    
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

	// Use this for initialization
	void Start () {

        myCamera = GameObject.Find("FirstPersonCharacter");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
