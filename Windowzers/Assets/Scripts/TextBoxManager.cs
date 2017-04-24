using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {


	public GameObject textBox;	// to access the panel 
	public Text theText;

	public TextAsset textFile;	// to access the text file 
	public string[] textLines;  // array of things want to say 

	public int currentLine; // to say where text line starts
	public int endAtLine;	// to say where text line ends


	void Start () {

		if (textFile != null) // as long as there is a textfile 
		{
			textLines = (textFile.text.Split ('\n')); 
		}

		if (endAtLine == 0) 
		{
			endAtLine = textLines.Length - 1;
		}
		
	}

	void Update()
	{
	//	Debug.Log(currentLine); 
	//	Debug.Log(textLines.Length);

		theText.text = textLines[currentLine]; //places the file as the currentLine

		// this moves through the lines of text
		if(Input.GetKeyDown(KeyCode.Space) ||Input.GetKeyDown(KeyCode.Joystick1Button1) && currentLine < textLines.Length) //to cycle through the story
			
	//	if(Input.GetKeyDown(KeyCode.Space && currentLine < textLines.Length))
	//	if (Input.GetKeyDown(KeyCode.Return)) 
		{
			currentLine += 1;
		}

		// this gets rid of the panel at the end of the text 

		if (currentLine > endAtLine) 		// checks if there is no more lines in the txt file then closes the text box
		{
			textBox.SetActive (false);	
			currentLine = 0;
		}	

	}

}
