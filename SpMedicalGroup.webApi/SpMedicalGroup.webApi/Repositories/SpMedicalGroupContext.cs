using System;

namespace SpMedicalGroup.webApi.Repositories
{
    internal class SpMedicalGroupContext
    {
        public object Clinicas { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}