using UnityEngine;
using UnityEngine.UI;

public class ExpandNotes : InteractEvent
{
    [SerializeField] GameObject expandedNote;
    public override void Start_Event()
    {
        Collider2D coll = GetComponent<Collider2D>();
        coll.enabled = false;
        onSuccess.AddListener(() => coll.enabled = true);

        Engine.current.dialogueSystem.SetUI(false);
        GameObject clone = Instantiate(expandedNote, Interface.current.canvas);
        Button onClose = clone.GetComponent<Button>();
        onClose.onClick.AddListener(On_Expanded_Closed);
    }

    void On_Expanded_Closed()
    {
        Engine.current.dialogueSystem.SetUI(true);
        onSuccess?.Invoke();
    }
}
