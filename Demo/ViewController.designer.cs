// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Demo
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UILabel Label { get; set; }

		[Outlet]
		UIKit.UITextView TextView { get; set; }

		[Action ("Commands:")]
		partial void Commands (Foundation.NSObject sender);

		[Action ("Recognize:")]
		partial void Recognize (Foundation.NSObject sender);

		[Action ("Speak:")]
		partial void Speak (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Label != null) {
				Label.Dispose ();
				Label = null;
			}

			if (TextView != null) {
				TextView.Dispose ();
				TextView = null;
			}
		}
	}
}
