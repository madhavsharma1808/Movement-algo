using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class Brain : MonoBehaviour
{
    public int DNAlength = 1;
    public float timealive;
    public DNA dna;
    ThirdPersonCharacter character;
    bool jump=false;
    bool crouch=false;
    Vector3 move;
    bool isalive = true;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="dead")
        {
            isalive = false;
        }
    }

    public void init() //initializing the values
    {
        dna = new DNA(DNAlength, 6);
        character = GetComponent<ThirdPersonCharacter>();
        timealive = 0;
        isalive = true;
        
    }

    

    public void FixedUpdate()
    {
        
        
        float h = 0;
        float v = 0;
        bool crouch = false;
        if (dna.GetGene(0) == 0) v = 1;
        else if (dna.GetGene(0) == 1) v = -1;
        else if (dna.GetGene(0) == 2) h = -1;
        else if (dna.GetGene(0) == 3) h = 1;
        else if (dna.GetGene(0) == 4) jump = true;
        else if (dna.GetGene(0) == 5) crouch = true;


        move = v * Vector3.forward + h * Vector3.right;
        character.Move(move, jump, crouch);
        jump = false;
        crouch = false;
        if(isalive)
        {
            timealive += Time.deltaTime;
        }

    }
}
