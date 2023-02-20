﻿using System.Runtime.Serialization;

namespace Project_RPG_Heroes.Characters
{
    [Serializable]
    internal class NoWeaponEquippedException : Exception
    {
        public NoWeaponEquippedException()
        {
        }

        public NoWeaponEquippedException(string? message) : base(message)
        {
        }

        public NoWeaponEquippedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoWeaponEquippedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}