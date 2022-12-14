using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using TMPro;

public class Reconnaissancevocal : MonoBehaviour
{
    [SerializeField] TMP_Text AffichageTextHaut;
    [SerializeField] TMP_Text AffichageTextBas;
    private KeywordRecognizer keyWordRecognizer;

    public string wordUp = "";
    public string wordDown = "";

    int champLexical = 0;

    TextGenerator textGenerator;

    void Start()
    {
        //RandomWord

        RandomizeWords();

        //Reconnaisance vocal


        keyWordRecognizer = new KeywordRecognizer(WordArrays.WordList[0].Concat(WordArrays.WordList[1]).ToArray());

        keyWordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keyWordRecognizer.Start();
    }
    string RandomWord(int Xx_ChampLexical_xX)
    {
        string[] LexicalField = WordArrays.WordList[Xx_ChampLexical_xX];

        int randomWord = UnityEngine.Random.Range(0, LexicalField.Length);

        return LexicalField[randomWord];

    }

    void RandomizeWords()
    {
        string wordUpSave = wordUp;
        string wordDownSave = wordDown;

        wordUp = RandomWord(champLexical);
        wordDown = RandomWord(champLexical);

        while (wordUpSave == wordUp)
        {
            wordUp = RandomWord(champLexical);
        }

        while (wordDownSave == wordDown)
        {
            wordDown = RandomWord(champLexical);
        }

        while (wordDown == wordUp)
        {
            wordDown = RandomWord(champLexical);
        }

        AffichageTextHaut.text = wordUp;
        AffichageTextBas.text = wordDown;
    }

    void ChampLexical()
    {
        int champLexical = UnityEngine.Random.Range(0, WordArrays.WordList.Length);
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        if (speech.text == wordUp)
        {
            Up();
            RandomizeWords();
        }

        if (speech.text == wordDown)
        {
            Down();
            RandomizeWords();
        }

        if (speech.text == "Malvina")
        {
            RandomizeWords();
        }
    }
    
    private void Up()
    {
        transform.Translate(0, 1,0);
    }

    private void Down()
    {
        transform.Translate(0, -1, 0);
    }
}
