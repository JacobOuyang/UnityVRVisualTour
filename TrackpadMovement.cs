using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TrackpadMovement : MonoBehaviour {
    public GameObject player;
    public GameObject screen;
    SteamVR_Controller.Device device;
    SteamVR_TrackedObject controller;
    Vector2 touchpad;
    private float sensitivityX = 1.5F;
    private Vector3 playerPos;
    public Vector3 startPos;
    public int counter;
    
    // Use this for initialization
    public Texture[] textarray = new Texture[40];

	// Use this for initialization
	void Start () {
        controller = gameObject.GetComponent<SteamVR_TrackedObject>();
        counter = 0;
        screen.GetComponent<Renderer>().material.EnableKeyword("_MainTex");
        
        textarray = Resources.LoadAll<Texture>("Textures/Static");
        startPos = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)controller.index);
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            player.transform.position = startPos;
            print("Jump");
            if (counter <= textarray.Length - 2)
                counter += 1;
            else
                counter = 0;
            print(textarray[counter]);


        }
        screen.GetComponent<Renderer>().material.SetTexture("_MainTex", textarray[counter]);
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            player.transform.position = startPos;

        
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
            print("touch");
            print(touchpad.x + "x            " + touchpad.y + "    y");
            if (touchpad.y > 0.1 || touchpad.y < -0.1)
            {

               
                player.transform.position += player.transform.forward * Time.deltaTime * touchpad.y * 5;
                playerPos = player.transform.position;
                //print(player.transform.position + "    y  " + touchpad.x + "x");
                
            }
            if (touchpad.x > 0.1 || touchpad.x < -0.1)
            {
           player.transform.Rotate(0, touchpad.x * sensitivityX *0.1f, 0);
            }
           // print(playerPos + "test2");
        }
        
	}
}
