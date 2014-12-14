using UnityEngine;
using System.Collections;

/// <summary>
/// Class which holds all the names of the tags in a static manner. Used to
/// avoid String errors and so on.
/// </summary>
public class TagManager : MonoBehaviour {

    // player
    public const string player = "Player";
    public const string spikes = "Spikes";
    public const string spawnPoint = "SpawnPoint";
    public const string fallingFloor = "FallingFloor";
}