﻿using System;
namespace Task1
{/// <summary>
/// lesson class stores materials which will use on lesson.
/// </summary>
    class Lesson : GeneralEntity, IVersionable, ICloneable
    {
        private const int _lengthVersion = 8;
        public int LengthVersion
        {
            get { return _lengthVersion; }
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
                Array.Copy(value, _materials, value.Length);              
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
                if ( value != null && value.Length == _lengthVersion )
                {
                    _version = new byte[_lengthVersion];
                    Array.Copy( value, _version, value.Length );
                    return;
                }
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Public constructor initializing the fields of the Lesson class object.
        /// </summary>
        /// <param name="textDescription"> Value for the field textDescription. </param>
        /// <param name="materials"> Value for the field materials.  </param>
        /// <param name="version">  Value for the field version. </param>
        public Lesson (string textDescription, GeneralEntity[] materials, byte[] version)  : base (textDescription)
        {         
            this.Materials = materials;
            this.Version = version;
        }

        /// <summary>
        /// GetTypeLesson method defines type of lesson.
        /// </summary>
        /// <returns> Type of lesson. </returns>
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
            int nodeIndex = 0;
            foreach ( ICloneable material in this._materials )
            {
                duplicateMaterials[nodeIndex] = (GeneralEntity)material.Clone();
                nodeIndex += 1;
            }
            byte[] duplicateVersion = new byte[_version.Length];
            Array.Copy(this._version, duplicateVersion, this._version.Length);
            return new Lesson(this.TextDescription, duplicateMaterials, duplicateVersion);         
        }        
    }
}
