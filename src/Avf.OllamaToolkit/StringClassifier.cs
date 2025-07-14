
public static class StringClassifier
{
    public static WhitespaceType Classify(string str)
    {
        if (string.IsNullOrEmpty(str))
            return WhitespaceType.NoWhitespace;

            if (str.Contains('\n') && (!str.Contains('\r')))
            return WhitespaceType.MultilineLinux;

        if (str.Contains('\n') && str.Contains('\r'))
            return WhitespaceType.MultilineWindows;

        if (str.Contains('\n'))
            return WhitespaceType.Multiline;

        if (str.Any(char.IsWhiteSpace))
                return WhitespaceType.InlineWhitespace;

        return WhitespaceType.NoWhitespace;
    }
}
