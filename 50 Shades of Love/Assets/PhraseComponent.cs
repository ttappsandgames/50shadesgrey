using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class PhraseComponent : MonoBehaviour {

	public Button PhraseButton;
	public Text PhraseText;
	private PhrasesRepository phrasesRepository;
	public string placementId = "video";
	private int quantityClicked;

	void Start () {
		phrasesRepository = new PhrasesRepository();
		PhraseButton.onClick.AddListener(ShowAd);
		if (Advertisement.isSupported) {
			Advertisement.Initialize ("1732675");
		}
	}

	private void ShowPhrase() {
		PhraseText.text = phrasesRepository.GetPhrase().translations.First().text;
	}

		void Update ()
		{
			PhraseButton.interactable = Advertisement.IsReady(placementId);
		}

		void ShowAd () {
			quantityClicked += 1;
			ShowPhrase();
			if (quantityClicked == 3) {
				ShowOptions options = new ShowOptions();
				options.resultCallback = HandleShowResult;
				Advertisement.Show(placementId, options);
				quantityClicked = 0;
			}
		}

		void HandleShowResult (ShowResult result)
		{
			if(result == ShowResult.Finished) {

			}else if(result == ShowResult.Skipped) {
				Debug.LogWarning("Video was skipped - Do NOT reward the player");

			}else if(result == ShowResult.Failed) {
				Debug.LogError("Video failed to show");
			}
		}
}
