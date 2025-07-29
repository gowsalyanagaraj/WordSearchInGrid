namespace WordPuzzleGrid;

/* 
Given a 2D grid of characters and a word, return true if the word exists in the grid. 
The word can be constructed from letters of sequentially adjacent cells (horizontally or vertically and in any direction – forward or backward).

  Sample Input:

    char[][] board = {
       ['A','B','C','E'],
       ['S','F','C','S'],
       ['A','D','E','E']
    };
    string word = "ABCCED";

  Sample Output:

    true
*/

public class WordPuzzleGrid
{
	public char[][] Board {  get; set; }
	public string SearchWord { get; set; }
	
}

public class Solution
{
	public WordPuzzleGrid PuzzleGrid { get; set; } = new WordPuzzleGrid();

	static int nSearchStringIndex = 0;
	static string strTemp = "";

	static int nRowLimit, nColumnLimit;

	public bool SearchWordInGrid()
	{
		char startLetter = PuzzleGrid.SearchWord[0];

		nColumnLimit = PuzzleGrid.Board.Length;
		for(int i = 0; i < nColumnLimit; i++)
		{
			nRowLimit = PuzzleGrid.Board[i].Length;
			for(int j = 0; j < nRowLimit; j++)
			{
				if(PuzzleGrid.Board[i][j].Equals(startLetter))
				{
					SequentialSearch(PuzzleGrid, startLetter, i, j);

					if(strTemp == PuzzleGrid.SearchWord)
					{
						return true;
					}
					strTemp = "";
				}
			}
		}

		return false;
	}

	private void SequentialSearch(WordPuzzleGrid grid, char letter, int nPositionOne, int nPositionTwo)
	{
		strTemp += letter;
		nSearchStringIndex++;
		char searchLetter = nSearchStringIndex < grid.SearchWord.Length ? grid.SearchWord[nSearchStringIndex] : ' ';

		// Checking using positions
		// Left
		if(nPositionTwo - 1 >= 0 && (grid.Board[nPositionOne][nPositionTwo - 1] == searchLetter))
		{
			SequentialSearch(grid, searchLetter, nPositionOne, nPositionTwo - 1);
		}
		// Right
		if(nPositionTwo + 1 < nRowLimit && (grid.Board[nPositionOne][nPositionTwo + 1] == searchLetter))
		{
			SequentialSearch(grid, searchLetter, nPositionOne, nPositionTwo + 1);
		}
		// Top
		if(nPositionOne - 1 >= 0 && (grid.Board[nPositionOne - 1][nPositionTwo] == searchLetter))
		{
			SequentialSearch(grid, searchLetter, nPositionOne - 1, nPositionTwo);
		}
		// Bottom
		if(nPositionOne + 1 < nColumnLimit && (grid.Board[nPositionOne + 1][nPositionTwo] == searchLetter))
		{
			SequentialSearch(grid, searchLetter, nPositionOne + 1, nPositionTwo);
		}

		// Backtracking
		if(strTemp.Length == grid.SearchWord.Length)
		{
			return;
		}
		else
		{
			strTemp = strTemp.Substring(0, strTemp.Length - 1);
			nSearchStringIndex--;
		}
	}
}