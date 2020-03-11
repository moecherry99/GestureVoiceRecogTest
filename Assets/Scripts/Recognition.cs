using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class Recognition : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;

    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Add any extra words here for actions
    void Start()
    {
        // Add go to dictionary
        keywords.Add("go", () =>
        {
            GoCalled();
        });

        // Add yes to dictionary
        keywords.Add("yes", () =>
        {
            YesCalled();
        });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeyWordRecognizerOnPhraseRecognized;
        keywordRecognizer.Start();
    }

    // if keyword is in the list of recognized words
    void KeyWordRecognizerOnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;

        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    // If Go is said, call this method
    void GoCalled()
    {
        Debug.Log("You just said Go");
    }

    // If Yes is said, call this method
    void YesCalled()
    {
        Debug.Log("You just said Yes");
    }

}


