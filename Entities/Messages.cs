namespace CrosswordAssistant.Entities
{
    public static class Messages
    {
        public static string NoFile { get; } = "ErrorNoFile";
        public static string PatternModeMessage { get; } = "Podaj wzorzec i kliknij Szukaj...";
        public static string AnagramModeMessage { get; } = "Podaj litery lub znak . i kliknij Szukaj...";
        public static string MetagramModeMessage { get; } = "Podaj wyraz i kliknij Szukaj...";
        public static string LengthModeMessage { get; } = "Wybierz dodatkowe filtry i kliknij Szukaj...";
        public static string EmptyPattern { get; } = "Wzorzec nie zawiera żadnych znaków.";

    }
}
