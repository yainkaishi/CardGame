using System.Collections.Generic;

public static class LocalizationManager
{
    private static Dictionary<string, string> japanese;
    private static Dictionary<string, string> english;

    private static string currentLanguage = "JP";

    static LocalizationManager()
    {
        japanese = new Dictionary<string, string>();
        english = new Dictionary<string, string>();

        // ===== 日本語 =====
        japanese.Add("CARD_1_NAME", "カード1");
        japanese.Add("CARD_1_DESC", "説明1");

        japanese.Add("CARD_2_NAME", "カード2");
        japanese.Add("CARD_2_DESC", "説明2");

        japanese.Add("CARD_3_NAME", "カード3");
        japanese.Add("CARD_3_DESC", "説明3");

        japanese.Add("CARD_4_NAME", "カード4");
        japanese.Add("CARD_4_DESC", "説明4");

        japanese.Add("CARD_5_NAME", "カード5");
        japanese.Add("CARD_5_DESC", "説明5");

        japanese.Add("CARD_6_NAME", "カード6");
        japanese.Add("CARD_6_DESC", "説明6");

        japanese.Add("CARD_7_NAME", "カード7");
        japanese.Add("CARD_7_DESC", "説明7");

        japanese.Add("CARD_8_NAME", "カード8");
        japanese.Add("CARD_8_DESC", "説明8");

        japanese.Add("CARD_9_NAME", "カード9");
        japanese.Add("CARD_9_DESC", "説明9");

        japanese.Add("CARD_10_NAME", "カード10");
        japanese.Add("CARD_10_DESC", "説明10");

        japanese.Add("CARD_11_NAME", "カード11");
        japanese.Add("CARD_11_DESC", "説明11");

        // ===== 英語 =====
        english.Add("CARD_1_NAME", "Card 1");
        english.Add("CARD_1_DESC", "Description 1");

        english.Add("CARD_2_NAME", "Card 2");
        english.Add("CARD_2_DESC", "Description 2");

        english.Add("CARD_3_NAME", "Card 3");
        english.Add("CARD_3_DESC", "Description 3");

        english.Add("CARD_4_NAME", "Card 4");
        english.Add("CARD_4_DESC", "Description 4");

        english.Add("CARD_5_NAME", "Card 5");
        english.Add("CARD_5_DESC", "Description 5");

        english.Add("CARD_6_NAME", "Card 6");
        english.Add("CARD_6_DESC", "Description 6");

        english.Add("CARD_7_NAME", "Card 7");
        english.Add("CARD_7_DESC", "Description 7");

        english.Add("CARD_8_NAME", "Card 8");
        english.Add("CARD_8_DESC", "Description 8");

        english.Add("CARD_9_NAME", "Card 9");
        english.Add("CARD_9_DESC", "Description 9");

        english.Add("CARD_10_NAME", "Card 10");
        english.Add("CARD_10_DESC", "Description 10");

        english.Add("CARD_11_NAME", "Card 11");
        english.Add("CARD_11_DESC", "Description 11");
    }

    public static void SetLanguage(string languageCode)
    {
        currentLanguage = languageCode;
    }

    public static string GetText(string key)
    {
        if (currentLanguage == "JP")
            return japanese.ContainsKey(key) ? japanese[key] : key;

        return english.ContainsKey(key) ? english[key] : key;
    }
}
