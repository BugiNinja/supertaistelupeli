
using UnityEngine;
using UnityEditor;

public class ActionsWindow : EditorWindow {

    GameObject activeGameObject;
    ActionHandler ah;
    Actions[] actions;
    [MenuItem("Window/Actions")]
    public static void ShowWindow()
    {
        GetWindow<ActionsWindow>("Actions");
        
    }

	void OnGUI()
    {
       
        activeGameObject = Selection.activeGameObject;
        if(activeGameObject != null)
        {
            ah = activeGameObject.GetComponent<ActionHandler>();
        }        
        
        if (ah != null)
        {
            actions = ah.actions;
            Movement movement = activeGameObject.GetComponent<Movement>();
            if (movement == null)
            {
                if (GUILayout.Button("Add Movement"))
                {
                    movement = activeGameObject.AddComponent<Movement>();
                }
            }
            else
            {
                if (GUILayout.Button("Remove Movement"))
                {
                    DestroyImmediate(movement);
                }
            }
        }

    }
}
