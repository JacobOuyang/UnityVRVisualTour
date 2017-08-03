using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderChange : MonoBehaviour {
   
    public Renderer rend;
   
    public int counter;
    public Texture textreal;
	// Use this for initialization
    public Texture[] textarray = new Texture[40];
	void Start () {
        counter = 0;
        rend.material.EnableKeyword("_MainTex");
        rend = GetComponent<Renderer>();
        textarray = Resources.LoadAll<Texture>("Textures");
        print(textarray.Length);
        for (int i = 0; i < textarray.Length; i += 1)
            print(textarray[i]);
        
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonDown("Fire1"))
        {
            print("Jump");
            if (counter <= textarray.Length - 2)
                counter += 1;
            else
                counter = 0;
            print(textarray[counter]);    
          
        }
        rend.material.SetTexture("_MainTex", textarray[counter]);
                

                
          
            
	}
}
