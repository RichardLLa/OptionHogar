
namespace Infrastructure.Entities.Util
{
    public class LogError
    {

        private string _message;
        private int? _numberError;
        private string _stackTracer;
        private bool _errorValidado;
        private string _mensajeUsuario;

        public string StackTracer { get => _stackTracer; set => _stackTracer = value; }
        public string Message { get => _message; set => _message = value; }
        public int? NumberError { get => _numberError; set => _numberError = value; }
        public bool ErrorValidado { get => _errorValidado; set => _errorValidado = value; }
        public string MensajeUsuario { get => _mensajeUsuario; set => _mensajeUsuario = value; }
    }
}
