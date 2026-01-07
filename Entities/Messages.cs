namespace CrosswordAssistant.Entities
{
    public static class Messages
    {
        public static string NoFile { get; } = "ErrorNoFile";
        public static string PatternModeMessage { get; } = "Podaj wzorzec i kliknij Szukaj...";
        public static string AnagramModeMessage { get; } = "Podaj litery lub znak . i kliknij Szukaj...";
        public static string MetagramModeMessage { get; } = "Podaj wyraz i kliknij Szukaj...";
        public static string LengthModeMessage { get; } = "Wybierz dodatkowe filtry i kliknij Szukaj...";
        public static string UlozSamModeMessage { get; } = "Podaj wzorzec złożony z cyfr 1-8 i kliknij Szukaj...";
        public static string EmptyPattern { get; } = "Wzorzec nie zawiera żadnych znaków.";
        public static string VersionInfo { get; } = "Pomocnik szaradzisty v3.2.5" + Environment.NewLine +
                "Autor: Mariusz Doliński" + Environment.NewLine + "© 2025";
        public static string MergeDictsInfo { get; } = "Wczytaj plik z wyrazami, które chcesz dodać do bieżącego słownika";
        public static string PatternInfo { get; } = "Wyszukuje wyrazy pasujące do podanego wzorca. Znak kropki (.) zastępuje dowolną jedną literę, " +
            "znak zapytania (?) zastępuje jedną lub więcej dowolnych liter. " +
            "Na przykład do wzorca T..C.A dopasowane zostałaby wyrazy TERCJA, TARCZA, itp. " +
            "Do wzorca SZ?A dopasowane zostałyby wszystkie wyrazy zaczynające się na SZ i kończące się na A." +
            Environment.NewLine + Environment.NewLine + "Przycisk LOSUJ wyświetla jedno losowe słowo pasujące do wzorca (dotyczy wszystkich trybów).";
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
            "z liter podanych we wzorcu (niekoniecznie wszystkich). We wzorcu można użyć maksymalnie dwóch znaków kropki (.) zatępjących dowolną literę. " +
            "Wzorzec powinien mieć od 4 do 15 znaków. Dopasowane wyrazy pogrupowane są domyślnie według ilości znaków, " +
            "w nawiasie podana jest podstawowa punktacja słowa w grze Scrabble (nie uwzględniająca dodatkowych premii " +
            "oraz liter użytych jako mydła (znak kropki)). Sposób wyświetlania dopasowań można zmienić w ustawieniach.";
        public static string FiltersInfo { get; } = "Dodatkowe filtry w zakładce Szaradzista pozwalają ograniczyć ilość dopsowań " +
            "dla wyszukiwań z tej zakładki. Aby aktywować daną grupę filtrów należy zaznaczyć w niej przycisk 'Aktywny'" +
            Environment.NewLine + Environment.NewLine + "Dostępne grupy filtrów:" + Environment.NewLine +
            "Początek - filtruje tylko wyrazy zaczynające lub niezaczynające się na podaną literę lub grupę liter" + Environment.NewLine +
            "Koniec - filtruje tylko wyrazy kończące lub niekończące się na podaną literę lub grupę liter" + Environment.NewLine +
            "Zawiera - filtruje tylko wyrazy zawierające oraz\\lub niezawierające podane litery lub wyrażenia. " +
            "Dla filtrów 'Zawiera' można podać po przecinku kilka liter lub wyrażeń. W takim przypadku dopasowane zostaną odpowiednio wyrazy, " +
            "które zawierają/niezwierają każde lub conajmniej jedno z podanych po przecinku wyrażeń/liter, " +
            "w zależności od zaznaczenia opcji ORAZ/LUB. " +
            "W przypadku zaznaczenia jednoczesnie filtru zawiera i niezawiera, pomiędzy tymi filtrami zwasze stosowany jest spójnik ORAZ. " +
            "Opcje ORAZ/LUB mają zastosowania do każdego filtru zawiera/niezawiera oddzielnie, jeśli podanych jest kilka wyrażeń po przecinku. " +
            "W przypadku wpisania jedego wyrażenia opcje ORAZ/LUB nie mają zastosowania.";
        public static string SubwordInfo { get; } = "W tym trybie wyszukiwane są wyrazy, które można utworzyć z wyrazu wzorca, " +
            "poprzez usunięcie z niego niektórych liter, np. dla wzorca TTATARAK dopasowane zostaną m. in. wyrazy: " +
            "TATA, ATAK, RAK. We wzorcu dozwolone są jedynie litery.";
        public static string SuperwordInfo { get; } = "W tym trybie wyszukiwane są wyrazy, które można utworzyć z wyrazu wzorca, " +
            "poprzez dodanie do niego dodatkowych liter (bez zmiany kolejności liter we wzorcu), np. dla wzorca TRAWA dopasowane zostaną m. in. wyrazy: " +
            "TRAtWA, alTeRnAtyWA. We wzorcu dozwolone są jedynie litery.";
        public static string StenoanagramwordInfo { get; } = "W tym trybie zwracane są wszystkie wyrazy, " +
            "dla których podany we wzorcu wyraz jest stenoanagramem. Stenoanagramy to wyrazy powstałe z " +
            "niepowtarzalnych liter danego wyrazu, np. stenoanagramem wyrazu BRAK jest m. in. wyraz BRAKARKA. " +
            "We wzorcu dozwolone są tylko litery. Dodatkowo litery we wzorcu nie mogą się powtarzać.";
        public static string WordInWordInfo { get; } = "W tym trybie wyszukiwane są wyrazy pasujące do podanego wzorca. " +
            "Ponadto litery, które we wzorcu były oznaczone kropką muszą również tworzyć słowo ze słownika, np. " +
            "dla wzorca SZ.... dopasowane zostaną m. in. wyrazy SZRAMA, SZKRAB; natomiast np. wyraz SZAŁAS nie zostaie " +
            "dopasowany, gdyż wyrażenie AŁAS nie występuje w słowniku." + Environment.NewLine + Environment.NewLine +
            "W tym trybie wzorzec musi zawierać co najmniej 3 kropki.";

        public static string WordsFromWordInfo { get; } = "W tym trybie wyszukiwane są wszystkie wyrazy, które złożone są tylko z liter podanych we wzorcu. " +
            " Litery te mogą wystapić dowolną ilość razy (w szczególności mogą nie wystąpić wcale), np. " +
            "do słowa AGREST dopasowane zostaną m. in. słowa: GEST, TARG, STRATEG, AGREGAT." + Environment.NewLine + Environment.NewLine +
            "UWAGA. W tym trybie dopasowywane są tylko wyrazy złożone z co najmniej 3 liter.";

        public static string CryptharitmInfo { get; } = "Tryb do szukania rozwiązań kryptarytmów, czyli łamigłowek, w których w poprawnym działaniu, " +
            "wszystkie cyfry zostały zastąpione literami (różnym cyfrom odpowiadają różne litery, różnym literom odpowiadają " +
            "różne cyfry). Należy wypełnić wszystkie pola literami, tworząc kryptarytm. Przyciskami dodaj/usuń " +
            "można zmieniać ilość składowych działania (minium 2, maksimum 5). Z listy można wybrać rodzaj działania. " +
            "Po uzupełnieniu wszystkich pól i liknięciu 'Rozwiąż' zostaną wyszukane wszystkie możliwe rozwiązania podanego kryptarytmu.";

        public static string Shortcuts { get; } = "Dostępne skróty klawiaturowe:" + Environment.NewLine +
            "Enter - uruchamia wyszukiwanie dla aktualnego wzorca" + Environment.NewLine +
            "F5 - przejście do następnej zakładki" + Environment.NewLine +
            "F6 - zaznacza wzorzec" + Environment.NewLine +
            "Ctrl+1 - tryb Wzorzec" + Environment.NewLine +
            "Ctrl+2 - tryb Anagram" + Environment.NewLine +
            "Ctrl+3 - tryb Metagram" + Environment.NewLine +
            "Ctrl+4 - tryb Plus/Minus 1" + Environment.NewLine +
            "Ctrl+5 - tryb Podsłowa" + Environment.NewLine +
            "Ctrl+6 - tryb Nadsłowa" + Environment.NewLine +
            "Ctrl+7 - tryb Stenoangram" + Environment.NewLine +
            "Ctrl+8 - tryb Słowo w słowie" + Environment.NewLine +
            "Ctrl+9 - tryb Długość";

        public static string GetInfoMessage(int index)
        {
            return index switch
            {
                0 => PatternInfo,
                1 => AnagramInfo,
                2 => MetagramInfo,
                3 => LengthInfo,
                4 => UlozSamInfo,
                5 => PlusMinus1Info,
                6 => SubwordInfo,
                7 => SuperwordInfo,
                8 => StenoanagramwordInfo,
                9 => WordInWordInfo,
                10 => WordsFromWordInfo,
                11 => FiltersInfo,
                12 => CryptharitmInfo,
                13 => ScrabbleInfo,
                14 => Shortcuts,
                _ => "Nie ma takiego trybu",
            };
        }
    }
}
