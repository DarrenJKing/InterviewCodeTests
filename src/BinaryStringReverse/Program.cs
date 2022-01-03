using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

WriteLine( "Hacker Rank" );
SolveBinaryStringPuzzle( );

void SolveBinaryStringPuzzle( )
{
    var binNumber = "1101 1000"; // 110(1 100)0 / 1(10)1 1000 = 1110 0100
    string result = GetBinaryStringSwap( binNumber.Replace( " ", "" ) );
    if( result != "1110 0100".Replace( " ", "" ) )
    {
        WriteLine( "Nope." );
        return;
    }
    WriteLine( "Working" );
}

string GetBinaryStringSwap( string binaryString )
{
    var newBinString = binaryString;
    var sections = GetSectionsStartOne( newBinString ).ToArray( );
    var adjacentSections = FindAdjacentSections( sections ).ToArray( );
    if( adjacentSections.Length > 0 )
    {
        var item = adjacentSections[ 0 ];
        var swp = item.Item1.start > item.Item2.start ? (item.Item1, item.Item2) : (item.Item2, item.Item1);
        swp.Item1.start = swp.Item2.start;
        swp.Item2.start = swp.Item1.start + swp.Item1.series.Length;
        newBinString = OverwritePart( swp.Item1, newBinString );
        newBinString = OverwritePart( swp.Item2, newBinString );
        return Convert.ToInt32( binaryString, 2 ) > Convert.ToInt32( newBinString, 2 )
            ? binaryString
            : newBinString;
    }
    return newBinString;
}

string OverwritePart( (int start, char[ ] series) item, string binaryString )
{
    return binaryString.Remove( item.start, item.series.Length ).Insert( item.start, new string( item.series ) );
}

IEnumerable<((int start, char[ ] series), (int start, char[ ] series))> FindAdjacentSections( IEnumerable<(int start, char[ ] series)> sections )
{
    foreach( var section in sections.OrderBy( f => f.series.Length ) )
    {
        var sectionEnd = section.start + section.series.Length;
        foreach( var nextSection in sections )
        {
            if( sectionEnd == nextSection.start )
            {
                yield return (section, nextSection);
            }
        }
    }
}

IEnumerable<(int start, char[ ] series)> GetSectionsStartOne( string binaryString )
{
    for( int size = binaryString.Length - 2; size >= 2; size -= 2 )
    {
        int pos = binaryString.Length - size;
        for( int group = pos; group >= 0; group -= 1 )
        {
            var sp = binaryString.AsSpan( group, size );
            if( CheckStartsWith( sp, '1' ) && CheckIsBalanced( sp ) )
            {
                yield return (group, sp.ToArray( ));
            }
        }
    }
}

bool CheckStartsWith( ReadOnlySpan<char> readOnlySpan, char v )
{
    return readOnlySpan[ 0 ] == v;
}

bool CheckIsBalanced( ReadOnlySpan<char> readOnlySpan )
{
    int balance = 0;
    foreach( var ch in readOnlySpan )
    {
        balance += ch == '1' ? 1 : -1;
    }
    return balance == 0;
}