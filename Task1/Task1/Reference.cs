﻿using System;
namespace Task1
{/// <summary>
/// Reference class stores references for lesson.
/// </summary>
    class Reference : GeneralForSiteEntities, ICloneable
    {
        private Guid _uniqueIdentifier;
        public override Guid UniqueIdentifier
        {
            get
            {
                return _uniqueIdentifier;
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
        private string _referenceContent;
        public string ReferenceContent
        {
            get
            {
                return _referenceContent;
            }
            set
            {
                if( !string.IsNullOrEmpty( value ) )
                {
                   _referenceContent = value;
                    return;
                }
                throw new ArgumentException();
            }
        }
        public TypeReference ReferenceType { get; set; } 

        public Reference( string textDescription, string referenceContent, TypeReference referenceType )
        {
            this._uniqueIdentifier = _uniqueIdentifier.CreateIdentifier();
            this.TextDescription = textDescription;
            this.ReferenceContent = referenceContent;           
            this.ReferenceType = referenceType;
        }

        /// <summary>
        ///  Clone method copies object of class Reference.
        /// </summary>
        /// <returns>  Copy of the Reference. </returns>
        public object Clone()
        {
            Reference reference = new Reference( this.TextDescription, this.ReferenceContent, this.ReferenceType );
            return reference;
        }
    }
}