// WARNING: This feature is deprecated. Use the "Native References" folder instead.
// Right-click on the "Native References" folder, select "Add Native Reference",
// and then select the static library or framework that you'd like to bind.
//
// Once you've added your static library or framework, right-click the library or
// framework and select "Properties" to change the LinkWith values.

using ObjCRuntime;

[assembly: LinkWith("libiSpeechSDK.a", 
LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.ArmV7 | LinkTarget.Arm64, 
SmartLink = true, 
ForceLoad = true,
IsCxx = true, 
Frameworks = "CFNetwork Security SystemConfiguration AudioToolbox UIKit Foundation CoreGraphics"

)]
