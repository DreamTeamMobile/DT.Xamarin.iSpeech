namespace DT.iSpeech
{
    public enum _ISpeechErrorCode : uint
    {
        InvalidAPIKey = 1,
        UnableToConvert = 2,
        NotEnoughCredits = 3,
        NoActionSpecified = 4,
        InvalidText = 5,
        TooManyWords = 6,
        InvalidTextEntry = 7,
        InvalidVoice = 8,
        InvalidFileFormat = 12,
        InvalidSpeed = 13,
        InvalidDictionary = 14,
        InvalidBitrate = 15,
        InvalidFrequency = 16,
        InvalidAliasList = 17,
        AliasMissing = 18,
        InvalidContentType = 19,
        AliasListTooComplex = 20,
        CouldNotRecognize = 21,
        OptionNotEnabled = 30,
        NoAPIAccess = 997,
        UnsupportedOutputType = 998,
        InvalidRequest = 999,
        TrialPeriodExceeded = 100,
        APIKeyDisabled = 101,
        InvalidRequestMethod = 1000,
        NoInputAvailable = 301,
        NoInternetConnection = 302,
        SDKIsBusy = 303,
        SDKInterrupted = 304,
        CouldNotActiveAudioSession = 305,
        CouldNotStartAudioQueue = 306,
        ServerDied = 307,
        LostInput = 308,
        BadHost = 309,
        UnknownError = 399
    }


    public enum ISFreeFormType : uint
    {
        ISFreeFormTypeSMS = 1,
        ISFreeFormTypeVoicemail = 2,
        ISFreeFormTypeDictation = 3,
        ISFreeFormTypeMessage = 4,
        ISFreeFormTypeInstantMessage = 5,
        ISFreeFormTypeTranscript = 6,
        ISFreeFormTypeMemo = 7,
    }
}
