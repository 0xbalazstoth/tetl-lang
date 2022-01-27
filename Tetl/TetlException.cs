using System;

namespace Tetl
{
    public class TetlBaseException : System.Exception
    {
        public string? ErrorMessage { get; set; }
        public object? Variable { get; set; }
        public object? Value { get; set; }
        public object? Left { get; set; }
        public object? Right { get; set; }
    }

    public class TetlCannotCompareValuesException : TetlBaseException
    {
    }

    public class TetlFunctionNotDefinedException : TetlBaseException
    {
        public object? Function { get; set; }
    }

    public class TetlVariableNotDefinedException : TetlBaseException
    {
    }

    public class TetlValueIsNotBooleanException : TetlBaseException
    {
    }
    
    public class TetlInvalidAdditionException : TetlBaseException
    {
        
    }

    public class TetlInvalidMultiplicationException : TetlBaseException
    {
    }
    
    public class TetlInvalidDivisionException : TetlBaseException
    {
    }

    public class TetlInvalidModulusException : TetlBaseException
    {
    }
}