namespace CodeBuilder.Expressions
{
    public abstract class ThisFieldReference
    {
        public abstract string ThisName { get; }
        public string FieldName { get; set; }
        public override string ToString() => ThisName + "." + FieldName;
    }
}
