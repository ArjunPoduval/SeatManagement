namespace MainAssessment.CustomException
{
    public class ObjectAlreadyExistException : Exception
    {
        public ObjectAlreadyExistException(string Object) : base(string.Format($"Similar {Object} already exist.")) { }

    }
}
