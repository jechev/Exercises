using System;
using System.Text;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        StringBuilder rnaText = new StringBuilder();

        if (nucleotide == "")
        {
            return nucleotide;
        }
        foreach (var dnaSymbol in nucleotide)
        {
            if (dnaSymbol == 'G')
            {
                rnaText.Append("C");
            }
            else if (dnaSymbol == 'C')
            {
                rnaText.Append("G");
            }
            else if (dnaSymbol == 'T')
            {
                rnaText.Append("A");
            }
            else if (dnaSymbol == 'A')
            {
                rnaText.Append("U");
            }
            else
            {
                rnaText.Append(nucleotide);
            }
        }

        return rnaText.ToString();
        
    }
}