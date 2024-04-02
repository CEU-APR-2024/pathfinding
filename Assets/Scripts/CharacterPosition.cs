using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPosition
{
    private string name { get; set; }
    private float timestamp { get; set; }
    private Vector3 position { get; set; }

    public CharacterPosition(string name, float timestamp, Vector3 position)
    {
        this.name = name;
        this.timestamp = timestamp;
        this.position = position;
    }

    public string ToCSV()
    {
        return $"{name};{timestamp};{position.x};{position.y};{position.z}";
    }

    public override string ToString()
    {
        return $"{name} {timestamp} {position}"; //Interpolated String
    }
}
