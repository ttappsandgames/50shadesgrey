using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace {
    public class PhrasesRepository {

        public List<Phrase> phrases = new List<Phrase>();

        public PhrasesRepository() {
            phrases = ParseDataFromFile().phrases;
        }

        private Phrases ParseDataFromFile() {
            var phrases = new Phrases();
            TextAsset file = Resources.Load("phrases") as TextAsset;
            string content = file.ToString ();
                JsonUtility.FromJsonOverwrite(content, phrases);


            return phrases;
        }

        public Phrase GetPhrase() {
            int randomIndex = Random.Range(0, phrases.Count);
            return phrases[randomIndex];
        }
    }
}