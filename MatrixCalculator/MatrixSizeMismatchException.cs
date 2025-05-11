using System;

public class MatrixSizeMismatchException : MatrixOperationException
{
    public MatrixSizeMismatchException(string message) : base(message) { }
}