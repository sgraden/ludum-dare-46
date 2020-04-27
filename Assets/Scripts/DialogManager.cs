using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] Image containerImage;
    [SerializeField] Text spaceTitle;
    [SerializeField] Text sectionDetails;
    [SerializeField] Text Options; //I think this will die soon

    [SerializeField] StoryState startingState; //Initial state loaded via Unity UI
    StoryState currentState; //Current State of the Dialog

    [SerializeField] Canvas buttonContainer; //Place to put option buttons
    [SerializeField] Button button; //Option Button Prefab

    // Start is called before the first frame update
    void Start()
    {
        ManageState(startingState);
        // Button newButton = Instantiate(button);
        // newButton.transform.SetParent(buttonContainer.transform, false);
        
        // SetText();
        // SetImage();
    }

    // Update is called once per frame
    void Update()
    {
        // ManageState(currentState);
    }

    private void ManageState (StoryState state) {
        // StoryState[] nextStates =  state.GetNextState();
        // if (Input.GetKeyDown(KeyCode.Alpha1) && nextStates.Length > 0) {
        //     state = nextStates[0];
        // } else if (Input.GetKeyDown(KeyCode.Alpha2) && nextStates.Length > 1) {
        //     state = nextStates[1];
        // } else if (Input.GetKeyDown(KeyCode.Alpha3) && nextStates.Length > 2) {
        //     state = nextStates[2];
        // } else if (Input.GetKeyDown(KeyCode.Alpha4) && nextStates.Length > 3) {
        //     state = nextStates[3];
        // }else if (Input.GetKeyDown(KeyCode.Alpha5) && nextStates.Length > 4) {
        //     state = nextStates[4];
        // } else {
        //     // Debug.Log("No Corresponding option");
        // }
        currentState = state;
        SetText();
        SetImage();
        createButtons();
    }

    private void SetText () {
        spaceTitle.text = currentState.GetStateTitle();
        sectionDetails.text = currentState.GetStateText();
        // Options.text = state.GetStateOptions();
    }

    private void SetImage () {
        containerImage.sprite = currentState.GetStateImage();
    }

    private void createButtons () {
        var optionsArray = currentState.GetStateOptions();
        var nextStates = currentState.GetNextState();
        
        for (int i = 0; i < optionsArray.Length; i++) {
            Button newButton = Instantiate(button);

            //Text buttonText = Instantiate(Options);
            //buttonText.text = optionsArray[i];
            //buttonText.transform.SetParent(newButton.transform, false);
            newButton.GetComponentInChildren<Text>().text = optionsArray[i];
            newButton.onClick.AddListener(ButtonTest);

            newButton.transform.SetParent(buttonContainer.transform, false);
        }
        
    }

    private void ButtonTest() {
        Debug.Log("Button Clicked");
    }
}
