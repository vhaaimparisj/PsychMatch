namespace PsychMatch
{
    /// <summary>
    /// Summary description for ADINFO
    /// </summary>
    /// 

    public class ADINFO
    {

        string _ADGroupName;
        bool _ADGroupIsMember;
        string _NTUsername;

        public void ADAccountInfo()
        {
            _ADGroupName = ADGroupName;
            _ADGroupIsMember = ADGroupIsMember;

        }

        public string ADGroupName
        {
            get { return _ADGroupName; }
            set { _ADGroupName = value; }
        }

        public bool ADGroupIsMember
        {
            get { return _ADGroupIsMember; }
            set { _ADGroupIsMember = value; }
        }

        public string NTUsername
        {
            get { return _NTUsername; }
            set { _NTUsername = value; }
        }
    }
}