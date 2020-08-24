﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxCollector : Character
{
    Character charInTheWay = null;
    public AudioSource sndSrc;
    public AudioClip dead;
    King king;

    private void Start()
    {
        king = FindObjectOfType<King>();
    }

    public override bool Interact(Character user)
    {
        currDir = user.currDir;
        if (DieByPlayerHoldingShiftKey(user))
        {
            return true;
        }
        if (user.type == CharacterType.ASSASIN)
        {
            Die(user.currDir.Vector());
            return true;
        }
        
        // This character can be pushed and will push other 
        // characters that it is allowed to push
        if (Mover.MoveCharacter(this, out charInTheWay, true, currDir, Physics.DefaultRaycastLayers))
        {
            return true;
        }
        currDir = MovDir.NONE;
        return false;
    }

    public override void Die(Vector3 impactForce)
    {
        if (sndSrc != null)
        {
            sndSrc.PlayOneShot(dead);
        }
        base.Die(impactForce);
    }

    public override void CharacterUpdate()
    {
        // The tax collector should raycast in all 4 directions and go in 
        // whichever direction has the most space and is away from the king
        int[] distances = new int[4];
        for (int i = 0; i < 4; i++)
        {
            Vector3 kingPos = king.gameObject.transform.position;
            MovDir dir = (MovDir)i;
            if ()
                continue;
            RaycastHit rayInfo;
            Physics.Raycast(
                transform.position + rayStartingHeight, 
                dir.Vector(), 
                out rayInfo);
        }

    }

}
