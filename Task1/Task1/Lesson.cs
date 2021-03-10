using System;
namespace Task1
{/// <summary>
/// lesson class stores materials which will use on lesson.
/// </summary>
    class Lesson : GeneralEntity, IVersionable, ICloneable
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
                if ( value == null || value.Length <= LengthDescription )
                {
                    _textDescription = value;
                    return;
                }
                throw new ArgumentOutOfRangeException();
            }
        }       
        private GeneralEntity[] _materials;
        public GeneralEntity[] Materials
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

                _materials = new GeneralEntity[value.Length];
                for ( int i = 0; i < value.Length; i++ )
                {
                    if ( value[i] is Video )
                    {
                        Video copyVideo = ( Video )value[i];
                        _materials[i] = ( Video )copyVideo.Clone();
                    }
                    if ( value[i] is Text )
                    {
                        Text copyText = ( Text )value[i];
                        _materials[i] = ( Text )copyText.Clone();
                    }
                    if ( value[i] is ReferenceTraining )
                    {
                        ReferenceTraining copyRef = ( ReferenceTraining )value[i];
                        _materials[i] = ( ReferenceTraining )copyRef.Clone();
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

        public Lesson ( string textDescription, GeneralEntity[] materials, byte[] version )
        {
            this._uniueIdentifier = _uniueIdentifier.CreateIdentifier();
            this.TextDescription = textDescription;
            this.Materials = materials;
            this.Version = version;
        }

        public TypeLesson GetTypeLesson()
        {
            foreach( GeneralEntity material in this._materials )
            {
                if( material is Video )
                {
                    return TypeLesson.VideoLeson;                   
                }
            }
            return TypeLesson.TextLesson;
        }

        /// <summary>
        /// Clone method copies lessons.
        /// </summary>
        /// <returns>Copy of the lesson.</returns>
        public object Clone()
        {
            GeneralEntity[] duplicateMaterials = new GeneralEntity[this._materials.Length];          
            foreach( ICloneable elem in this._materials)
            {
                elem.Clone // Доделать

            }




           /* for( int i = 0; i < _materials.Length; i++ )
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
                if ( _materials[i] is ReferenceTraining )
                {
                    ReferenceTraining copyRef = ( ReferenceTraining )_materials[i];
                    duplicateMaterials[i] = ( ReferenceTraining )copyRef.Clone();
                }
           
            }
           */
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
