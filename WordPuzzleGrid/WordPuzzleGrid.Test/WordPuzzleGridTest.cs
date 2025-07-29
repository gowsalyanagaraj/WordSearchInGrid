namespace WordPuzzleGrid.Test
{
	[TestClass]
	public class WordPuzzleGridTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			// Arrange
			Solution solution = new Solution();

			solution.PuzzleGrid.Board =  new char[][]{
				 ['A','B','C','E'],
				 ['S','F','C','S'],
				 ['A','D','E','E']
				};

			solution.PuzzleGrid.SearchWord = "ABCCED";

			// Act
			bool result = solution.SearchWordInGrid();

			//Assert
			Assert.AreEqual(result, true);
		}
		
		[TestMethod]
		public void TestMethod2()
		{
			// Arrange
			Solution solution = new Solution();

			solution.PuzzleGrid.Board =  new char[][]{
				 ['A','B','C','E'],
				 ['S','F','C','S'],
				 ['A','D','E','E']
				};

			solution.PuzzleGrid.SearchWord = "FAC";

			// Act
			bool result = solution.SearchWordInGrid();

			//Assert
			Assert.AreEqual(result, true);
		}
	}
}
