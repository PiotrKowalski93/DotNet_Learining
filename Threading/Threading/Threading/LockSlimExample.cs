using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading
{
    public class LockSlimExample
    {
        private readonly List<Contact> contacts;
        private readonly ReaderWriterLockSlim contactLock = new ReaderWriterLockSlim();

        public LockSlimExample(List<Contact> initContacts)
        {
            contacts = initContacts;
        }

        public void AddContact(Contact newContact)
        {
            try
            {
                contactLock.EnterWriteLock();
                contacts.Add(newContact);
            }
            finally
            {
                contactLock.ExitWriteLock();
            }
        }

        public Contact GetContactByName(string name)
        {
            try
            {
                contactLock.EnterReadLock();
                return contacts.FirstOrDefault(x => x.Name == name);
            }
            finally
            {
                contactLock.ExitReadLock();
            }
        }
    }

    public class Contact
    {
        public string Name { get; set; }
    }
}
