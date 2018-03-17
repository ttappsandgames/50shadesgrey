using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class PhraseComponent : MonoBehaviour {
	private const int QUANTITY_FOR_ADS = 2;

	public Button PhraseButton;
	public Text PhraseText;
	public Text ButtonText;
	private PhrasesRepository phrasesRepository;
	public string placementId = "video";
	private int quantityClicked;

	void Start () {
		quantityClicked = PlayerPrefs.GetInt("quantity_phrases");
		if (quantityClicked >= QUANTITY_FOR_ADS) {
			ButtonText.text = "VER UN VIDEO PARA MAS FRASES";
		}
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
			PlayerPrefs.SetInt("quantity_phrases", quantityClicked);
			if (quantityClicked < QUANTITY_FOR_ADS) {
				ButtonText.text = "OBTENER UNA FRASE";
				ShowPhrase();
			} else if (quantityClicked == QUANTITY_FOR_ADS) {
				ShowPhrase();
				ButtonText.text = "VER UN VIDEO PARA MAS FRASES";
			}
			else {
				ButtonText.text = "VER UN VIDEO PARA MAS FRASES";
				if (quantityClicked > QUANTITY_FOR_ADS) {
					ShowOptions options = new ShowOptions();
					options.resultCallback = HandleShowResult;
					Advertisement.Show(placementId, options);
				}
			}
		}

		void HandleShowResult (ShowResult result)
		{
			if(result == ShowResult.Finished) {
				quantityClicked = 0;
				PlayerPrefs.SetInt("quantity_phrases", quantityClicked);
				ButtonText.text = "OBTENER UNA FRASE";
			}else if(result == ShowResult.Skipped) {
				Debug.LogWarning("Video was skipped - Do NOT reward the player");

			}else if(result == ShowResult.Failed) {
				Debug.LogError("Video failed to show");
			}
		}
}
