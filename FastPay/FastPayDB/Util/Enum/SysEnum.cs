using System.ComponentModel;

namespace FastPayDB.Util.Enum;

public enum DataTypeEnum
{
    [Description("Int")]
    Int = 1,

    [Description("Float")]
    Float = 2,

    [Description("String")]
    String = 3,

    [Description("Date")]
    Date = 4,
}

public enum SocialMedia
{
    [Description("Facebook")]
    Facebook = 1,
    [Description("Google")]
    Google = 2,
    [Description("Twitter")]
    Twitter = 3,
}

public enum ControlTypeEnum
{
    [Description("DropList")]
    DropList = 1,

    [Description("CheckList")]
    CheckList = 2,

    [Description("RadioList")]
    RadioList = 3,

    [Description("TextDate")]
    TextDate = 4,

    [Description("TextInt")]
    TextInt = 5,

    [Description("TextFloat")]
    TextFloat = 6,

    [Description("TextEmail")]
    TextEmail = 7,

    [Description("TextPhone")]
    TextPhone = 8,

    [Description("TextMultiline")]
    TextMultiline = 9,

    [Description("TextLabel")]
    TextLabel = 10,

    [Description("TextString")]
    TextString = 11,

    [Description("TextPassword")]
    TextPassword = 12,

    [Description("Checkbox")]
    Checkbox = 13,

    [Description("Setting")]
    Setting = 14,



}