using UnityEngine;

/// <summary>
/// Base class for ships (children are Enemy and Player)
/// </summary>
public abstract class Ship : MonoBehaviour
{
    /// Add AudioClip fields:
    public AudioClip targetDestroyed;
    public AudioClip missileFired;
    public AudioClip Marvelous;

    /// <summary>
    /// Our RigidBody component.
    /// RigidBody components let us tell physics what forces to apply to an object.
    /// </summary>
    protected Rigidbody2D rigidBody;
    // A protected member is accessible within its class and by derived class instances. 

    /// <summary>
    /// Find the rest of our components.
    /// Called at startup.
    /// </summary>
    internal virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
}