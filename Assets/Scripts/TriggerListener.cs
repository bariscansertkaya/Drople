using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TriggerListener : MonoBehaviour
{
    public event Action<GameObject, Collider2D> OnEnter;
    public event Action<GameObject, Collider2D> OnExit;
    public event Action<GameObject, Collider2D> OnStay;
     
    [SerializeField, TagField] private List<string> whiteList;

    private Collider2D _collider;

    private void Awake()
    {
        TryGetComponent(out _collider);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!whiteList.Contains(other.tag))
        {
            return;
        }
            
        OnEnter?.Invoke(gameObject, other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!whiteList.Contains(other.tag))
        {
            return;
        }
            
        OnExit?.Invoke(gameObject, other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!whiteList.Contains(other.tag))
        {
            return;
        }
            
        OnStay?.Invoke(gameObject, other);
    }

}

