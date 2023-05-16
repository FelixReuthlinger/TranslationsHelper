using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TranslationsHelper.models;

public abstract class Translatable
{
    public abstract List<string> Translate();

    protected string TranslateTokenToPair(string token)
    {
        Regex invalidCharToken = new Regex("[^a-zA-Z0-9_$]");
        Regex invalidCharText = new Regex("[^a-zA-Z0-9_]");
        string plainToken = invalidCharToken.Replace(token, "");
        string plainText = invalidCharText.Replace(plainToken, "");
        if (plainToken == "") return "";
        return $"{plainText}: \"{Localization.instance.Localize(plainToken)}\"";
    }
}