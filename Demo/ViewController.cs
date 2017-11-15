using System;
using DT.iSpeech;
using Foundation;
using UIKit;

namespace Demo
{
    public partial class ViewController : UIViewController, IISSpeechRecognitionDelegate
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
        }

        partial void Speak(Foundation.NSObject sender)
        {
            TextView.EndEditing(true);
            var synthesis = new ISSpeechSynthesis(TextView.Text);
            if (!synthesis.Speak(out var error))
            {
                System.Console.WriteLine(error);
            }
        }

        private ISSpeechRecognition _recognition;

        partial void Recognize(Foundation.NSObject sender)
        {
            _recognition = _recognition ?? new ISSpeechRecognition();
            _recognition.FreeformType = ISFreeFormType.ISFreeFormTypeMemo;
            _recognition.WeakDelegate = this;
            if (!_recognition.ListenAndRecognizeWithTimeout(10, out var error))
            {
                System.Console.WriteLine(error);
            }
        }

        partial void Commands(Foundation.NSObject sender)
        {
            _recognition = new ISSpeechRecognition();
            _recognition.WeakDelegate = this;
            _recognition.AddAlias("officers", new[] { "Mike", "Heath", "Rocco", "Wes", "Florencio" });
            _recognition.AddCommand("call %officers%");
            if (!_recognition.ListenAndRecognizeWithTimeout(10, out var error))
            {
                System.Console.WriteLine(error);
            }
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            TextView.EndEditing(true);
        }

        public void DidGetRecognitionResult(ISSpeechRecognition speechRecognition, ISSpeechRecognitionResult result)
        {
            Console.WriteLine("Result: {0} with confidence {1}", result.Text, result.Confidence);
            Label.Text = result.Text;
        }

        [Export("recognitionCancelledByUser:")]
        public void RecognitionCancelledByUser(ISSpeechRecognition speechRecognition)
        {
            Console.WriteLine(nameof(RecognitionCancelledByUser));
        }

        [Export("recognitionDidBeginRecording:")]
        public void RecognitionDidBeginRecording(ISSpeechRecognition speechRecognition)
        {
            Console.WriteLine(nameof(RecognitionDidBeginRecording));
        }

        [Export("recognitionDidFinishRecording:")]
        public void RecognitionDidFinishRecording(ISSpeechRecognition speechRecognition)
        {
            Console.WriteLine(nameof(RecognitionDidFinishRecording));
        }
    }
}
