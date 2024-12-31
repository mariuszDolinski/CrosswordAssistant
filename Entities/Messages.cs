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
        public static string VersionInfo { get; } = "Pomocnik szaradzisty v2.6.1" + Environment.NewLine +
                "Autor: Mariusz Doliński" + Environment.NewLine + "© 2024";
        public static string MergeDictsInfo { get; } = "Wczytaj plik z wyrazami, które chcesz dodać do bieżącego słownika";
        public static string PatternInfo { get; } = "Wyszukuje wyrazy posiadające te same litery na tych" +
            " samych pozycjach co w podanym wzorcu. Znak kropki (.) zastępuje dowolną literę," +
            " np. do wzorca T..C.A dopasowane zostałaby wyrazy TERCJA, TARCZA, itp.";
        public static string AnagramInfo { get; } = "Wyszukuje anagramy podanego wyrazu, tzn. wyrazy zawierające" +
            " dokładnie te same litery, ale w innej kolejności. Na przykład dla wyrazu MONTER dopasowane zostałyby" +
            " wyrazy REMONT, MENTOR, itp. Dodatkowo znak kropki (.) zastępuję dowolną literę, np. dla wzorca JAKB.." +
            " znalezione zostałyby wyszystkie wyrazy zawierjące litery J,A,K,B i dwie inne dowolne litery, np." +
            " JABŁKO, UBIJAK.";
        public static string MetagramInfo { get; } = "Wyszukuje wszystkie metagramy podango wyrazu, tzn. słowa" +
            " różniące się od niego dokładnie jedną literą, np. KLATKA, KLAMKA. W tym trybie we wzorcu dopuszczalne" +
            " są tylko litery.";
        public static string LengthInfo { get; } = "Wyszukuje wszystkie wyrazy o podanej ilości liter. " +
            "Można podać dokładną ilość liter lub przedział do którego ma należeć, wliczając jego krańce. " +
            "W przypadku podawania przedziału, jeden z krańców można pozostawić pusty, np. podając wartość 'od' 5 " +
            "oraz wartość 'do' pustą, zwrócone zostaną tylko wyrazy o ilości liter 5 lub więcej. Analogicznie zadziała " +
            "pozostawienie pustego pola 'od'." + Environment.NewLine + Environment.NewLine +
            "UWAGA. Gdy filtr Długość jest zaznaczony, pole ze wzorcem może pozostać puste, wówczas filtrowane są " +
            "wszystkie wyrazy ze słownika.";
        public static string UlozSamInfo { get; } = "W tym trybie wzorcem jest ciąg cyfr od 1 do 8." +
            " Cyfry wskazują do której grupy liter należą poszczególne litery szukanego słowa, np. gdyby wzorcem" +
            " był ciąg 2341, to dopasowane zostałyby wszystkie wyrazy czteroliterowe, dla których pierwsza litera byłaby z grupy 2.," +
            " druga z grupy 3., itd. Domyślnie 32 litery polskiego alfabetu podzielone zostały na 8 grup po cztery litery." +
            " Konfigurację grup można dowolnie zmieniać. Nie wszystkie grupy muszą mieć przypisane litery.";
        public static string PlusMinus1Info { get; } = "W tym trybie wyszukiwane są wszystkie wyrazy, które powstają" +
            " z danego wyrazu, poprzez dodanie lub odjęcie dokładnie jednej litery, np. SALA -> SALWA, PROSTO -> PROSO." +
            " We wzorcu dozwolone są jedynie litery.";
        public static string ScrabbleInfo { get; } = "W tym trybie wyszukiwane są wszystkie wyrazy, które można ułożyć " +
            "z liter podanych we wzorcu. We wzorcu można użyć maksymalnie dwóch znaków kropki (.) zatępjących dowolną literę. " +
            "Wzorzec powinien mieć od 4 do 15 znaków. Dopasowane wyrazy pogrupowane są według ilości znaków, " +
            "w nawiasie podana jest podstawowa punktacja słowa w grze Scrabble (nie uwzględniająca dodatkowych premii " +
            "oraz liter użytych jako mydła (znak kropki)). ";
        public static string FiltersInfo { get; } = "Dodatkowe filtry w zakładce Szaradzista pozwalają ograniczyć ilość dopsowań " +
            "dla wyszukiwań z tej zakładki. Dla filtrów 'Tylko wyrazy niezawierające' oraz 'Tylko wyrazy zawierające' można po przecinku podać kilka wyrażeń; " +
            "w takim przypadku dopasowane zostaną odpowiednio wyrazy niezawierające żadnego z podanych po przecinku wyrażeń/liter lub zawierające wszystkie podane po przecinku wyrażenia/litery.";
        public static string SubwordInfo { get; } = "W tym trybie wyszukiwane są wyrazy, które można utworzyć z wyrazu wzorca, " +
            "poprzez usunięcie z niego niektórych liter, np. dla wzorca 'tatarak' dopasowane zostaną m. in. wyrazy: " +
            "tata, atak, rak. We wzorcu dozwolone są jedynie litery.";
        public static string SuperwordInfo { get; } = "W tym trybie wyszukiwane są wyrazy, które można utworzyć z wyrazu wzorca, " +
            "poprzez dodanie do niego dodatkowych liter (bez zmiany kolejności liter we wzorcu), np. dla wzorca 'trawa' dopasowane zostaną m. in. wyrazy: " +
            "TRAtWA, alTeRnAtyWA. We wzorcu dozwolone są jedynie litery.";
        public static string StenoanagramwordInfo { get; } = "W tym trybie zwracane są wszystkie wyrazy, " +
            "dla których podany we wzorcu wyraz jest stenoanagramem. Stenoanagramy to wyrazy powstałe z " +
            "niepowtarzalnych liter danego wyrazu, np. stenoanagramem wyrazu 'brakarka' jest np. wyraz 'bark'. " +
            "We wzorcu dozwolone są tylko litery. Dodatkowo litery we wzorcu nie mogą się powtarzać.";
        public static string WordInWordInfo { get; } = "W tym trybie wyszukiwane są wyrazy pasujące do podanego wzorca. " +
            "Ponadto litery, które we wzorcu były oznaczone kropką muszą również tworzyć słowo ze słownika, np. " +
            "dla wzorca SZ.... dopasowane zostaną m. in. wyrazy SZRAMA, SZKRAB; natomiast np. wyraz SZAŁAS nie zostaie " +
            "dopasowany, gdyż wyraz AŁAS nie występuje w słowniku.";
        
        public static string Shortcuts { get; } = "Dostępne skróty klawiaturowe:" + Environment.NewLine +
            "Enter - uruchamia wyszukiwanie dla aktualnego wzorca" + Environment.NewLine +
            "F6 - zaznacza wzorzec" + Environment.NewLine +
            "Ctrl+1 - tryb Wzorzec" + Environment.NewLine +
            "Ctrl+2 - tryb Anagram" + Environment.NewLine +
            "Ctrl+3 - tryb Metagram" + Environment.NewLine +
            "Ctrl+4 - tryb Plus/Minus 1" + Environment.NewLine +
            "Ctrl+5 - tryb Długość" + Environment.NewLine +
            "Ctrl+6 - filtr 'Tylko wyrazy zaczynające się od'" + Environment.NewLine +
            "Ctrl+7 - filtr 'Tylko wyrazy kończące się na'" + Environment.NewLine +
            "Ctrl+8 - filtr 'Tylko wyrazy zawierające'" + Environment.NewLine +
            "Ctrl+9 - filtr 'Tylko wyrazy niezawierające'";

    }
}
