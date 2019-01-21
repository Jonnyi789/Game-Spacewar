using System.Linq;
using UnityEngine;

/// <summary>
/// Marks a location where a ship can respawn
/// </summary>
public class SpawnPoint : MonoBehaviour
{
    /// <summary>
    /// Visualize the spawn point in the editor
    /// </summary>
    internal void OnDrawGizmos()
    {
        if (Application.isPlaying)
            return;

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, 0.1f);
        Gizmos.DrawLine(transform.position, transform.position+transform.TransformDirection(new Vector3(0.4f, 0, 0)));
    }

    /// <summary>
    /// Find the distance of the closest ship to the spawnpoint.
    /// </summary>
    public float Freespace
    {
        get
        {
            var position = transform.position;
            return FindObjectsOfType<Ship>().Min(ship => Vector3.Distance(position, ship.transform.position));  
            // There's one unfixed issue when we sort this way in FindFree: if player ship and enemy both die by crashing into each other,
            // they respawn at the same point, super close to each other.
        }
    }

    public static SpawnPoint FindFree()
    {
        // Why doesn't Linq have ArgMax?  This should just be a linq query. Now we have to loop.
        var all = GameObject.FindObjectsOfType<SpawnPoint>();
        var best = all[0];
        var score = best.Freespace;
        for (var i = 1; i < all.Length; i++)
        {
            var e = all[i];
            var s = e.Freespace;
            if (s > score)
            {
                best = e;
                score = s;
            }
        }
        return best;
    }
}
