using System;
using System.Collections.Generic;

[Serializable]
public class Phrase {
    public List<Translation> translations;
    public int id;
}

[Serializable]
public class Translation {
    public string language;
    public string text;
}