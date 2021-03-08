using System;
namespace Task1
{/// <summary>
/// lesson class stores materials which will use on lesson.
/// </summary>
    class Lesson : GeneralForSiteEntities, IVersionable, ICloneable
    {
        const int LengthVersion = 8;       
        private Guid _uniueIdentifier;
        public override Guid UniqueIdentifier
        {
            get
            {
                return _uniueIdentifier;
            }
        }
        private string _textDescription;
        public override string TextDescription
        {
            get
            {
                return _textDescription;
            }
            set
            {
                if ( value == null || value.Length <= lengthDescription )
                {
                    _textDescription = value;
                    return;
                }
                throw new ArgumentOutOfRangeException();
            }
        }       
        private GeneralForSiteEntities[] _materials;
        public GeneralForSiteEntities[] Materials
        {
            get
            {
                return _materials;
            }
            set
            {
                if( value == null )
                {
                    throw new ArgumentException();
                }
                _materials = new GeneralForSiteEntities[value.Length];
                for ( int i = 0; i < value.Length; i++ )
                {
                    if ( value[i] is Video )
                    {
                        Video copyVideo = (Video)value[i];
                        _materials[i] = (Video)copyVideo.Clone();
                    }
                    if ( value[i] is Text )
                    {
                        Text copyText = ( Text )value[i];
                        _materials[i] = ( Text )copyText.Clone();
                    }
                    if ( value[i] is Reference )
                    {
                        Reference copyRef = ( Reference )value[i];
                        _materials[i] = ( Reference )copyRef.Clone();
                    }

                }
            }
        }
        private byte[] _version;
        public byte[] Version
        {
            get
            {
                return _version;
            }
            set
            {
                if ( value != null && value.Length == LengthVersion )
                {
                    _version = new byte[LengthVersion];
                    Array.Copy( value, _version, value.Length );
                    return;
                }
                throw new ArgumentException();
            }
        }

        public Lesson ( string textDescription, GeneralForSiteEntities[] materials, byte[] version )
        {
            this._uniueIdentifier = _uniueIdentifier.CreateIdentifier();
            this.TextDescription = textDescription;
            this.Materials = materials;
            this.Version = version;
        }

        public Lesson()
        {

        }

        public GeneralForSiteEntities GetTypeLesson()
        {
            foreach( GeneralForSiteEntities material in this._materials )
            {
                if( material is Video )
                {
                    return new Video();
                }
            }
            return new Text();           
        }
        /// <summary>
        /// Clone method copies lessons.
        /// </summary>
        /// <returns>Copy of the lesson.</returns>
        public object Clone()
        {
            GeneralForSiteEntities[] duplicateMaterials = new GeneralForSiteEntities[this._materials.Length];          
            for( int i = 0; i < _materials.Length; i++ )
            {
                if( _materials[i] is Video )
                {
                    Video copyVideo = ( Video )_materials[i];
                    duplicateMaterials[i] = ( Video )copyVideo.Clone();
                }
                if( _materials[i] is Text )
                {
                    Text copyText = ( Text )_materials[i];
                    duplicateMaterials[i] = ( Text )copyText.Clone();
                }
                if ( _materials[i] is Reference )
                {
                    Reference copyRef = ( Reference )_materials[i];
                    duplicateMaterials[i] = ( Reference )copyRef.Clone();
                }
            }
            byte[] duplicateVersion = new byte[_version.Length];
            Array.Copy( this._version, duplicateVersion, this._version.Length );
            return new Lesson 
            {
                _uniueIdentifier = this._uniueIdentifier,
                _textDescription = this._textDescription,
                _materials = duplicateMaterials,
                _version = duplicateVersion
            };                 
        }       
    }
}
