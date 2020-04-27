using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoryState", menuName = "StoryState", order = 0)]

public class StoryState : ScriptableObject {
    [SerializeField] string spaceTitle;
    [SerializeField] Sprite ContainerImage;
    [TextArea(10, 14)] [SerializeField] string storyText;
    [TextArea(10, 14)] [SerializeField] string options;
    [SerializeField] string[] optionsArray;
    [SerializeField] StoryState[] nextStates;

    public string GetStateTitle () {
        return spaceTitle;
    }

    public Sprite GetStateImage () {
        return ContainerImage;
    }

    public string GetStateText () {
        return storyText;
    }

    public string[] GetStateOptions () {
        return optionsArray;
    }

    public StoryState[] GetNextState () {
        return nextStates; 
    }

}

