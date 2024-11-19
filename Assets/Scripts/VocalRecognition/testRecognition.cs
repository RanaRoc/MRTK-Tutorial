using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

public class testVocalReconizer : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    public GameObject targetObject;
    UIScript UI;


    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("Interfacez").GetComponent<UIScript>();
        Debug.Log(UI);

        //Create keywords for keyword recognizer
        keywords.Add("next", () =>
        {
            UI.ChangeProgress();
        });
        
        //Create keywords for keyword recognizer
        keywords.Add("end", () =>
        {
            UI.StopRecipe();
        });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        // if the keyword recognized is in our dictionary, call that Action.
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        // Vérifier si la touche "E" est pressée
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key was pressed.");
            OnEPressed();
        }

        // Vérifier si la touche "R" est pressée
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R key was pressed.");
            OnRPressed();
        }
    }

    void OnEPressed()
    {
        UI.ChangeProgress();
    }

    void OnRPressed()
    {
        UI.StopRecipe();
    }
}
