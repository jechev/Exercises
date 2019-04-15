public static class TwoFer
{
    public static string Speak(params string[] name)
    {
        if (name.Length > 0) {
            return $"One for {name}, one for me.";
        }else {
            return "One for you, one for me.";
        }
    }
}
