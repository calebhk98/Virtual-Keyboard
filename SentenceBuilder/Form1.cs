using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SentenceBuilder
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {

            InitializeComponent();

            createLetters();//This runs as soons as the form is real. This will create the letter buttons
        }
        
        List<string> words = new List<string>();//This houses all the words that will be created. 
		//Technically only needed to position each button, could also be replaced by a simple int counter

		//This is my dynamic code.
		//This uses 83 lines to create an intial 52 buttons, with any new buttons being added as well.  
		//Add the 2 lines before at 19 and 24 for a total of 85 lines.
        public void createLetters(){
            string[] letters = { "a", "b", "c", "d","e","f","g","h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t",
				"u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
				"Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            //this is the text of the letters.
			//Can add up to 8 new letters/words before over taking the dynamic buttons.  
            int x = 0;//This keeps track of the number of buttons on a line
            int y = 0;//This keeps track of the lines


            for (int i = 0; i < letters.Length; i++){
                Button newButton = new Button();//This creates a new button
                this.Controls.Add(newButton);//This adds the button to the form 
                newButton.Show();//This makes the button visible to the user. Sometimes not nesccary, but good practice
                newButton.Visible = true;//This  makes the button visible to the user. Sometimes not nesccary, but good practice
				newButton.Text = letters[i];//This sets the text of the button to the respective letter
                
				//The next 6 lines could probably be reduced to 2 with the proper math
                if (i % 10 == 0) {
                    x = 0;//resets the x to start over from the begining of the line
                    y++;//Moves down 1 line
                }//This checks to see if there has been 10 letters, and if so, it goes to the next line
				newButton.Left = 50+x*75;//Sets the X value of the button compared to the left side of the form Beware, different X than the variable
				newButton.Top = 300+y*25;//Sets the Y value of the button, compared to the top of the form.  Beware, different Y than the variable
				newButton.Click += new System.EventHandler(this.letters_Click);//This is weird. 
				//It basically sets the Click event to the letters_Click function in this form. 
				//Will have to try this in other programs
                x++;//Moves each button over by 1

            }//This goes through all the letters

        }//This runs at the begining of the program once.

        public void createButtons()
        {

			int x = 0;//This keeps track of the number of buttons on a line
			int y = 0;//This keeps track of the lines

			//52
			for (int i = 0; i < words.Count; i++)
            {
                Button newButton = new Button();//This creates a new btn
                this.Controls.Add(newButton); //This adds the btn to the form
				newButton.Show();//This makes the button visible to the user. Sometimes not nesccary, but good practice
				newButton.Visible = true;//This  makes the button visible to the user. Sometimes not nesccary, but good practice
				newButton.Text = words[i];//This sets the text of the button to the respective word
				//Could possibly be set up to simply recieve the new word.

				if (i % 10 == 0) {
                    x = 0;//resets the x to start over from the begining of the line
                    y++;//Moves down 1 line
                }//This checks to see if there has been 10 words, and if so, it goes to the next line
				newButton.Left = 50 + x * 75;//Sets the X value of the button compared to the left side of the form. Beware, different X than the variable
				newButton.Top = 450 + y * 25;//Sets the Y value of the button, compared to the top of the form.  Beware, different Y than the variable
				newButton.Click += new System.EventHandler(this.letters_Click);//This basically adds the letters_click function
				//From this form to the click event
                x++;//Moves each button over by 1

            }//This goes through all the letters

        }//This runs only when the user creates a new btn

        public void letters_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;//This enables the sentence to prevent it the sentence from being erased everytime. 
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
           
            sentence.Text += ((Button)sender).Text;//This adds the text of the button to the sentence
			//Basically it checks to see the button of the sender sent to the function. It then grabs the buttons text, 
			//allowing it to just copy the text of the button. 
			//Will be much harder if you want a different text than what appears in the text, unless you want the same thing for 
			//All buttons that come to this function

        }//This runs whenever a button(besides space) is clicked

		private void AddingButtom_Click( object sender, EventArgs e ) {

			words.Add(sentence.Text);//THis just sends the word to the words list. 
			//Could prob be changed to send to the createButton(); instead
			createButtons();//This just runs the createButtons function
		}//Whenever the add button Button is clicked, this runs

		//This is the original code
		private void clearBtn_Click(object sender, EventArgs e)
        {
                sentence.Text = "";//This resets the sentence to nothing            
        }//Runs when the user click clear

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();//This closes the form
        }//Runs when the user clicks close

		private void spaceBtn_Click( object sender, EventArgs e ) {
			if(sentence.Enabled == false) {
				sentence.Enabled = true;//This enables the sentence to prevent it the sentence from being erased everytime.
				sentence.Text = "";//This resets the sentence to nothing
			}//This checks to see if this is the first character
			sentence.Text += " ";//This adds a space to the sentence
		}//This runs whe the space is clicked

		//Everything after this can be gotten rid of if wanted to, just adds the words above the sentence.
		//Meaning 240 lines are used to create 24 buttons

		//These functions run when the button with the word beside btn is clicked. They all do similar things
		//They all check if they are the first to be clicked(could be a function but is only 5 lines, so idc.
		//If they are the first, they clear the text. 
		//After that, they add their letter. 
		

//
/*
		private void btnA_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "A";//This adds A to the sentence
        }

        private void btn_a_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "a";//This adds a to the sentence
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "An";//This adds An to the sentence
        }

        private void btn_an_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "an";//This adds an to the sentence
        }

        private void btnThe_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "The";//This adds The to the sentence
        }

        private void theBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "the";//This adds the to the sentence
        }

        private void manBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "man";//This adds man to the sentence
        }

        private void womanBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "woman";//This adds woman to the sentence
        }

        private void dogBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "dog";//This adds dog to the sentence
        }

        private void catBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "cat";//This adds cat to the sentence
        }

        private void carBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "car";//This adds car to the sentence
        }

        private void bicycleBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "bicycle";//This adds bicycle to the sentence
        }

        private void beautifulBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "beautiful";//This adds beautiful to the sentence
        }

        private void bigBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "big";//This adds big to the sentence
        }

        private void smallBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "small";//This adds small to the sentence
        }

        private void strangeBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "strange";//This adds strange to the sentence
        }

        private void lookedAtBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "looked at";//This adds looked at to the sentence
        }

        private void rodeBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "rode";//This adds rode to the sentence
        }

        private void spokeToBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "spoke to";//This adds spoke to to the sentence
        }

        private void laughedAtBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "laughed at";//This adds laughed at to the sentence
        }

        private void droveBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "drove";//This adds drove to the sentence
        }

       

        private void periodBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += ".";//This adds . to the sentence
        }

        private void exclamationBtn_Click(object sender, EventArgs e)
        {
            if (sentence.Enabled == false)
            {
                sentence.Enabled = true;
                sentence.Text = "";//This resets the sentence to nothing
            }//This checks to see if this is the first character
            sentence.Text += "!";//This adds ! to the sentence
        }
		*/
    }
}
