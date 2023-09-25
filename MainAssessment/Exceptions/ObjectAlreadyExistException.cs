namespace MainAssessment.CustomException
{
    public class ObjectAlreadyExistException : Exception
    {
        public ObjectAlreadyExistException() : base(string.Format("Similar object already exist.")) { }

        public ObjectAlreadyExistException(string message) : base(message) { }
    }
}
