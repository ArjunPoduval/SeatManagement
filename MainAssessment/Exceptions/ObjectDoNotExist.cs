namespace MainAssessment.Exceptions
{
    public class ObjectDoNotExist : Exception
    {
        public ObjectDoNotExist() : base(string.Format("object doesn't exist.")) { }
    }
}
