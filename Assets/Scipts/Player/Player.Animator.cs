using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    private Rigidbody[] ragdoolRBs;

    private Animator animator;
    private string jumpParametrName = "Jump";

    private void AnimatorAwake()
    {
        animator = GetComponentInChildren<Animator>();

        ragdoolRBs = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
    }

    private void DisableRagdoll()
    {
        foreach(var rb in ragdoolRBs)
        {
            rb.isKinematic = true;
        }
        animator.enabled = true;
    }

    private void EnableRagdoll()
    {
        foreach (var rb in ragdoolRBs)
        {
            rb.isKinematic = false;
        }
        animator.enabled = false;
    }

    private void AnimateJump()
    {
        animator.SetTrigger(jumpParametrName);
    }

    private void ResetAnimator()
    {
        DisableRagdoll();
    }

}
