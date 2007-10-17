namespace HSMS.Bo
{
    /// <summary>
    /// This class represent a pupil's parent.
    /// </summary>
    public class HSMSParent
    {
        private HSMSPupil hsmsPupil;

        /// <summary>
        /// Constructs a new HSMSParent object.
        /// </summary>
        public HSMSParent()
        {
        }

        /// <summary>
        /// Constructs a new HSMSParent object.
        /// </summary>
        /// <param name="hsmsPupil"></param>
        public HSMSParent(HSMSPupil hsmsPupil)
        {
            this.hsmsPupil = hsmsPupil;
        }

        public HSMSPupil HsmsPupil
        {
            get { return hsmsPupil; }
            set { hsmsPupil = value; }
        }
    }
}
