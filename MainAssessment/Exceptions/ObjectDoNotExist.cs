namespace MainAssessment.Exceptions
{
    public class ObjectDoNotExist : Exception
    {
        public ObjectDoNotExist(string Object) : base(string.Format($"{Object} doesn't exist.")) { }
    }
}
