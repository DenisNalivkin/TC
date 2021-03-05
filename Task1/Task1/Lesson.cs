
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
                for ( int i = 0; i < _materials.Length; i++ )
                {
                    GeneralForSiteEntities typeMaterial = Lesson.CloneElementMaterials( value[i] );
                    if ( typeMaterial is Video )
                    {
                        this._materials[i] = ( Video )typeMaterial;
                    }
                    if (typeMaterial is Text)
                    {
                        this._materials[i] = ( Text )typeMaterial;
                    }
                    if ( typeMaterial is Reference )
                    {
                        this._materials[i] = ( Reference )typeMaterial;
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
                if(material is Video)
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
            for(int i = 0; i < _materials.Length; i++)
            {
                GeneralForSiteEntities typeMaterial = Lesson.CloneElementMaterials( _materials[i] );
                if( typeMaterial is Video )
                {
                    duplicateMaterials[i] = ( Video )typeMaterial;
                }
                if( typeMaterial is Text )
                {
                    duplicateMaterials[i] = ( Text )typeMaterial;
                }
                if ( typeMaterial is Reference )
                {
                    duplicateMaterials[i] = ( Reference )typeMaterial;
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
        /// <summary>
        /// CloneElement Materials method copies elements of array with materials for lesson.
        /// </summary>
        /// <param name="materialType"> Element of array with material for lesson. </param>
        /// <returns>  Copy of lesson material. </returns>
        private static GeneralForSiteEntities CloneElementMaterials( GeneralForSiteEntities materialType )
        {
            if ( materialType is Video )
            {
                Video vFormat = ( Video )materialType;
                Video video = new Video( vFormat.TextDescription, vFormat.UrlVideo, vFormat.UrlPicture, vFormat.FormatVideo, vFormat.Version ); 
                return video;               
            }
            if( materialType is Text )
            {
                Text tFormat = ( Text )materialType;
                Text text = new Text( tFormat.TextDescription, tFormat.TextLesson );
                return text;
            }                           
            Reference rFormat = ( Reference )materialType;
            Reference reference = new Reference( rFormat.TextDescription, rFormat.ReferenceContent, rFormat.ReferenceType );
            return reference;
        }

        
    }
}
