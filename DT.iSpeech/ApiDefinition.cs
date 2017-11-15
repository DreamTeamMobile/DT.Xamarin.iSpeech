using System;
using Foundation;
using ObjCRuntime;

namespace DT.iSpeech
{
    // typedef void (^ISSpeechSynthesisHandler)(NSError *, BOOL);
    delegate void ISSpeechSynthesisHandler(NSError arg0, bool arg1);

    // @protocol ISSpeechSynthesisDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ISSpeechSynthesisDelegate
    {
        // @optional -(void)synthesisDidStartSpeaking:(ISSpeechSynthesis *)speechSynthesis;
        [Export("synthesisDidStartSpeaking:")]
        void SynthesisDidStartSpeaking(ISSpeechSynthesis speechSynthesis);

        // @optional -(void)synthesisDidFinishSpeaking:(ISSpeechSynthesis *)speechSynthesis userCancelled:(BOOL)userCancelled;
        [Export("synthesisDidFinishSpeaking:userCancelled:")]
        void SynthesisDidFinishSpeaking(ISSpeechSynthesis speechSynthesis, bool userCancelled);

        // @optional -(void)synthesis:(ISSpeechSynthesis *)speechSynthesis didFailWithError:(NSError *)error;
        [Export("synthesis:didFailWithError:")]
        void Synthesis(ISSpeechSynthesis speechSynthesis, NSError error);
    }

    // @interface ISSpeechSynthesis : NSObject
    [BaseType(typeof(NSObject))]
    interface ISSpeechSynthesis
    {
        [Wrap("WeakDelegate")]
        ISSpeechSynthesisDelegate Delegate { get; set; }

        // @property (nonatomic, unsafe_unretained) id<ISSpeechSynthesisDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (copy, nonatomic) NSString * voice;
        [Export("voice")]
        string Voice { get; set; }

        // @property (assign, nonatomic) NSInteger speed;
        [Export("speed")]
        nint Speed { get; set; }

        // @property (assign, nonatomic) NSInteger bitrate;
        [Export("bitrate")]
        nint Bitrate { get; set; }

        // @property (copy, nonatomic) NSString * text;
        [Export("text")]
        string Text { get; set; }

        // -(id)initWithText:(NSString *)text;
        [Export("initWithText:")]
        IntPtr Constructor(string text);

        // -(BOOL)speak:(NSError **)err;
        [Export("speak:")]
        bool Speak(out NSError err);

        // -(void)speakWithHandler:(ISSpeechSynthesisHandler)handler;
        [Export("speakWithHandler:")]
        void SpeakWithHandler(ISSpeechSynthesisHandler handler);

        // -(void)cancel;
        [Export("cancel")]
        void Cancel();
    }

    // @protocol ISConfiguration <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ISConfiguration
    {
        // @required @property (copy, nonatomic) NSString * voice;
        [Abstract]
        [Export("voice")]
        string Voice { get; set; }

        // @required @property (assign, nonatomic) NSInteger speed;
        [Abstract]
        [Export("speed")]
        nint Speed { get; set; }

        // @required @property (assign, nonatomic) NSInteger bitrate;
        [Abstract]
        [Export("bitrate")]
        nint Bitrate { get; set; }

        // @required @property (copy, nonatomic) NSString * locale;
        [Abstract]
        [Export("locale")]
        string Locale { get; set; }

        // @required @property (copy, nonatomic) NSString * model;
        [Abstract]
        [Export("model")]
        string Model { get; set; }

        // @required @property (assign, nonatomic) NSUInteger freeformType;
        [Abstract]
        [Export("freeformType")]
        nuint FreeformType { get; set; }

        // @required @property (assign, nonatomic) BOOL silenceDetectionEnabled;
        [Abstract]
        [Export("silenceDetectionEnabled")]
        bool SilenceDetectionEnabled { get; set; }

        // @required @property (assign, nonatomic) BOOL adaptiveBitrateEnabled;
        [Abstract]
        [Export("adaptiveBitrateEnabled")]
        bool AdaptiveBitrateEnabled { get; set; }
    }

    // @protocol iSpeechSDKDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface iSpeechSDKDelegate
    {
        // @optional -(void)iSpeechSDKDidBeginInterruption:(iSpeechSDK *)sdk;
        [Export("iSpeechSDKDidBeginInterruption:")]
        void ISpeechSDKDidBeginInterruption(iSpeechSDK sdk);

        // @optional -(void)iSpeechSDKDidEndInterruption:(iSpeechSDK *)sdk;
        [Export("iSpeechSDKDidEndInterruption:")]
        void ISpeechSDKDidEndInterruption(iSpeechSDK sdk);
    }

    // @interface iSpeechSDK : NSObject
    [BaseType(typeof(NSObject))]
    interface iSpeechSDK
    {
        // @property (assign, nonatomic) BOOL usesDevServer;
        [Export("usesDevServer")]
        bool UsesDevServer { get; set; }

        // @property (assign, nonatomic) BOOL vibrateOnPrompts;
        [Export("vibrateOnPrompts")]
        bool VibrateOnPrompts { get; set; }

        // @property (assign, nonatomic) BOOL playsSuccessAndFailPrompts;
        [Export("playsSuccessAndFailPrompts")]
        bool PlaysSuccessAndFailPrompts { get; set; }

        // @property (assign, nonatomic) BOOL shouldDeactivateAudioSessionWhenFinished;
        [Export("shouldDeactivateAudioSessionWhenFinished")]
        bool ShouldDeactivateAudioSessionWhenFinished { get; set; }

        // @property (copy, nonatomic) NSString * extraServerParams;
        [Export("extraServerParams")]
        string ExtraServerParams { get; set; }

        // @property (copy, nonatomic) NSString * APIKey;
        [Export("APIKey")]
        string APIKey { get; set; }

        [Wrap("WeakDelegate")]
        iSpeechSDKDelegate Delegate { get; set; }

        // @property (nonatomic, unsafe_unretained) id<iSpeechSDKDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, assign, nonatomic) BOOL isBusy;
        [Export("isBusy")]
        bool IsBusy { get; }

        // @property (readonly, copy, nonatomic) NSString * version;
        [Export("version")]
        string Version { get; }

        // +(iSpeechSDK *)sharedSDK;
        [Static]
        [Export("sharedSDK")]
        iSpeechSDK SharedSDK { get; }

        // -(id<ISConfiguration>)configuration;
        [Export("configuration")]
        ISConfiguration Configuration { get; }

        // -(void)resetSDK;
        [Export("resetSDK")]
        void ResetSDK();

        // -(void)beginInterruption;
        [Export("beginInterruption")]
        void BeginInterruption();

        // -(void)endInterruption;
        [Export("endInterruption")]
        void EndInterruption();
    }

    // @interface ISSpeechRecognitionResult : NSObject
    [BaseType(typeof(NSObject))]
    interface ISSpeechRecognitionResult
    {
        // @property (readonly, copy, nonatomic) NSString * text;
        [Export("text")]
        string Text { get; }

        // @property (readonly, assign, nonatomic) float confidence;
        [Export("confidence")]
        float Confidence { get; }
    }

    // typedef void (^ISSpeechRecognitionHandler)(NSError *, ISSpeechRecognitionResult *, BOOL);
    delegate void ISSpeechRecognitionHandler(NSError error, ISSpeechRecognitionResult result, bool cancelledByUser);

    // @protocol ISSpeechRecognitionDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ISSpeechRecognitionDelegate
    {
        // @required -(void)recognition:(ISSpeechRecognition *)speechRecognition didGetRecognitionResult:(ISSpeechRecognitionResult *)result;
        [Abstract]
        [Export("recognition:didGetRecognitionResult:")]
        void DidGetRecognitionResult(ISSpeechRecognition speechRecognition, ISSpeechRecognitionResult result);

        // @optional -(void)recognition:(ISSpeechRecognition *)speechRecognition didFailWithError:(NSError *)error;
        [Export("recognition:didFailWithError:")]
        void DidFailWithError(ISSpeechRecognition speechRecognition, NSError error);

        // @optional -(void)recognitionCancelledByUser:(ISSpeechRecognition *)speechRecognition;
        [Export("recognitionCancelledByUser:")]
        void RecognitionCancelledByUser(ISSpeechRecognition speechRecognition);

        // @optional -(void)recognitionDidBeginRecording:(ISSpeechRecognition *)speechRecognition;
        [Export("recognitionDidBeginRecording:")]
        void RecognitionDidBeginRecording(ISSpeechRecognition speechRecognition);

        // @optional -(void)recognitionDidFinishRecording:(ISSpeechRecognition *)speechRecognition;
        [Export("recognitionDidFinishRecording:")]
        void RecognitionDidFinishRecording(ISSpeechRecognition speechRecognition);
    }

    // @interface ISSpeechRecognition : NSObject
    [BaseType(typeof(NSObject))]
    interface ISSpeechRecognition
    {
        [Wrap("WeakDelegate")]
        ISSpeechRecognitionDelegate Delegate { get; set; }

        // @property (nonatomic, unsafe_unretained) id<ISSpeechRecognitionDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (copy, nonatomic) NSString * locale;
        [Export("locale")]
        string Locale { get; set; }

        // @property (copy, nonatomic) NSString * model;
        [Export("model")]
        string Model { get; set; }

        // @property (assign, nonatomic) ISFreeFormType freeformType;
        [Export("freeformType")]
        ISFreeFormType FreeformType { get; set; }

        // @property (assign, nonatomic) BOOL silenceDetectionEnabled;
        [Export("silenceDetectionEnabled")]
        bool SilenceDetectionEnabled { get; set; }

        // +(BOOL)audioInputAvailable;
        [Static]
        [Export("audioInputAvailable")]

        bool AudioInputAvailable { get; }

        // -(void)addAlias:(NSString *)alias forItems:(NSArray *)items;
        [Export("addAlias:forItems:")]

        void AddAlias(string alias, string[] items);

        // -(void)addCommand:(NSString *)command;
        [Export("addCommand:")]
        void AddCommand(string command);

        // -(void)addCommands:(NSArray *)commands;
        [Export("addCommands:")]

        void AddCommands(string[] commands);

        // -(void)resetCommandsAndAliases;
        [Export("resetCommandsAndAliases")]
        void ResetCommandsAndAliases();

        // -(BOOL)listen:(NSError **)err;
        [Export("listen:")]
        bool Listen(out NSError err);

        // -(void)finishListenAndStartRecognize;
        [Export("finishListenAndStartRecognize")]
        void FinishListenAndStartRecognize();

        // -(BOOL)listenAndRecognizeWithTimeout:(NSTimeInterval)timeout error:(NSError **)err;
        [Export("listenAndRecognizeWithTimeout:error:")]
        bool ListenAndRecognizeWithTimeout(double timeout, out NSError err);

        // -(void)listenWithHandler:(ISSpeechRecognitionHandler)handler;
        [Export("listenWithHandler:")]
        void ListenWithHandler(ISSpeechRecognitionHandler handler);

        // -(void)listenAndRecognizeWithTimeout:(NSTimeInterval)timeout handler:(ISSpeechRecognitionHandler)handler;
        [Export("listenAndRecognizeWithTimeout:handler:")]
        void ListenAndRecognizeWithTimeout(double timeout, ISSpeechRecognitionHandler handler);

        // -(void)cancel;
        [Export("cancel")]
        void Cancel();
    }

    [Static]
    partial interface Constants
    {
        // extern NSString *const ISVoiceUSEnglishFemale;
        [Field("ISVoiceUSEnglishFemale", "__Internal")]
        NSString ISVoiceUSEnglishFemale { get; }

        // extern NSString *const ISVoiceUSEnglishMale;
        [Field("ISVoiceUSEnglishMale", "__Internal")]
        NSString ISVoiceUSEnglishMale { get; }

        // extern NSString *const ISVoiceUKEnglishFemale;
        [Field("ISVoiceUKEnglishFemale", "__Internal")]
        NSString ISVoiceUKEnglishFemale { get; }

        // extern NSString *const ISVoiceUKEnglishMale;
        [Field("ISVoiceUKEnglishMale", "__Internal")]
        NSString ISVoiceUKEnglishMale { get; }

        // extern NSString *const ISVoiceAUEnglishFemale;
        [Field("ISVoiceAUEnglishFemale", "__Internal")]
        NSString ISVoiceAUEnglishFemale { get; }

        // extern NSString *const ISVoiceUSSpanishFemale;
        [Field("ISVoiceUSSpanishFemale", "__Internal")]
        NSString ISVoiceUSSpanishFemale { get; }

        // extern NSString *const ISVoiceUSSpanishMale;
        [Field("ISVoiceUSSpanishMale", "__Internal")]
        NSString ISVoiceUSSpanishMale { get; }

        // extern NSString *const ISVoiceCHChineseFemale;
        [Field("ISVoiceCHChineseFemale", "__Internal")]
        NSString ISVoiceCHChineseFemale { get; }

        // extern NSString *const ISVoiceCHChineseMale;
        [Field("ISVoiceCHChineseMale", "__Internal")]
        NSString ISVoiceCHChineseMale { get; }

        // extern NSString *const ISVoiceHKChineseFemale;
        [Field("ISVoiceHKChineseFemale", "__Internal")]
        NSString ISVoiceHKChineseFemale { get; }

        // extern NSString *const ISVoiceTWChineseFemale;
        [Field("ISVoiceTWChineseFemale", "__Internal")]
        NSString ISVoiceTWChineseFemale { get; }

        // extern NSString *const ISVoiceJPJapaneseFemale;
        [Field("ISVoiceJPJapaneseFemale", "__Internal")]
        NSString ISVoiceJPJapaneseFemale { get; }

        // extern NSString *const ISVoiceJPJapaneseMale;
        [Field("ISVoiceJPJapaneseMale", "__Internal")]
        NSString ISVoiceJPJapaneseMale { get; }

        // extern NSString *const ISVoiceKRKoreanFemale;
        [Field("ISVoiceKRKoreanFemale", "__Internal")]
        NSString ISVoiceKRKoreanFemale { get; }

        // extern NSString *const ISVoiceKRKoreanMale;
        [Field("ISVoiceKRKoreanMale", "__Internal")]
        NSString ISVoiceKRKoreanMale { get; }

        // extern NSString *const ISVoiceCAEnglishFemale;
        [Field("ISVoiceCAEnglishFemale", "__Internal")]
        NSString ISVoiceCAEnglishFemale { get; }

        // extern NSString *const ISVoiceHUHungarianFemale;
        [Field("ISVoiceHUHungarianFemale", "__Internal")]
        NSString ISVoiceHUHungarianFemale { get; }

        // extern NSString *const ISVoiceBRPortugueseFemale;
        [Field("ISVoiceBRPortugueseFemale", "__Internal")]
        NSString ISVoiceBRPortugueseFemale { get; }

        // extern NSString *const ISVoiceEURPortugueseFemale;
        [Field("ISVoiceEURPortugueseFemale", "__Internal")]
        NSString ISVoiceEURPortugueseFemale { get; }

        // extern NSString *const ISVoiceEURPortugueseMale;
        [Field("ISVoiceEURPortugueseMale", "__Internal")]
        NSString ISVoiceEURPortugueseMale { get; }

        // extern NSString *const ISVoiceEURSpanishFemale;
        [Field("ISVoiceEURSpanishFemale", "__Internal")]
        NSString ISVoiceEURSpanishFemale { get; }

        // extern NSString *const ISVoiceEURSpanishMale;
        [Field("ISVoiceEURSpanishMale", "__Internal")]
        NSString ISVoiceEURSpanishMale { get; }

        // extern NSString *const ISVoiceEURCatalanFemale;
        [Field("ISVoiceEURCatalanFemale", "__Internal")]
        NSString ISVoiceEURCatalanFemale { get; }

        // extern NSString *const ISVoiceEURCzechFemale;
        [Field("ISVoiceEURCzechFemale", "__Internal")]
        NSString ISVoiceEURCzechFemale { get; }

        // extern NSString *const ISVoiceEURDanishFemale;
        [Field("ISVoiceEURDanishFemale", "__Internal")]
        NSString ISVoiceEURDanishFemale { get; }

        // extern NSString *const ISVoiceEURFinnishFemale;
        [Field("ISVoiceEURFinnishFemale", "__Internal")]
        NSString ISVoiceEURFinnishFemale { get; }

        // extern NSString *const ISVoiceEURFrenchFemale;
        [Field("ISVoiceEURFrenchFemale", "__Internal")]
        NSString ISVoiceEURFrenchFemale { get; }

        // extern NSString *const ISVoiceEURFrenchMale;
        [Field("ISVoiceEURFrenchMale", "__Internal")]
        NSString ISVoiceEURFrenchMale { get; }

        // extern NSString *const ISVoiceEURNorwegianFemale;
        [Field("ISVoiceEURNorwegianFemale", "__Internal")]
        NSString ISVoiceEURNorwegianFemale { get; }

        // extern NSString *const ISVoiceEURDutchFemale;
        [Field("ISVoiceEURDutchFemale", "__Internal")]
        NSString ISVoiceEURDutchFemale { get; }

        // extern NSString *const ISVoiceEURDutchMale;
        [Field("ISVoiceEURDutchMale", "__Internal")]
        NSString ISVoiceEURDutchMale { get; }

        // extern NSString *const ISVoiceEURPolishFemale;
        [Field("ISVoiceEURPolishFemale", "__Internal")]
        NSString ISVoiceEURPolishFemale { get; }

        // extern NSString *const ISVoiceEURItalianFemale;
        [Field("ISVoiceEURItalianFemale", "__Internal")]
        NSString ISVoiceEURItalianFemale { get; }

        // extern NSString *const ISVoiceEURItalianMale;
        [Field("ISVoiceEURItalianMale", "__Internal")]
        NSString ISVoiceEURItalianMale { get; }

        // extern NSString *const ISVoiceEURTurkishFemale;
        [Field("ISVoiceEURTurkishFemale", "__Internal")]
        NSString ISVoiceEURTurkishFemale { get; }

        // extern NSString *const ISVoiceEURTurkishMale;
        [Field("ISVoiceEURTurkishMale", "__Internal")]
        NSString ISVoiceEURTurkishMale { get; }

        // extern NSString *const ISVoiceEURGermanFemale;
        [Field("ISVoiceEURGermanFemale", "__Internal")]
        NSString ISVoiceEURGermanFemale { get; }

        // extern NSString *const ISVoiceEURGermanMale;
        [Field("ISVoiceEURGermanMale", "__Internal")]
        NSString ISVoiceEURGermanMale { get; }

        // extern NSString *const ISVoiceRURussianFemale;
        [Field("ISVoiceRURussianFemale", "__Internal")]
        NSString ISVoiceRURussianFemale { get; }

        // extern NSString *const ISVoiceRURussianMale;
        [Field("ISVoiceRURussianMale", "__Internal")]
        NSString ISVoiceRURussianMale { get; }

        // extern NSString *const ISVoiceSWSwedishFemale;
        [Field("ISVoiceSWSwedishFemale", "__Internal")]
        NSString ISVoiceSWSwedishFemale { get; }

        // extern NSString *const ISVoiceCAFrenchFemale;
        [Field("ISVoiceCAFrenchFemale", "__Internal")]
        NSString ISVoiceCAFrenchFemale { get; }

        // extern NSString *const ISVoiceCAFrenchMale;
        [Field("ISVoiceCAFrenchMale", "__Internal")]
        NSString ISVoiceCAFrenchMale { get; }

        // extern NSString *const ISVoiceArabicMale;
        [Field("ISVoiceArabicMale", "__Internal")]
        NSString ISVoiceArabicMale { get; }

        // extern NSString *const iSpeechErrorDomain;
        [Field("iSpeechErrorDomain", "__Internal")]
        NSString iSpeechErrorDomain { get; }

        // extern NSString *const ISLocaleUSEnglish;
        [Field("ISLocaleUSEnglish", "__Internal")]
        NSString ISLocaleUSEnglish { get; }

        // extern NSString *const ISLocaleCAEnglish;
        [Field("ISLocaleCAEnglish", "__Internal")]
        NSString ISLocaleCAEnglish { get; }

        // extern NSString *const ISLocaleGBEnglish;
        [Field("ISLocaleGBEnglish", "__Internal")]
        NSString ISLocaleGBEnglish { get; }

        // extern NSString *const ISLocaleAUEnglish;
        [Field("ISLocaleAUEnglish", "__Internal")]
        NSString ISLocaleAUEnglish { get; }

        // extern NSString *const ISLocaleESSpanish;
        [Field("ISLocaleESSpanish", "__Internal")]
        NSString ISLocaleESSpanish { get; }

        // extern NSString *const ISLocaleMXSpanish;
        [Field("ISLocaleMXSpanish", "__Internal")]
        NSString ISLocaleMXSpanish { get; }

        // extern NSString *const ISLocaleITItalian;
        [Field("ISLocaleITItalian", "__Internal")]
        NSString ISLocaleITItalian { get; }

        // extern NSString *const ISLocaleFRFrench;
        [Field("ISLocaleFRFrench", "__Internal")]
        NSString ISLocaleFRFrench { get; }

        // extern NSString *const ISLocaleCAFrench;
        [Field("ISLocaleCAFrench", "__Internal")]
        NSString ISLocaleCAFrench { get; }

        // extern NSString *const ISLocalePLPolish;
        [Field("ISLocalePLPolish", "__Internal")]
        NSString ISLocalePLPolish { get; }

        // extern NSString *const ISLocaleBRPortuguese;
        [Field("ISLocaleBRPortuguese", "__Internal")]
        NSString ISLocaleBRPortuguese { get; }

        // extern NSString *const ISLocalePTPortuguese;
        [Field("ISLocalePTPortuguese", "__Internal")]
        NSString ISLocalePTPortuguese { get; }

        // extern NSString *const ISLocaleCACatalan;
        [Field("ISLocaleCACatalan", "__Internal")]
        NSString ISLocaleCACatalan { get; }

        // extern NSString *const ISLocaleCNChinese;
        [Field("ISLocaleCNChinese", "__Internal")]
        NSString ISLocaleCNChinese { get; }

        // extern NSString *const ISLocaleHKChinese;
        [Field("ISLocaleHKChinese", "__Internal")]
        NSString ISLocaleHKChinese { get; }

        // extern NSString *const ISLocaleTWChinese;
        [Field("ISLocaleTWChinese", "__Internal")]
        NSString ISLocaleTWChinese { get; }

        // extern NSString *const ISLocaleDKDanish;
        [Field("ISLocaleDKDanish", "__Internal")]
        NSString ISLocaleDKDanish { get; }

        // extern NSString *const ISLocaleDEGerman;
        [Field("ISLocaleDEGerman", "__Internal")]
        NSString ISLocaleDEGerman { get; }

        // extern NSString *const ISLocaleFIFinish;
        [Field("ISLocaleFIFinish", "__Internal")]
        NSString ISLocaleFIFinish { get; }

        // extern NSString *const ISLocaleJAJapanese;
        [Field("ISLocaleJAJapanese", "__Internal")]
        NSString ISLocaleJAJapanese { get; }

        // extern NSString *const ISLocaleKRKorean;
        [Field("ISLocaleKRKorean", "__Internal")]
        NSString ISLocaleKRKorean { get; }

        // extern NSString *const ISLocaleNLDutch;
        [Field("ISLocaleNLDutch", "__Internal")]
        NSString ISLocaleNLDutch { get; }

        // extern NSString *const ISLocaleNONorwegian;
        [Field("ISLocaleNONorwegian", "__Internal")]
        NSString ISLocaleNONorwegian { get; }

        // extern NSString *const ISLocaleRURussian;
        [Field("ISLocaleRURussian", "__Internal")]
        NSString ISLocaleRURussian { get; }

        // extern NSString *const ISLocaleSESwedish;
        [Field("ISLocaleSESwedish", "__Internal")]
        NSString ISLocaleSESwedish { get; }
    }
}
