namespace Mayhem.Dal.Dto.Dtos
{
    public struct BuildVersion
    {
        public static BuildVersion zero = new BuildVersion(0, 0, 0);

        public short Major;
        public short Minor;
        public short SubMinor;

        public BuildVersion(short _major, short _minor, short _subMinor)
        {
            Major = _major;
            Minor = _minor;
            SubMinor = _subMinor;
        }

        public BuildVersion(string _version)
        {
            string[] versionStrings = _version.Split('.');
            if (versionStrings.Length != 3)
            {
                Major = 0;
                Minor = 0;
                SubMinor = 0;
                return;
            }

            Major = short.Parse(versionStrings[0]);
            Minor = short.Parse(versionStrings[1]);
            SubMinor = short.Parse(versionStrings[2]);
        }

        public override string ToString()
        {
            return $"{Major}.{Minor}.{SubMinor}";
        }
    }
}
