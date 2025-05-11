using System;

public class InvalidMatrixOperationException : MatrixOperationException
{
    public InvalidMatrixOperationException(string message) : base(message) { }
}