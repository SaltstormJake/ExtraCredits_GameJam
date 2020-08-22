﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Mover
{    
    public static bool MoveCharacter(
        Character sourceCharacter, 
        out Character hitCharacter, 
        bool pushHitCharacter,
        MovDir direction,
        LayerMask layerMask)
    {
        hitCharacter = null;

        //Do raycast
        Vector3 dir = direction.Vector();
        Vector3 sourcePos = sourceCharacter.transform.position;
        RaycastHit rayInfo;
        Physics.Linecast(sourcePos, sourcePos + dir, out rayInfo, layerMask);
        Debug.DrawLine(sourcePos, sourcePos + dir, Color.red);

        //If we hit something, check if it blocks our path
        bool isBlocked = rayInfo.transform != null;
        if (isBlocked)
        {
            //Check if the blocking thing is a character
            hitCharacter = rayInfo.transform.gameObject.GetComponent<Character>();
            if (hitCharacter != null)
            {
                //If the function cant interact with objects then ignore the hit object and dont move, if it can, do an interact
                if (!pushHitCharacter)
                {
                    return false;
                }
                else
                {
                    //If the character we interact with tells us that we shouldnt move, we return false and we dont move
                    //if it doesnt, then we move
                    if (!hitCharacter.Interact(sourceCharacter))
                    {
                        return false;
                    }
                }
            }
        }

        //If the way is clear, then move sourceCharacter and return true
        //The movements should ONLY be done in 1 unit increment 
        //ie: I move right so dir = 1,0,0    
        sourceCharacter.transform.position += dir;
        return true;
    }    
}