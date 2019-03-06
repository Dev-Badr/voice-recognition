using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace Voice_Recognition
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine recengine = new SpeechRecognitionEngine();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            recengine.RecognizeAsync(RecognizeMode.Multiple);
            buttonX2.Enabled = true;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            buttonX2.Enabled = false;
            recengine.RecognizeAsyncStop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] {"H","P", "C"});
            GrammarBuilder gbuilder = new GrammarBuilder();
            gbuilder.Append(commands);
            Grammar grammar = new Grammar(gbuilder);
            recengine.LoadGrammarAsync(grammar);
            recengine.SetInputToDefaultAudioDevice();
            recengine.SpeechRecognized += recengine_speech_recognized;
        }

        void  recengine_speech_recognized(object sender, SpeechRecognizedEventArgs e)

        {
            switch (e.Result.Text)
            {
                case "H":
                        MessageBox.Show("Hello Sir. How are you?");
                        break;
                case "P":
                    richTextBox1.Text += "\nBadr";
                    break;
                case "C":
                    richTextBox1.Text += "\nCool";
                    break;
            }
        }
    }
}
