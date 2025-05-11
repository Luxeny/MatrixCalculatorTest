using System;
using Xunit;

public class MathMatrixTests
{
    [Fact]
    public void Constructor_WithValidSize_CreatesMatrix()
    {
        var matrix = new MathMatrix(3);
        Assert.Equal(3, matrix.GetSize());
    }

    [Fact]
    public void Constructor_WithArray_CreatesMatrix()
    {
        int[,] testArray = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        var matrix = new MathMatrix(testArray);
        
        Assert.Equal(testArray, matrix.GetMatrix());
    }

    [Fact]
    public void Constructor_WithNonSquareArray_ThrowsException()
    {
        int[,] invalidArray = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
        Assert.Throws<ArgumentException>(() => new MathMatrix(invalidArray));
    }

    [Fact]
    public void AddOperator_WithSameSize_ReturnsSum()
    {
        var firstMatrix = new MathMatrix(new int[,] { { 1, 2 }, { 3, 4 } });
        var secondMatrix = new MathMatrix(new int[,] { { 5, 6 }, { 7, 8 } });
        var result = firstMatrix + secondMatrix;
        
        Assert.Equal(new int[,] { { 6, 8 }, { 10, 12 } }, result.GetMatrix());
    }

    [Fact]
    public void AddOperator_WithDifferentSizes_ThrowsException()
    {
        var firstMatrix = new MathMatrix(2);
        var secondMatrix = new MathMatrix(3);
        
        Assert.Throws<MatrixSizeMismatchException>(() => firstMatrix + secondMatrix);
    }

    [Fact]
    public void MultiplyOperator_WithSameSize_ReturnsProduct()
    {
        var firstMatrix = new MathMatrix(new int[,] { { 1, 2 }, { 3, 4 } });
        var secondMatrix = new MathMatrix(new int[,] { { 5, 6 }, { 7, 8 } });
        var result = firstMatrix * secondMatrix;
        
        Assert.Equal(new int[,] { { 19, 22 }, { 43, 50 } }, result.GetMatrix());
    }

    [Fact]
    public void MultiplyOperator_WithDifferentSizes_ThrowsException()
    {
        var firstMatrix = new MathMatrix(2);
        var secondMatrix = new MathMatrix(3);
        
        Assert.Throws<MatrixSizeMismatchException>(() => firstMatrix * secondMatrix);
    }

    [Fact]
    public void Determinant_2x2Matrix_CalculatesCorrectly()
    {
        var matrix = new MathMatrix(new int[,] { { 1, 2 }, { 3, 4 } });
        
        Assert.Equal(-2, matrix.Determinant());
    }

    [Fact]
    public void Determinant_3x3Matrix_CalculatesCorrectly()
    {
        var matrix = new MathMatrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
        
        Assert.Equal(0, matrix.Determinant());
    }

    [Fact]
    public void Inverse_2x2Matrix_CalculatesCorrectly()
    {
        var matrix = new MathMatrix(new int[,] { { 4, 7 }, { 2, 6 } });
        var inverseMatrix = matrix.Inverse();
        var expectedMatrix = new MathMatrix(new int[,] { { 3, -3 }, { -1, 2 } });
        
        Assert.Equal(expectedMatrix.GetMatrix(), inverseMatrix.GetMatrix());
    }

    [Fact]
    public void Inverse_SingularMatrix_ThrowsException()
    {
        var matrix = new MathMatrix(new int[,] { { 1, 2 }, { 2, 4 } });
        
        Assert.Throws<InvalidMatrixOperationException>(() => matrix.Inverse());
    }

    [Fact]
    public void CompareOperators_CompareByDeterminant()
    {
        var firstMatrix = new MathMatrix(new int[,] { { 1, 2 }, { 3, 4 } });
        var secondMatrix = new MathMatrix(new int[,] { { 0, 1 }, { 1, 0 } });
        
        Assert.True(firstMatrix < secondMatrix);
        Assert.False(firstMatrix > secondMatrix);
    }

    [Fact]
    public void EqualityOperators_CompareMatrixValues()
    {
        var firstMatrix = new MathMatrix(new int[,] { { 1, 2 }, { 3, 4 } });
        var secondMatrix = new MathMatrix(new int[,] { { 1, 2 }, { 3, 4 } });
        var thirdMatrix = new MathMatrix(new int[,] { { 1, 2 }, { 3, 5 } });
        
        Assert.True(firstMatrix == secondMatrix);
        Assert.False(firstMatrix == thirdMatrix);
        Assert.True(firstMatrix != thirdMatrix);
    }

    [Fact]
    public void ExplicitConversion_ToInt_ReturnsDeterminant()
    {
        var matrix = new MathMatrix(new int[,] { { 1, 2 }, { 3, 4 } });
        
        int determinant = (int)matrix;
        Assert.Equal(-2, determinant);
    }

    [Fact]
    public void TrueFalseOperators_CheckDeterminant()
    {
        var singularMatrix = new MathMatrix(new int[,] { { 1, 2 }, { 2, 4 } });
        var nonSingularMatrix = new MathMatrix(new int[,] { { 1, 2 }, { 3, 4 } });

        Assert.Equal(0, singularMatrix.Determinant());
        Assert.NotEqual(0, nonSingularMatrix.Determinant());
    }

    [Fact]
    public void Clone_CreatesDeepCopy()
    {
        var originalMatrix = new MathMatrix(new int[,] { { 1, 2 }, { 3, 4 } });
        var clonedMatrix = originalMatrix.Clone() as MathMatrix;
        
        Assert.Equal(originalMatrix.GetMatrix(), clonedMatrix.GetMatrix());
        Assert.NotSame(originalMatrix.GetMatrix(), clonedMatrix.GetMatrix());
    }

    [Fact]
    public void CompareTo_ComparesByDeterminant()
    {
        var firstMatrix = new MathMatrix(new int[,] { { 1, 2 }, { 3, 4 } });
        var secondMatrix = new MathMatrix(new int[,] { { 0, 1 }, { 1, 0 } });
        
        Assert.Equal(-1, firstMatrix.CompareTo(secondMatrix));
        Assert.Equal(1, secondMatrix.CompareTo(firstMatrix));
    }

    [Fact]
    public void ToString_ReturnsCorrectFormat()
    {
        var matrix = new MathMatrix(new int[,] { { 1, 2 }, { 3, 4 } });
        
        Assert.Equal("1 2 \n3 4 \n", matrix.ToString());
    }

    [Fact]
    public void IsSymmetric_WithSymmetricMatrix_ReturnsTrue()
    {
        var matrix = new MathMatrix(new int[,] { { 1, 2, 3 }, { 2, 4, 5 }, { 3, 5, 6 } });
        
        Assert.True(matrix.IsSymmetric());
    }

    [Fact]
    public void IsSymmetric_WithNonSymmetricMatrix_ReturnsFalse()
    {
        var matrix = new MathMatrix(new int[,] { { 1, 2 }, { 3, 4 } });
        
        Assert.False(matrix.IsSymmetric());
    }

    [Fact]
    public void Trace_CalculatesCorrectly()
    {
        var matrix = new MathMatrix(new int[,] { { 1, 2 }, { 3, 4 } });
        
        Assert.Equal(5, matrix.Trace());
    }
}

public static class MathMatrixTestExtensions
{
    public static int[,] GetMatrix(this MathMatrix matrix)
    {
        var matrixField = typeof(MathMatrix).GetField("_matrix",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        return (int[,])matrixField.GetValue(matrix);
    }

    public static int GetSize(this MathMatrix matrix)
    {
        var sizeField = typeof(MathMatrix).GetField("_size",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        return (int)sizeField.GetValue(matrix);
    }
}
