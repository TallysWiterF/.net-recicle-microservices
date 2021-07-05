namespace Core.Objetos
{
    public static class MensagensValidador
    {
        public static string NotEnum = "Valor informado para {PropertyName} não está válido.";
        public static string NotNullGeneric(string campo) => $"{campo} precisa ser informado.";
        public static string EmailInvalid(string campo) => $"{campo} não está com e-mail válido.";
        public static string LengthInvalid(string campo) => campo + " contém mais caracteres que o permitido ({MaxLength}).";
        public static string MaxLengthInvalid(string campo) => campo + " contém mais caracteres que o permitido ({MaxLength}).";
        public static string MinLengthInvalid(string campo) => campo + " contém menos caracteres que o permitido ({MinLength}).";
        public static string GreaterThanOrEqualToInvalid(string campo) => campo + " deve ser maior ou igual a {ComparisonValue}.";
        public static string DontNumber(string campo) => $"{campo} precisa conter somente números.";
        public const string NotFound = "Registro não encontrado.";
    }
}
