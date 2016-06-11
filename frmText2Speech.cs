//*************************************************************************
// Name: frmText2Speech.cs
// Programmer: Curtis N Frank
// Date: 4/13/2016
// Purpose: This application accepts user input, then plugs the
//          string value into a Windows Speech Synthesizer class
//          object to convert it to speech.
//*************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;  // added assembly reference

namespace TextToSpeechForm
{
    // main form
    public partial class frmText2Speech : Form
    {    
        // constructor
        public frmText2Speech()
        {
            InitializeComponent();
        }

        // speak button click event handler
        private void button1_Click(object sender, EventArgs e)
        {
            // initialize a new instance of the SpeechSynthesizer
            using(SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                // configure the audio output
                synth.SetOutputToDefaultAudioDevice();

                // convert textbox input to string
                string input = Convert.ToString(txtInput.Text);

                // plug the string into synthesizer
                synth.Speak(input);

                // send the focus to textbox,
                // select all text
                txtInput.Focus();
                txtInput.SelectAll();
            }
        }

        // clear button click event handler
        private void button2_Click(object sender, EventArgs e)
        {
            // clear textbox
            txtInput.Text = "";

            // send the focus to textbox
            txtInput.Focus();
        }

        // form loading event handler
        private void Form1_Load(object sender, EventArgs e)
        {
            // instantiate new thread
            MyThread t1 = new MyThread();

            // wrap thread and assign method
            Thread splashThread = new Thread(new ThreadStart(t1.SplashStart));

            // start thread
            splashThread.Start();

            // pause 5 seconds
            Thread.Sleep(5000);

            // abort thread
            splashThread.Abort();
        }
    }

    // splash screen thread
    public class MyThread
    {
        // instantiate form object
        mySplashScreen splash = new mySplashScreen();

        // class method
        public void SplashStart()
        {
            // run splash screen
            Application.Run(splash);
        }
    }
}
