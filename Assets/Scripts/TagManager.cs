using UnityEngine;
using System.Collections;

/// <summary>
/// Class which holds all the names of the tags in a static manner. Used to
/// avoid String errors and so on.
/// </summary>
public class TagManager : MonoBehaviour {

    public const string player = "Player";
    public const string spikes = "Spikes";
    public const string spawnPoint = "SpawnPoint";
    public const string fallingFloor = "FallingFloor";
    public const string floor = "Floor";
    public const string scythe = "Scythe";
    public const string shuriken = "Shuriken";
    public const string fallingBlock = "FallingBlock";
    public const string grabPoint = "GrabPoint";
    public const string endTrigger = "EndTrigger";
}