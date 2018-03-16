using System.Collections.Generic;
using UnityEngine;

public class PhraseJsonParser {

    public List<Phrase> ConvertFrom(string jsonPhrase) {
        return JsonUtility.FromJson<List<Phrase>>(jsonPhrase);
    }
}