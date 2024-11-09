using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ActivateAnimWIthTrigger : MonoBehaviour
{
    [SerializeField] private Animator[] _animator;

    private bool hasPlayedIt = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayedIt) return;
        foreach (var item in _animator)
            item.SetTrigger("trigger");
        hasPlayedIt = true;
    }
}
